using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChooser : MonoBehaviour
{
    private WeaponCreator _weaponCreator;
    [SerializeField] GameObject[] Choosers;


    //GUI doesnt get clicks from mouse. find another way to trigger the choosers to wake up
    private void OnMouseDown()
    {
        Debug.Log("Hey");
        foreach(GameObject chooser in Choosers)
        {
            chooser.SetActive(true);
        }
    }
    private void OnMouseUp()
    {
        foreach (GameObject chooser in Choosers)
        {
            chooser.SetActive(false);
        }
    }
    public WeaponChooser (WeaponCreator weaponCreator)
    {
        TransitionTo(weaponCreator);
    }

    public void TransitionTo(WeaponCreator weaponCreator)
    {
        _weaponCreator = weaponCreator;
    }
}
