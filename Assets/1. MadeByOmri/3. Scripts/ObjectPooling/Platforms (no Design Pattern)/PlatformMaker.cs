using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlatformMaker : AbstractCreator, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject platform;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        CreateObjectsOfPool(2, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        platform = SpawnFromPool(cam.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y, -cam.transform.position.z)), Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        platform.transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        platform.transform.position =  cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
    }
}
