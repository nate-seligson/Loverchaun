using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 20;
    public float damage;
    void Start()
    {
        Destroy(gameObject, 20);
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.gameObject.tag == "Enemy")
        {
            Hit(col.transform.gameObject);
        }
    }
    void Hit(GameObject enemy)
    {
        try
        {
            enemy.GetComponent<Health>().RemoveHealth(damage);
        }
        catch
        {
            enemy.GetComponent<HealthTut>().RemoveHealth(damage);
        }
        Destroy(gameObject);
    }
}
