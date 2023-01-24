using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public Vector3 target;
    Vector3 direction;
    public float speed;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        direction = target - transform.position;
        direction = direction.normalized;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Explosion"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().AddScore(25);
            Destroy(gameObject);
        }
    }
}
