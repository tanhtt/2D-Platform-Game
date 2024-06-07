using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public Rigidbody2D rb;
    [SerializeField] public Queue<Vector3> points = new Queue<Vector3>();
    public bool isReachTarget = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            //target.position = pos;
            points.Enqueue(pos);
        }

        if(isReachTarget && points.Count != 0)
        {
            target.position = points.Dequeue();
            isReachTarget = false;
            Debug.Log("Dequeue object");
            Debug.Log("Count: " + points.Count);
        }

        if(isReachTarget)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        dir.Normalize();

        MoveByVelocity(dir);

        float angle = Mathf.Atan2(dir.y, dir.x);

        Quaternion rot = transform.rotation;
        rot.eulerAngles = new Vector3(0, 0, angle + 90);
        transform.rotation = rot;
    }

    void MoveByAddVector(Vector3 dir)
    {
        this.transform.position += dir * speed * Time.deltaTime;
    }

    void MoveByVelocity(Vector3 dir)
    {
        rb.velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals(Constant.Target))
        {
            isReachTarget = true;
            Debug.Log("Reach Target");
            Debug.Log("is reach target: " + isReachTarget);
        }
    }
}
