using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemyCreator : AbstractEnemyCreator
{
    bool HasBeenCreated = false;
    [SerializeField] int EnemiesToCreate = 5;
    private void Awake()
    {
        CreateObjectsOfPool(EnemiesToCreate);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==6 /*player*/ && HasBeenCreated == false)
        {
            StartCoroutine(CreateEnemies(EnemiesToCreate, 0.2f));
            HasBeenCreated = true;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.layer==6 /*player*/ && HasBeenCreated == true)
    //    {
    //        HasBeenCreated = false;
    //    }
    //}

    protected override AbstractEnemy CreateUniqueEnemy()
    {
        return SpawnFromPool(transform.position, Quaternion.identity).AddComponent<FloatingEnemy>();       
    }
}
