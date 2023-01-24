using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
    public float cooldown = 1.5f;
    public float maxCooldown = 1.5f;

    public float minX;
    public float maxX;

    public List<Transform> cities;

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            cooldown = maxCooldown;
            maxCooldown -= 0.0025f;
            var m = Instantiate(meteor, new Vector2(Random.Range(minX, maxX), 5.5f), Quaternion.identity);
            var mc = m.GetComponent<MeteorController>();
            mc.target = cities[Random.Range(0,6)].position;
            mc.Init();
            m.SetActive(true);
        }
    }
}