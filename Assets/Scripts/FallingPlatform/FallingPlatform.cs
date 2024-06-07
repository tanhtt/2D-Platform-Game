using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class FallingPlatform : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    Animator anim;

    [SerializeField]
    float delayTime = 0.5f;

    [SerializeField]
    float destroyTime = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ShakeAndFall());
        }
    }

    private IEnumerator ShakeAndFall()
    {
        anim.SetBool("isShaking", true);
        yield return new WaitForSeconds(delayTime);
        anim.SetBool("isShaking", false);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(this.gameObject, destroyTime);
    }
}
