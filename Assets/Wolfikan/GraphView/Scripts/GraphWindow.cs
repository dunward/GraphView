using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Wolfikan.GraphView
{
    public class GraphWindow : EditorWindow
    {
        private GraphView graphView;

        [MenuItem("Wolfikan/GraphView")]
        public static void OpenGraphViewWindow()
        {
            var window = GetWindow<GraphWindow>();
            window.titleContent = new GUIContent("Graph View");
            window.Show();
        }

        private void OnEnable()
        {
            graphView = new GraphView()
            {
                name = "Graph View",
            };

            graphView.StretchToParentSize();

            rootVisualElement.Add(graphView);
        }
    }
}