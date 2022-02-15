using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMain : MonoBehaviour
{
    ObjectExtra _sharedState;

    public ObjectMain (ObjectExtra sharedstate)
    {
        _sharedState = sharedstate;
    }
}
