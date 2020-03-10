using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Wolfikan.GraphView
{
    [CreateAssetMenu(fileName = "GraphNode", menuName = "Wolfikan/Create GraphNode"), System.Serializable]
    public class GraphNode : Node
    {
        [HideInInspector] public string GUID;
        public string Name;
        public GraphPort Port;
    }
}