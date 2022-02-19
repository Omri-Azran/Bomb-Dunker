using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletCreator : WeaponCreator, IBeginDragHandler, IEndDragHandler
{
    bool IsShooting = false;
    float SecondsToWait = 0.1f;
    Vector3 pos;
    Joystick joystick;
    Rigidbody PrefabToCreateRB;
    private void Awake()
    {
        CreateObjectsOfPool(10);
        joystick = GetComponent<FixedJoystick>();
        PrefabToCreateRB = PrefabToCreate.GetComponent<Rigidbody>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        IsShooting = true;
        StartCoroutine(Shoot());
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        IsShooting = false;
        PrefabToCreateRB.velocity = Vector3.zero;
    }
    IEnumerator Shoot()
    {
        while(IsShooting)
        {
            pos = new Vector3(PositionToCreatePrefab.transform.position.x - joystick.Horizontal, PositionToCreatePrefab.transform.position.y - joystick.Vertical, 0);
            SpawnFromPool(pos, Quaternion.Euler(new Vector3(0,0,Angle(new Vector2(joystick.Horizontal, -joystick.Vertical))))).AddComponent<Bullet>();
            yield return new WaitForSeconds(SecondsToWait);
        }
    }
    public float Angle(Vector2 vector2)
    {
        if (vector2.x < 0)
        {
            return 360 - (Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg;
        }
    }

}
