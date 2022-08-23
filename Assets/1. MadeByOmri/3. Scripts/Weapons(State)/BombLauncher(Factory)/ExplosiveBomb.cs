using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class ExplosiveBomb : AbstractBomb
{
    float ExplosionForce = 1000;
    float ExplosionRadius = 7;

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlatformIdentifier>() && collision != null)
        {
            StartCoroutine(BombSequence(1));
        }
    }

    protected override void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (Collider collider in colliders)
        {
            //all enemies derive from AbstractEnemies
            if (collider.gameObject.GetComponent<AbstractEnemy>())
            {
                Rigidbody enemyRB = collider.GetComponent<Rigidbody>();
                if (enemyRB != null)
                {
                    collider.gameObject.GetComponent<FloatingEnemy>().StopMoving();
                    enemyRB.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
                    enemyRB.transform.GetComponent<FloatingEnemy>().CreateDoorKey();
                }
            }
        }
    }
}
