using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wraped_city_game
{
    public class BulletBase : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float lifeTime;

        private Rigidbody2D rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            StartCoroutine(LifeTimeBullet());
        }

        // Update is called once per frame
        void Update()
        {
            rb.velocity = speed * this.transform.right;
        }

        IEnumerator LifeTimeBullet()
        {
            yield return new WaitForSeconds(lifeTime);
            this.gameObject.SetActive(false);
        }
    }
}
