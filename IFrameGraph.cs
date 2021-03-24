using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace ServiceUtilityCigiDLL
{
    public interface IFrameGraph
    {
        string Name { get; set; }
        GraphPane getFrameGraph();
        void updateFrame();
        void resetScale();
        int getFrameCount();
        void clearPoint();
        void clearGraph();
    }
}
