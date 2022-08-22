using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateorPool : AbstractPool
{
    protected override void ExecutePoolCommand()
    {

        GameObject PBContainer = new GameObject();
        PBContainer.name = PrefabToCreate.name + " Container";
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject PB = Instantiate(PrefabToCreate, Vector3.zero, Quaternion.Euler(Vector3.zero), PBContainer.transform);
            PB.SetActive(false);
            Pool.Enqueue(PB);
        }
    }

}
