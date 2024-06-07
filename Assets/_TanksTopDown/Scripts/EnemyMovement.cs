using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tank_top_down
{
    public class EnemyMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField] float moveSpeed;
        [SerializeField] GameObject target;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            target = GameManager.Instance.Player;
        }

        // Update is called once per frame
        void Update()
        {
            if (!target)
            {
                return;
            }
            Quaternion rot = transform.rotation;
            Vector2 dir = target.transform.position - transform.position;
            if(dir.sqrMagnitude < 1f)
            {
                rb.velocity = Vector2.zero;
                return;
            }

            float newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rot.eulerAngles = new Vector3(0,0,newAngle);
            transform.rotation = rot;

            //rb.velocity = transform.right * moveSpeed * Time.deltaTime;
            rb.velocity = dir.normalized * moveSpeed *Time.deltaTime;
        }

        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                GameManager.Instance.SetScore(1);

                collision.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }
}
