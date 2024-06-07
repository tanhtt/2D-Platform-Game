using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tank_top_down
{
    public class BulletFly : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField] float speed;
        [SerializeField] float lifeTime;

        Coroutine _DeactiveWait = null;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _DeactiveWait =  StartCoroutine(DeactiveAfterTime());
        }

        private void OnDisable()
        {
            if(_DeactiveWait != null)
            {
                StopCoroutine(_DeactiveWait);
                _DeactiveWait = null;
            }
        }

        // Update is called once per frame
        void Update()
        {
           rb.velocity = this.transform.up * speed * Time.deltaTime;
        }

        IEnumerator DeactiveAfterTime()
        {
            yield return new WaitForSeconds(lifeTime);
            this.gameObject.SetActive(false);
        }
    }
}