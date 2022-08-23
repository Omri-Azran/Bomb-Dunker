using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemyCreator : AbstractCreator
{
    protected abstract AbstractEnemy CreateUniqueEnemy();
    protected IEnumerator CreateEnemies(int Size, float TimeBetweenEnemies)
    {
        for (int i = 0; i < Size; i++)
        {
            CreateUniqueEnemy();
            yield return new WaitForSeconds(TimeBetweenEnemies);
        }
    }
}
