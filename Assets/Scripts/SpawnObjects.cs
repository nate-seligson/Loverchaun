using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] spawnables;
    public int spawnamt;
    public static Bounds bounds;
    // Start is called befor the first frame update
    void Start()
    {
        bounds = GetComponent<Collider2D>().bounds;
        for (var i = 0; i<spawnamt; i++)
        {
            GameObject obj = Instantiate(spawnables[Random.Range(0, spawnables.Length)]);
            obj.transform.position = GetPos(obj);
        }
    }
    public Vector2 GetPos(GameObject obj, float reach = 15)
    {
        Vector2 pos = new Vector2(Random.Range(bounds.max.x, reach), bounds.max.y + obj.GetComponent<Collider2D>().bounds.extents.y);
        if(Random.value > 0.5)
        {
            pos = new Vector2(-pos.x, pos.y);
        }
        return pos;
    }
    public static void PutDown(GameObject obj)
    {
        obj.transform.position = new Vector2(obj.transform.position.x, bounds.max.y + obj.GetComponent<Collider2D>().bounds.extents.y);
    }
}
