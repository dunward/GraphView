using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolfikan.GraphView
{
    [CreateAssetMenu(fileName = "GraphNode", menuName = "Wolfikan/Create GraphNode"), System.Serializable]
    public class GraphNodeAsset : ScriptableObject
    {
        [HideInInspector] public string GUID;
        public string Name;
        public GraphPort Port;
    }
}