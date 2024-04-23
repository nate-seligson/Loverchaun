using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject overScreen;
    public static bool gameOver = false;
    bool playing = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        overScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && !playing)
        {
            overScreen.SetActive(true);
            AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource aud in audios)
            {
                aud.volume = 0;
            }
            overScreen.GetComponent<AudioSource>().volume = 1;
            overScreen.GetComponent<AudioSource>().Play();
            playing = true;
        }
        else if (!gameOver)
        {
            overScreen.SetActive(false);
        }
    }
    public void Restart()
    {
        Store.instore = false;
        Money.amount = 0;
        Woman.charming = false;
        Controller.InRange = null;
        Controller.heldObject = null;
        Controller.stopped = false;
        StartCoroutine("restartscene");
    }
    IEnumerator restartscene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
