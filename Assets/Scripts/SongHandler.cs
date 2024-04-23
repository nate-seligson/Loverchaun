using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongHandler : MonoBehaviour
{
    public AudioSource shop, main;
    bool switched = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (GameOver.gameOver)
        {
            main.Stop();
            shop.Stop();
        }
        if (Store.instore && !switched)
        {
            main.Stop();
            shop.Play();
            switched = true;
        }
        else if (!Store.instore && switched)
        {
            main.Play();
            shop.Stop();
            switched = false;
        }
    }
}
