using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    [SerializeField] Dictionary<GameObject, List<GameObject>> _listObjects = new Dictionary<GameObject, List<GameObject>>();

    public GameObject GetObject(GameObject defaultPrefab)
    {
        if (_listObjects.ContainsKey(defaultPrefab))
        {
            foreach(GameObject @object in _listObjects[defaultPrefab])
            {
                if (@object.activeSelf)
                {
                    continue;
                }
                return @object;
            }

            GameObject newGameObj = Instantiate(defaultPrefab,this.transform.position, Quaternion.identity);
            _listObjects[defaultPrefab].Add(newGameObj);
            newGameObj.SetActive(false);
            return newGameObj;
        }

        List<GameObject> newListInstanceObj = new List<GameObject>();
        GameObject newGameObj2 = Instantiate(defaultPrefab, this.transform.position, Quaternion.identity);
        newListInstanceObj.Add(newGameObj2);
        newGameObj2.SetActive(false);

        _listObjects.Add(defaultPrefab, newListInstanceObj);
        return newGameObj2;
    }
}
