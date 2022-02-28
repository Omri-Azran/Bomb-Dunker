using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponChooser : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private ProjectileCreator _ProjCreator;
    [SerializeField] GameObject[] Creators;

    private void Awake()
    {
        _ProjCreator = Creators[0].GetComponent<ProjectileCreator>();
        gameObject.GetComponent<Image>().color = _ProjCreator.GetComponent<Image>().color;
    }
    public WeaponChooser (ProjectileCreator ProjCreator)
    {
        TransitionTo(ProjCreator);
    }

    public void TransitionTo(ProjectileCreator ProjCreator)
    {
        _ProjCreator = ProjCreator;
        gameObject.GetComponent<Image>().color = ProjCreator.GetComponent<Image>().color;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _ProjCreator.CalculateShot();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _ProjCreator.ShootShot();
    }

}
