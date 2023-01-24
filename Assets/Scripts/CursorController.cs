using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    public float speed;
    public float cooldown = 1;

    public GameObject missile;

    Vector3 newPos;
    Vector2 missileSpawn = new Vector2(0, -4.3f);

    // Update is called once per frame
    void Update()
    {
        newPos = transform.position;
        newPos.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        newPos.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        transform.position = newPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var m = Instantiate(missile, missileSpawn, Quaternion.identity);
            var mc = m.GetComponent<MissileController>();
            mc.target = transform.position;
            mc.Init();
            m.SetActive(true);
        }
    }
}
