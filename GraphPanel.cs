using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Reflection;

namespace ServiceUtilityCigiDLL
{
    public partial class GraphPanel : UserControl
    {
        private List<IFrameGraph> frameGraph = new List<IFrameGraph>();

        private ZedGraph.MasterPane masterPane;

        private int graphWidth = 0;
        private int graphHeight = 0;

        public GraphPanel(int GraphWidth, int GraphHeight)
        {
            InitializeComponent();

            graphWidth = GraphWidth;
            graphHeight = GraphHeight;

            zedGraph.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(zedGraph_ContextMenuBuilder);
            zedGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraph_PointValueEvent);
            zedGraph.IsShowPointValues = true;

            masterPane = zedGraph.MasterPane;
            zedGraph.Size = new Size(GraphWidth, GraphHeight);
            masterPane.PaneList.Clear();
        }

        public void CreateGraph(IFrameGraph obj)
        {
            frameGraph.Add(obj);
            masterPane.Add(obj.getFrameGraph());

            updateMasterPane();
        }

        public List<IFrameGraph> getFrameGraph()
        {
            return frameGraph;
        }

        void zedGraph_ContextMenuBuilder(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            //удалить ненужные пункты меню
            for (int i = 0; i < 6; i++)
                menuStrip.Items.RemoveAt(2);

            ToolStripItem ResetScale = new ToolStripMenuItem("Reset Scale");
            menuStrip.Items.Add(ResetScale);
            ResetScale.Click += new EventHandler(ResetScale_Click);

            ToolStripItem ClearPoint = new ToolStripMenuItem("Clear All Point");
            menuStrip.Items.Add(ClearPoint);
            ClearPoint.Click += new EventHandler(ClearPoint_Click);
        }

        private void ResetScale_Click(object sender, EventArgs e)
        {
            resetScale();
        }
        private void ClearPoint_Click(object sender, EventArgs e)
        {
            ClearPoint();
        }

        public void updateGraphs()
        {
            foreach (var graph in frameGraph)
                graph.updateFrame();

            updateMasterPane();
        }
        public void ClearPoint()
        {
            foreach (var graph in frameGraph)
                graph.clearPoint();

            updateMasterPane();
        }

        public void resetScale()
        {
            foreach (var graph in frameGraph)
                graph.resetScale();

            updateMasterPane();
        }

        private void updateMasterPane()
        {
            using (Graphics g = CreateGraphics())
            {
                // Графики будут размещены в один столбец друг под другом
                masterPane.SetLayout (g, PaneLayout.SingleColumn);
            }

            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }
        string zedGraph_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair point = curve[iPt];

            return string.Format("X: {0:F3}\nY: {1:F3}", point.X, point.Y);
        }
    }
}
