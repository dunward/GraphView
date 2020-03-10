using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wolfikan.GraphView
{
    [System.Flags]
    public enum GraphPortIO
    { 
        Input   = (1 << 0),
        Output  = (1 << 1),
    }
}