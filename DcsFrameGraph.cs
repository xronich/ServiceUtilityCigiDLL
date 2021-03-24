using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ServiceUtilityCigiDLL
{
    public class DcsFrameGraph : IFrameGraph
    {
        GraphPane pane = new GraphPane();
        GraphObjList graphObjList = new GraphObjList();
        PointPairList pointList = new PointPairList();
        GraphObjList RedLineList = new GraphObjList();

        private string title = "";

        private int timeAfterStart = 0;
        private double workTime = 0.0;

        private string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public DcsFrameGraph(string Name)
        {
            name = Name;
            
            title = Regex.Replace(name, "([a-z])([A-Z])", "$1 Working $2");

            loadDefaultSettings();

            clearGraph();
        }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr getWorkingTime();

        private void loadDefaultSettings()
        {
            pane.Title.Text = "";
            pane.Title.FontSpec.Size = 25;

            pane.XAxis.Scale.Max = 600;
            pane.XAxis.Scale.Min = 0;

            pane.YAxis.Title.Text = "        No data        ";
            pane.XAxis.Title.Text = "Time:  sec";

            pane.YAxis.Title.FontSpec.Angle = 90;
            pane.YAxis.Title.FontSpec.Size = 22;
            pane.YAxis.Scale.FontSpec.Size = 20;
            pane.XAxis.Title.FontSpec.Size = 22;
            pane.XAxis.Scale.FontSpec.Size = 20;
        }

        public void resetScale()
        {
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
        }
        public void clearPoint()
        {
            pointList.Clear();
        }

        public int getFrameCount()
        {
            return 0;
        }

        public GraphPane getFrameGraph()
        {
            return pane;
        }

        public void updateFrame()
        {
            IntPtr arrayValue = getWorkingTime();

            if (arrayValue == null)
                return;

            Dictionary<string, float> frameTime = arrayValue.ToStringFloat();

            workTime = frameTime[name];

            //двигаем график учитывая увеличение времени
            moveGraph(timeAfterStart);

            timeAfterStart++;

            pane.XAxis.Title.Text = $"Time: { timeAfterStart } sec";
            pane.YAxis.Title.Text = $"{ title } \n\n { Math.Round(workTime,6) * 1000 } ms  \n\n";

            //что бы не ломало маштаб графика при перезагрузке дкс
            if (workTime > 1)
                workTime = pane.YAxis.Scale.Max;

            pointList.Add(timeAfterStart, workTime);
        }

        private void moveGraph(double mTime)
        {
            if (pane.XAxis.Scale.Max - 100 < mTime)
                pane.XAxis.Scale.Max++;
        }

        public void clearGraph()
        {
            timeAfterStart = 0;
            workTime = 0;

            pointList.Clear();
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();
            foreach (var line in graphObjList)
                pane.GraphObjList.Add(line);
            pane.AddCurve(" ", pointList, Color.Blue, SymbolType.None);
        }
    }
}

