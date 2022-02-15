using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ExplosiveBombCreatorButton : AbstractBombCreator, IDragHandler, IEndDragHandler
{
    [SerializeField] Transform TargetTransform;
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
        CreateObjectsOfPool(10,Vector3.zero,Quaternion.Euler(Vector3.zero));
    }
    public void OnDrag(PointerEventData eventData)
    {
        CalculateThrowForce();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ThrowBomb();
        ThrowForceX = 0;
        ThrowForceY = 0;
    }
    protected override AbstractBomb CreateBomb() 
    {
        return SpawnFromPool(TargetTransform.position, TargetTransform.rotation).AddComponent<ExplosiveBomb>();
    }
    private void CalculateThrowForce()
    {
        ThrowForceX = (transform.position.x - Input.mousePosition.x) * 0.1f;
        ThrowForceY = (transform.position.y - Input.mousePosition.y) * 0.3f;
    }

}
