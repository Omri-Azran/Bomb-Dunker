using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    float Speed = 1f;
    Rigidbody RB;
    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        RB.MovePosition(transform.position+transform.TransformDirection(Vector3.up*Speed));
        
    }
}
