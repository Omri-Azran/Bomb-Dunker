using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBombCreator : ProjectileCreator

{
    [SerializeField] protected float ThrowForceX = 25;
    [SerializeField] protected float ThrowForceY = 25;
   
    protected abstract AbstractBomb CreateBomb();
}
