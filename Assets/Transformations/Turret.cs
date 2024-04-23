using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    TransformData data;
    GameObject closestenemy;
    GameObject head;
    GameObject realhead;
    bool shooting = false;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            data = GetComponent<Transformation>().data;
        }
        catch
        {
            data = GetComponent<TransformationTut>().data;
        }
        head = data.head;
        StartCoroutine("AddHead");
    }
    void Update()
    {
        if(closestenemy != null)
        {
            try
            {
                realhead.transform.right = closestenemy.transform.position - realhead.transform.position;
            }
            catch { }
            if (!shooting)
            {
                StartCoroutine("shoot");
                shooting = true;
            }
        }
        else if(closestenemy == null)
        {
            StopCoroutine("shoot");
            shooting = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        closestenemy = FindClosestEnemy();
    }
    GameObject FindClosestEnemy()
    {
        float bestDistance = data.range;
        GameObject bestObject = null;
        foreach (Collider2D enemy in Physics2D.OverlapCircleAll(transform.position, data.range))
        {
            if (enemy.gameObject.tag == "Enemy" && Vector2.Distance(transform.position, enemy.transform.position) < bestDistance)
            {
                bestDistance = Vector2.Distance(transform.position, enemy.transform.position);
                bestObject = enemy.gameObject;
            }
        }
        return bestObject;
    }
    IEnumerator shoot()
    {
        FireBullet();
        yield return new WaitForSeconds(data.timeBetweenShots);
        StartCoroutine("shoot");
    }
    void FireBullet()
    {
        GameObject bullet = Instantiate(data.bullet, transform.position + head.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = data.damage;
        bullet.transform.up = (closestenemy.transform.position - (transform.position + head.transform.position));
    }
    IEnumerator AddHead()
    {
        yield return new WaitForSeconds(0.5f);
        realhead = Instantiate(head, transform.position + head.transform.position, transform.rotation);
        realhead.transform.parent = transform;
    }
}
