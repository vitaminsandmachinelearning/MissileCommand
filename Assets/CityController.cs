using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    public Sprite destroyed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            Destroy(collision.gameObject);
            GetComponent<Animator>().Play("City_Explode");
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Destroy()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = destroyed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().DestroyedCity();
    }
}
