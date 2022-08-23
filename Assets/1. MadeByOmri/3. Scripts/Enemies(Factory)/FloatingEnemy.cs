using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : AbstractEnemy
{
    [SerializeField] int Meters = 10;
    Rigidbody enemyRB;
    float ExplosionForce = 1000;
    float ExplosionRadius = 7;
    private void FixedUpdate()
    {
        Move(Meters);
        enemyRB = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==8) //weapon
        {

            if (enemyRB != null)
            {
                StopMoving();
                enemyRB.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
                CreateDoorKey();
            }
        }
        
    }

    public void CreateDoorKey()
    {
        if (EnemyCount % 5 == 0)
        {
            transform.parent.GetComponent<PrizeManager>().CreatePrize();
        }
    }
}
