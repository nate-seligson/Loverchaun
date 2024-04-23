using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    GameObject collided;
    public float speed = 1;
    public float damage = 10f;
    float timeBetweenAttacks = 1;
    bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Potogold");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(target.transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(collided != null && !attacking)
        {
            StartCoroutine("attack");
            attacking = true;
        }
        else if (collided == null)
        {
            StopCoroutine("attack");
            attacking = false;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.gameObject.GetComponent<Health>() && col.transform.gameObject.tag != "Enemy")
        {
            collided = col.transform.gameObject;
        }
    }
    IEnumerator attack()
    {
        collided.GetComponent<Health>().RemoveHealth(damage);
        GetComponent<Animator>().SetTrigger("attack");
        yield return new WaitForSeconds(timeBetweenAttacks);
        StartCoroutine("attack");
    }
}
