using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolfikan.GraphView
{
    [CreateAssetMenu(fileName = "GraphNode", menuName = "Wolfikan/Create GraphNode")]
    public class GraphNodeAsset : ScriptableObject
    {
        public GraphNode Node;
    }
}