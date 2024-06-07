using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wraped_city_game
{
    public class GunCtrl : MonoBehaviour
    {
        [SerializeField] float _fireSpeed = 1f;
        float _timeFireCount = 0;
        [SerializeField] GameObject bulletPrefab;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            _timeFireCount -= Time.deltaTime;
        }

        public void Fire()
        {
            if(_timeFireCount > 0)
            {
                return;
            }
            _timeFireCount = _fireSpeed;
            GameObject bullet = ObjectPooling.Instance.GetBullet();
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, this.transform.parent.localScale.x == 1 ? 0 : 180, 0);
            bullet.SetActive(true);
        }
    }
}
