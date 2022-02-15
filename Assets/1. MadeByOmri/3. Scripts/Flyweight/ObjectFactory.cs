using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    List<ObjectMain> bombs = new List<ObjectMain>();

    public ObjectMain CreateNewBomb(ObjectExtra sharedstate)
    {
        if(bombs == null)
        {
            bombs.Add(new ObjectMain(sharedstate));
        }
        return bombs[0];
    }
}
