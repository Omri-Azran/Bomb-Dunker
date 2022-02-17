using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBomb : MonoBehaviour
{
    
    protected IEnumerator BombSequence(int Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        Detonate();
        gameObject.SetActive(false);
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);            
    }

    protected abstract void Detonate();

}
