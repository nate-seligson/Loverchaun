using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Quip : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    public void Quipped(int goodness, int max)
    {
        if(goodness >= max)
        {
            Text.text = "Oh! You Gentleman!";
        }
        else if (goodness >= 20)
        {
            Text.text = "Oh wow!";
        }
        else if(goodness > 0)
        {
            Text.text = "Uh... Ok...";
        }
        else if (goodness < 0)
        {
            Text.text = "Ew, Creep!";
        }
        else
        {
            Text.text = "";
        }
    }
}
