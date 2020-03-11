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
        private GraphWindow graphWindow;

        public GraphView(GraphWindow graphWindow)
        {
            this.graphWindow = graphWindow;

            SetupZoom(UnityGraph.ContentZoomer.DefaultMinScale, UnityGraph.ContentZoomer.DefaultMaxScale);

			this.AddManipulator(new UnityGraph.ContentDragger());
			this.AddManipulator(new UnityGraph.SelectionDragger());
			this.AddManipulator(new UnityGraph.RectangleSelector());

			var grid = new UnityGraph.GridBackground();
			Insert(0, grid);
			grid.StretchToParentSize();

            provider = ScriptableObject.CreateInstance<SearchProvider>();
            provider.Initialize(this, graphWindow);

            nodeCreationRequest = (evt) =>
            {
                UnityGraph.SearchWindow.Open(new UnityGraph.SearchWindowContext(evt.screenMousePosition), provider);
            };

            // AddElement(GenerateGraphNode());
		}

        public void AddGraphNode(GraphNodeAsset asset, Vector2 position)
        {
            GraphNode node = new GraphNode(asset);

            node.title = node.Name;
            node.SetPosition(new Rect(position, Vector2.zero));

            node.GUID = GUID.Generate().ToString();

            foreach (var input in node.Port.inputs)
            {
                var port = GeneratePort(node, UnityGraph.Direction.Input, UnityGraph.Port.Capacity.Single, input.Type);
                port.portName = input.Name;
                node.inputContainer.Add(port);
            }

            foreach (var output in node.Port.outputs)
            {
                var port = GeneratePort(node, UnityGraph.Direction.Output, UnityGraph.Port.Capacity.Multi, output.Type);
                port.portName = output.Name;
                node.outputContainer.Add(port);
            }

            node.RefreshExpandedState();
            node.RefreshPorts();

            AddElement(node);
        }

        private UnityGraph.Port GeneratePort(GraphNode node, UnityGraph.Direction direction, UnityGraph.Port.Capacity capacity, Type type)
        {
            return node.InstantiatePort(UnityGraph.Orientation.Horizontal, direction, capacity, type);
        }
    }
}