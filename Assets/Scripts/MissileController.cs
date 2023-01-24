using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public Vector3 target;
    Vector3 direction;
    public float speed;

    Rigidbody2D rb2d;

    public GameObject explosion;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        direction = target - transform.position;
        direction = direction.normalized;
    }

    private void Update()
    {
        if (Vector3.Distance(target, transform.position) <= 0.15f)
            Explode();

    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    private void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    } 
}