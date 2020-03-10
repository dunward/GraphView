using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolfikan.GraphView
{
    [System.Serializable]
    public class GraphPortData
    {
        [SerializeField] private string name;
        [SerializeField] private GraphPortType type;

        public string Name
        {
            get => name;
        }

        public System.Type Type
        {
            get
            {
                switch (type)
                {
                    default:
                        return typeof(int);

                    case GraphPortType.Float:
                        return typeof(float);
                }
            }
        }
    }
}