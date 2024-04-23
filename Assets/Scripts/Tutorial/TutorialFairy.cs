using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class TutorialFairy : MonoBehaviour
{
    public static int index = 0;
    string text;
    public static bool waiting = false;
    public GameObject enemy;
    public GameObject rock;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Down);
    }
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = text;
        if (!waiting)
        {
            GetComponent<TextMeshProUGUI>().text = text + "\n [Click] to continue.";
        }
        switch (index)
        {
            case 0:
                text = "Hey man! it's me! The tutorial fairy! Haven't seen you in a while!";
                break;
            case 1:
                text = "Woah mama! Looks like you got a hot date!";
                break;
            case 2:
                text = "Looks like she's getting disinterested! Go up to her and charm her!";
                waiting = true;
                break;
            case 3:
                text = "Nice, man. Make sure to keep her interested. If you save up enough, you can buy a ring and marry her!";
                break;
            case 4:
                text = "The longer you wait to charm her, the harder it'll be. Give her roses to keep her interest for longer!";
                break;
            case 5:
                text = "Uhoh. Looks like some kids are coming to steal your charms.";
                break;
            case 6:
                text = "See that rock over on the right?";
                rock.SetActive(true);
                break;
            case 7:
                text = "Cast a charm on that rock to turn it into a turret.";
                waiting = true;
                break;
            case 8:
                text = "Here it comes!";
                enemy.SetActive(true);
                waiting = true;
                break;
            case 9:
                text = "Good work. Make sure not to let those kids steal your charms!";
                break;
            case 10:
                text = "Welp, I'm off. Good luck on your date!";
                break;
            case 11:
                SceneManager.LoadScene("SampleScene");
                break;
        }

    }
    void Down()
    {
        if (!waiting)
        {
            index++;
        }
    }
}
