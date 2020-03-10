using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityGraph = UnityEditor.Experimental.GraphView;

namespace Wolfikan.GraphView
{
    public class GraphView : UnityGraph.GraphView
    {
        private SearchProvider provider;

        public GraphView()
        {
            SetupZoom(UnityGraph.ContentZoomer.DefaultMinScale, UnityGraph.ContentZoomer.DefaultMaxScale);

			this.AddManipulator(new UnityGraph.ContentDragger());
			this.AddManipulator(new UnityGraph.SelectionDragger());
			this.AddManipulator(new UnityGraph.RectangleSelector());

			var grid = new UnityGraph.GridBackground();
			Insert(0, grid);
			grid.StretchToParentSize();

            // AddElement(GenerateGraphNode());
		}

        private GraphNode GenerateGraphNode()
        {
            var node = Resources.Load<GraphNodeAsset>("GraphNode").Node;

            node.GUID = GUID.Generate().ToString();

            //foreach (var input in node.Port.inputs)
            //{
            //    node.inputContainer.Add(GeneratePort(node, UnityGraph.Direction.Input, UnityGraph.Port.Capacity.Single, input.Type));
            //}

            //foreach (var output in node.Port.outputs)
            //{
            //    node.outputContainer.Add(GeneratePort(node, UnityGraph.Direction.Input, UnityGraph.Port.Capacity.Multi, output.Type));
            //}

            node.RefreshExpandedState();
            node.RefreshPorts();

            return node;
        }

        private UnityGraph.Port GeneratePort(GraphNode node, UnityGraph.Direction direction, UnityGraph.Port.Capacity capacity, Type type)
        {
            return node.InstantiatePort(UnityGraph.Orientation.Horizontal, direction, capacity, type);
        }
    }
}