using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : AbstractEnemy
{
    [SerializeField] int Meters = 10;
    private void FixedUpdate()
    {
        Move(Meters);
    }
}
