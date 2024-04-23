using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] spawnforwave;
    bool spawning;
    int wave = 0;
    int startenemies = 5;
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !spawning)
        {
            wave += 1;
            StartCoroutine("Spawn", startenemies + (2 * wave));
            for (var i = 0; i < 3; i++)
            {
                GameObject obj = Instantiate(spawnforwave[Random.Range(0, spawnforwave.Length)], transform.position, transform.rotation);
                obj.transform.position = GetComponent<SpawnObjects>().GetPos(obj);
            }
            spawning = true;
        }
    }
    IEnumerator Spawn(int amt)
    {
        yield return new WaitForSeconds(10);
        SpawnEnemies(amt);
    }
    void SpawnEnemies(int amt)
    {
        for(var i = 0; i<amt; i++)
        {
            StartCoroutine("waitalil");
        }
    }
    IEnumerator waitalil()
    {
        yield return new WaitForSeconds(Random.Range(0f,5f));
        GameObject enem = Instantiate(enemy);
        enem.GetComponent<Enemy>().speed = (float)((float)wave / 3f);
        enem.transform.position = GetComponent<SpawnObjects>().GetPos(enem, 30);
        spawning = false;
    }

}
