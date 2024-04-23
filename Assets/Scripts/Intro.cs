using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Intro : MonoBehaviour
{
    public Sprite[] sprites;
    int index= 0;
    public Image img;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            index++;
        }
        if (index >= sprites.Length)
        {
            SceneManager.LoadScene("Tutorial");
        }
        img.sprite = sprites[index];
    }
}
