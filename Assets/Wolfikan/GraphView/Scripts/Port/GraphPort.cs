using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolfikan.GraphView
{
    [System.Serializable]
    public class GraphPort
    {
        public GraphPortIO IO;

        public List<GraphPortData> inputs;
        public List<GraphPortData> outputs;
    }
}