using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//must have rigidbody
public class Bullet : MonoBehaviour
{
    private void Update()
    {
        //rigidbody.movepos
        transform.Translate(Vector3.up*Time.deltaTime*5);
    }
}
