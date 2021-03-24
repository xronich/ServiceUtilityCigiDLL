using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ServiceUtilityCigiDLL
{
    public class ChannelFrameGraph : IFrameGraph
    {
        private GraphPane pane = new GraphPane();
        private GraphObjList graphObjList = new GraphObjList();
        private PointPairList pointList = new PointPairList();
        private GraphObjList redLineList = new GraphObjList();
        private PointPairList peakPointList = new PointPairList();

        private int totalLags = 0;
        private double previusFramtTime = 0;
        private double modelTime = 0;
        private double framtTime = 0;
        private int frameCount = 0;

        private string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public ChannelFrameGraph(string Name)
        {
            name = Name;

            loadDefaultSettings(); 

            clearGraph();
        }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr GetFrameTime(string ip);

        private void drawLines(bool needDrawRedPickLine = true)
        //добавление пунктирных линий, линий пиков frametime на сетку графика ( ограничение оси Y до 50 )
        {
            graphObjList.Clear();
            pane.GraphObjList.Clear();

            double level;
            for (int i = 0; i < 6; i++)
            {
                level = 10 * i;
                LineObj line = new LineObj(pane.XAxis.Scale.Min, level, pane.XAxis.Scale.Max, level);

                // Стиль линии - пунктирная
                line.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

                graphObjList.Add(line);
            }

            foreach (var line in graphObjList)
                pane.GraphObjList.Add(line);

            if (needDrawRedPickLine)
            {
                foreach (var line in redLineList)
                    pane.GraphObjList.Add(line);
            }
        }

        private void loadDefaultSettings()
        {
            pane.Title.Text = "";
            pane.Title.FontSpec.Size = 25;

            pane.YAxis.MajorGrid.IsZeroLine = false;

            pane.YAxis.Scale.Max = 55;
            pane.YAxis.Scale.Min = -4;
            pane.XAxis.Scale.Max = 600;
            pane.XAxis.Scale.Min = 0;

            pane.YAxis.Title.Text = "        No data        ";
            pane.XAxis.Title.Text = "Model Time:  sec";

            pane.YAxis.Title.FontSpec.Angle = 90;
            pane.YAxis.Title.FontSpec.Size = 28;
            pane.YAxis.Scale.FontSpec.Size = 25;
            pane.XAxis.Title.FontSpec.Size = 28;
            pane.XAxis.Scale.FontSpec.Size = 25;
 
            drawLines();
        }

        public void resetScale()
        {
            pane.YAxis.Scale.Max = 55;
            pane.YAxis.Scale.Min = -4;

            pane.XAxis.Scale.Max = modelTime + 300;
            pane.XAxis.Scale.Min = modelTime - 300;

            drawLines();
        }

        public int getFrameCount()
        {
            return frameCount;
        }

        public void clearPoint()
        {
            totalLags = 0;
            pointList.Clear();
            pane.GraphObjList.Clear();
            drawLines(false);
        }

        public GraphPane getFrameGraph()
        {
            return pane;
        }

        public void updateFrame()
        {
            IntPtr arrayValue = GetFrameTime(name);

            if (arrayValue == null)
                return; 

            Dictionary<float, float> frameTime = arrayValue.ToFloatFloat();

            frameCount = frameTime.Count();

            //признак рестарта DCS
            if (frameTime.Count == 0)
            {
                pane.YAxis.Title.Text = "        No data        ";
                loadDefaultSettings();
                clearGraph();
                return;
            }

            //если в дкс пауза - не обновлять график ФПС
            if ( modelTime > frameTime.First().Key )
                return;

            PointPairList tempPointList = new PointPairList();

            foreach (var frame in frameTime)
            {
                modelTime = frame.Key;
                framtTime = frame.Value;

                //обновляем данные текста на графике
                updateTitleGraphText();

                //двигаем график учитывая модельное время
                moveGraph(modelTime);

                //удаляем красные линии пиков frametime ушедшие за границу графика
                removeRedPeakLineAbroadGraph();

                foreach ( var item in pane.GraphObjList)
                {
                    if (item.Location.X < pane.XAxis.Scale.Min)
                        item.IsVisible = false;
                }

                if (framtTime > 24)
                {
                    if (framtTime > pane.YAxis.Scale.Max)
                        framtTime = pane.YAxis.Scale.Max;

                    //рисуем красную линию пиков frametime
                    drawRedPeakLine();

                    peakPointList.Add(modelTime, framtTime);

                    totalLags++;
                    continue;
                }

                tempPointList.Add(modelTime, framtTime);
                previusFramtTime = framtTime;
            }

            if (tempPointList.Count == 0)
                return;

            pointList.Add(tempPointList.First());
            pointList.Add(tempPointList.Last());
        }

        private void drawRedPeakLine()
        {
            LineObj line = new LineObj(Color.Red, modelTime, framtTime, modelTime, previusFramtTime);
            // Стиль линии - пунктирная
            line.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            redLineList.Add(line);
            pane.GraphObjList.Add(line);
        }

        private void removeRedPeakLineAbroadGraph()
        {
            foreach (var item in pane.GraphObjList)
            {
                if (item.Location.X < pane.XAxis.Scale.Min)
                    item.IsVisible = false;
            }
        }

        private void moveGraph(double mTime)
        {
            if (pane.XAxis.Scale.Max - 50 < mTime)
            {
                pane.XAxis.Scale.Max++;
                pane.XAxis.Scale.Min++;

                foreach (LineObj line in pane.GraphObjList)
                    if (line.Line.Style == System.Drawing.Drawing2D.DashStyle.Dash)
                        line.Location.X++;
            }
        }

        private void updateTitleGraphText()
        {
            pane.YAxis.Title.Text = $"{name} \n { Math.Round(framtTime, 1).ToString() } ms\n { totalLags } lags";
            pane.XAxis.Title.Text = $"Model Time: { Math.Round(modelTime).ToString() } sec\n Frame count per tick: { frameCount }";
        }

        public void clearGraph()
        {
            totalLags = 0;
            pointList.Clear();
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();
            foreach (var line in graphObjList)
                pane.GraphObjList.Add(line);
            pane.AddCurve(" ", pointList, Color.Blue, SymbolType.None);
        }
    }
}
