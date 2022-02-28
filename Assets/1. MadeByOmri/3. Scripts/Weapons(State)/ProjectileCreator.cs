using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileCreator : AbstractCreator
{
    protected WeaponChooser _weaponChooser;

    public void ChooseWeapon(WeaponChooser weaponChooser)
    {
        _weaponChooser = weaponChooser;
    }

    public abstract void CalculateShot();
    public abstract void ShootShot();

}
