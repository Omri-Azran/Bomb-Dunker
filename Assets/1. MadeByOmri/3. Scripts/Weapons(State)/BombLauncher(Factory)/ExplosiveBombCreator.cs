using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ExplosiveBombCreator : AbstractBombCreator
{
    bool IsShooting = false;
    private void Awake()
    {
        CreateObjectsOfPool(10);
    }

    protected override AbstractBomb CreateBomb() 
    {
        return SpawnFromPool(PositionToCreatePrefab.position, PositionToCreatePrefab.rotation).AddComponent<ExplosiveBomb>();
    }

    public override void CalculateShot()
    {
        IsShooting = true;
        StartCoroutine(ShootBomb());
    }

    public override void ShootShot()
    {
        IsShooting = false;
        CreateBomb().GetComponent<Rigidbody>().AddForce(new Vector3(ThrowForceX, ThrowForceY, 0), ForceMode.Impulse);
        ThrowForceX = 0;
        ThrowForceY = 0;
    }
    IEnumerator ShootBomb()
    {
        while(IsShooting)
        {
            ThrowForceX = (transform.position.x - Input.mousePosition.x) * 0.1f;
            ThrowForceY = (transform.position.y - Input.mousePosition.y) * 0.3f;
            yield return null;
        }
    }
}
