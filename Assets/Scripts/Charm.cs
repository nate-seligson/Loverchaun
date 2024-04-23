using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{
    public GameObject moverbit;
    Vector3 extents;
    public float charmSpeed = 1;
    public bool stopped = false;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        extents = new Vector2(GetComponent<Collider2D>().bounds.extents.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        t = Mathf.PingPong(Time.time * charmSpeed, 1);
        if (!stopped)
        {
            moverbit.transform.position = Vector3.Lerp(transform.position - extents, transform.position + extents, t);
        }
    }
    public int CalculateCharm()
    {
        stopped = true;
        return (int)(Mathf.Lerp(50, -10, (float)(Mathf.Abs(t-0.5f) * 2)));
    }
}
