using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public abstract class AbstractEnemy : MonoBehaviour
{
    Rigidbody RB;
    protected float Speed { get => speed; set => speed = value; }
    float speed = 10f;
    Vector3 StartPos;
    bool MoveRight = true;
    static protected int EnemyCount = 0;
    private void Awake()
    {
        EnemyCount++;
        RB = GetComponent<Rigidbody>();
        StartPos = transform.position;
    }
    protected void Move(int Meters) 
    {
        if (MoveRight)
            RB.MovePosition(Vector3.MoveTowards(transform.position, transform.position + Vector3.right * Meters, Time.deltaTime * Speed));
        else
            RB.MovePosition(Vector3.MoveTowards(transform.position, transform.position + Vector3.left * Meters, Time.deltaTime * Speed));

        if (transform.position.x >= StartPos.x + Meters)
        {
            MoveRight = false;
        }
        else if(transform.position.x <= StartPos.x)
        {
            MoveRight = true;
        }

    }

    public void StopMoving()
    {
        Speed = 0;
        RB.useGravity = true;
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        RB.useGravity = false;
        RB.velocity = Vector3.zero;
    }

}
