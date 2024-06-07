using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : Singleton<EnemyPooling>
{
    [SerializeField] GameObject _enemy;
    [SerializeField] List<GameObject> _listEnemy = new List<GameObject>();

    public GameObject InstantiateEnemy(Vector2 pos, Quaternion rot)
    {
        foreach (GameObject enemy in _listEnemy)
        {
            if (enemy.activeSelf)
            {
                continue;
            }
            enemy.transform.position = pos;
            enemy.transform.rotation = rot;
            return enemy;
        }

        GameObject newEnemy = Instantiate(_enemy, pos, rot);
        _listEnemy.Add(newEnemy);
        newEnemy.SetActive(false);
        return newEnemy;
    }
}
