using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletCreator : AbstractCreator, IBeginDragHandler, IEndDragHandler
{
    bool IsShooting = false;
    float SecondsToWait = 0.5f;
    Vector3 pos;
    private void Awake()
    {
        CreateObjectsOfPool(10);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        IsShooting = true;
        StartCoroutine(Shoot());
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        IsShooting = false;
    }
    IEnumerator Shoot()
    {
        while(IsShooting)
        {
            //get real direction of bullet
            SpawnFromPool(PositionToCreatePrefab.transform.position, PrefabToCreate.transform.rotation).AddComponent<Bullet>();
            yield return new WaitForSeconds(SecondsToWait);
        }
    }

}
