using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponCreator : AbstractCreator
{
    protected WeaponChooser _weaponChooser;

    public void ChooseWeapon(WeaponChooser weaponChooser)
    {
        _weaponChooser = weaponChooser;
    }
}
