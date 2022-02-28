using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletCreator : ProjectileCreator
{
    bool IsShooting = false;
    Vector3 pos;
    float angle;
    Joystick joystick;
    Rigidbody PrefabToCreateRB;
    int BulletsToCreate = 5;
    float TimeBetweenBullets = 0.1f;
    private void Awake()
    {
        CreateObjectsOfPool(BulletsToCreate*3);
        joystick = GetComponentInParent<FixedJoystick>();
        PrefabToCreateRB = PrefabToCreate.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.Log(Angle(new Vector2(joystick.Horizontal, -joystick.Vertical)));
    }
    public override void CalculateShot()
    {
        IsShooting = true;
        StartCoroutine(Calculation());
    }

    public override void ShootShot()
    {
        IsShooting = false;
        StartCoroutine(ShootMultipleBullets());
        PrefabToCreateRB.velocity = Vector3.zero;
    }
    IEnumerator Calculation()
    {
        while(IsShooting)
        {
            pos = new Vector3(PositionToCreatePrefab.transform.position.x - joystick.Horizontal, PositionToCreatePrefab.transform.position.y - joystick.Vertical, 0);
            angle = Angle(new Vector2(joystick.Horizontal, -joystick.Vertical));
            yield return null;
        }
    }
    IEnumerator ShootMultipleBullets()
    {
        for (int i = 0; i < BulletsToCreate; i++)
        {
            SpawnFromPool(pos, Quaternion.Euler(new Vector3(0, 0, angle))).AddComponent<Bullet>();
            yield return new WaitForSeconds(TimeBetweenBullets);
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
