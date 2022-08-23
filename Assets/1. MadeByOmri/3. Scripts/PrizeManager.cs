using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    [SerializeField] GameObject Key;

    public void CreatePrize()
    {

        Instantiate(Key, transform.position, Quaternion.identity);
    }
}
