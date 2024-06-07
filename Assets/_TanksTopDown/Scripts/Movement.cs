using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tank_top_down
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D rb;
        public float rotationSpeed;
        public float speed;

        [SerializeField] Transform bullet;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxis("Vertical");

            if(x != 0)
            {
                transform.rotation *= Quaternion.Euler(0,0, - x * rotationSpeed * Time.deltaTime);
            }
            if(y != 0)
            {
                // Lấy transform để lấy đúng hướng của gameobject, còn Vector2.up là hướng của world space (tí nhầm)
                rb.velocity = this.transform.up * speed * y * Time.deltaTime;
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                GameObject bulletClone = ObjectPooling.Instance.GetObject(bullet.gameObject);
                bulletClone.transform.position = transform.position;
                bulletClone.transform.rotation = transform.rotation;
                bulletClone.SetActive(true);
                AudioCtrl.Instance.PlaySound("UIForward");
            }
        }
    }
}

