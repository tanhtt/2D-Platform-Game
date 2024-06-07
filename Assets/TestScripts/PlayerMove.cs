using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D colli;
    public Vector2 force;
    public bool canJump = false;
    public float speed = 3f;
    public float angle = 0;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.TestRay();
        this.TestMultiRay();
        this.Moving();
    }

    void TestRay()
    {
        Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 100, layerMask);
        Debug.DrawRay(transform.position, dir.normalized * 100);

        if(hit.collider != null)
        {
            Debug.Log("Hit: "+ hit.collider.name);
        }
    }

    void TestMultiRay()
    {
        Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        RaycastHit2D[] hits = new RaycastHit2D[10];
        colli.Cast(dir, hits, 100, false);
        Debug.DrawRay(this.transform.position, dir.normalized * 100, Color.red);

        foreach (RaycastHit2D hit in hits)
        {
            if(hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                Debug.DrawRay(hit.point, hit.normal, Color.yellow);
            }
        }
    }

    void Moving()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(force);
            canJump = false;
        }
        rb.velocity = new Vector2(horizontalInput * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
