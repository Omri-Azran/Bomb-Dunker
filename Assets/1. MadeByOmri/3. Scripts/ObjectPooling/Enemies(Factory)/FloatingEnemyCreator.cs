using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemyCreator : AbstractEnemyCreator
{
    bool HasBeenCreated = false;
    [SerializeField] int EnemiesToCreate = 5;
    private void Awake()
    {
        CreateObjectsOfPool(EnemiesToCreate, Vector3.zero, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovmentCC>() && HasBeenCreated == false)
        {
            StartCoroutine(CreateEnemies(EnemiesToCreate, 0.2f));
            HasBeenCreated = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovmentCC>() && HasBeenCreated == true)
        {
            HasBeenCreated = false;
        }
    }

    protected override AbstractEnemy CreateUniqueEnemy()
    {
        return SpawnFromPool(transform.position, Quaternion.identity).AddComponent<FloatingEnemy>();
    }
}
