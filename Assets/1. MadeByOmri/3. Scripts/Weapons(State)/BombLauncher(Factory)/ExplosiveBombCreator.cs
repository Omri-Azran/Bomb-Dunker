using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ExplosiveBombCreator : AbstractBombCreator, IDragHandler, IEndDragHandler
{

    private void Start()
    {
        CreateObjectsOfPool(10);
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
        return SpawnFromPool(PositionToCreatePrefab.position, PositionToCreatePrefab.rotation).AddComponent<ExplosiveBomb>();
    }
    private void CalculateThrowForce()
    {
        ThrowForceX = (transform.position.x - Input.mousePosition.x) * 0.1f;
        ThrowForceY = (transform.position.y - Input.mousePosition.y) * 0.3f;
    }

}
