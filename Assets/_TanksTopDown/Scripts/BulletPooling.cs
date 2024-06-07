using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : Singleton<BulletPooling>
{
    [SerializeField] GameObject bullet;
    [SerializeField] List<GameObject> _listBullet = new List<GameObject>();

    public GameObject InstantiateBullet(Vector2 pos, Quaternion rot)
    {
        foreach(GameObject bullet in _listBullet)
        {
            if (bullet.activeSelf)
            {
                continue;
            }
            bullet.transform.position = pos;
            bullet.transform.rotation = rot;
            return bullet;
        }

        GameObject newBullet =  Instantiate(bullet, pos, rot);
        _listBullet.Add(newBullet);
        newBullet.SetActive(false);
        return newBullet;
    }
}
