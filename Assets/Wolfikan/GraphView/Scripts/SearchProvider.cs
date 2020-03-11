using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Wolfikan.GraphView
{
    public class SearchProvider : ScriptableObject, ISearchWindowProvider
    {
        private GraphView graphView;
        private GraphWindow graphWindow;

        private Texture2D transparent;

        public void Initialize(GraphView graphView, GraphWindow graphWindow)
        {
            this.graphView = graphView;
            this.graphWindow = graphWindow;
            
            transparent = new Texture2D(1, 1);
            transparent.SetPixel(0, 0, new Color(0, 0, 0, 0));
            transparent.Apply();
        }

        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            var assets = Resources.LoadAll<GraphNodeAsset>("Node");

            var tree = new List<SearchTreeEntry>();

            tree.Add(new SearchTreeGroupEntry(new GUIContent("Create Node")));

            foreach (var asset in assets)
            {
                tree.Add(new SearchTreeEntry(new GUIContent(asset.Name, transparent)) { level = 1, userData = asset });
            }

            return tree;
        }

        public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
        {
            var asset = SearchTreeEntry.userData as GraphNodeAsset;

            var windowMousePosition = graphWindow.rootVisualElement.ChangeCoordinatesTo(graphWindow.rootVisualElement.parent, context.screenMousePosition - graphWindow.position.position);
            var graphMousePosition = graphView.contentViewContainer.WorldToLocal(windowMousePosition);

            graphView.AddGraphNode(asset, graphMousePosition);

            return true;
        }
    }
}