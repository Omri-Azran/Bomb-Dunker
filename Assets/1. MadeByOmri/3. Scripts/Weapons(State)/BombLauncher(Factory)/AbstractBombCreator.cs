using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBombCreator : WeaponCreator

{
    [SerializeField] protected float ThrowForceX = 25;
    [SerializeField] protected float ThrowForceY = 25;
   
    protected abstract AbstractBomb CreateBomb();
    protected void ThrowBomb()
    {
        CreateBomb().GetComponent<Rigidbody>().AddForce(new Vector3(ThrowForceX, ThrowForceY, 0), ForceMode.Impulse);
    }
}
