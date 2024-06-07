using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wraped_city_game
{
    public class ObjectPooling : MonoBehaviour
    {
        private static ObjectPooling _instance;
        public static ObjectPooling Instance => _instance;

        [SerializeField] GameObject _bulletPrefab;
        [SerializeField] List<GameObject> _bulletList;

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
            }else if (_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
            {
                Destroy(this.gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public GameObject GetBullet()
        {
            foreach(GameObject bullet in _bulletList)
            {
                if (bullet.activeSelf)
                {
                    continue;
                }
                return bullet;
            }
            GameObject newBullet = Instantiate(_bulletPrefab, this.transform.position, Quaternion.identity, this.transform);
            _bulletList.Add(newBullet);
            newBullet.SetActive(false);

            return newBullet;
        }
    }
}
