using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCreator : MonoBehaviour
{
    [SerializeField] protected GameObject PrefabToCreate;
    [SerializeField] protected Transform PositionToCreatePrefab;
    protected Queue<GameObject> Pool = new Queue<GameObject>();
    protected virtual void CreateObjectsOfPool(int Size)
    {
        GameObject PBContainer = new GameObject();
        PBContainer.name = PrefabToCreate.name + " Container";
        for (int i = 0; i < Size; i++)
        {
            GameObject PB = Instantiate(PrefabToCreate,Vector3.zero,Quaternion.Euler(Vector3.zero),PBContainer.transform);
            PB.SetActive(false);
            Pool.Enqueue(PB);
        }
    }
    
    protected GameObject SpawnFromPool(Vector3 Position, Quaternion Rotation)
    {
        GameObject ObjToSpawn = Pool.Dequeue();

        ObjToSpawn.SetActive(true);
        ObjToSpawn.transform.position = Position;
        ObjToSpawn.transform.rotation = Rotation;

        Pool.Enqueue(ObjToSpawn);
        return ObjToSpawn;
    }
    
}
