using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyBase CreateEnemy(EnemyData enemyData, Vector3 position)
    {
        if (enemyData.enemyPrefab == null)
        {
            Debug.LogError($"Enemy prefab not assigned in {enemyData.name}!");
            return null;
        }
        // Instantiate the specific enemy prefab at the given position
        GameObject enemyInstance = GameObject.Instantiate(enemyData.enemyPrefab, position, Quaternion.identity);
        // Get the Enemy component and assign the EnemyData properties
        EnemyBase enemy = enemyInstance.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.GetComponent<Enemy>().enemyData = enemyData;
        }
        else
        {
            Debug.LogError("The prefab does not contain an EnemyBase component!");
        }
        Debug.Log($"Created {enemyData.enemyName} at {position}");
        return enemy;
    }
}
