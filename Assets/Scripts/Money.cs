using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    public static float amount = 2000;
    public static GameObject instance;
    // Start is called before the first frame update
    public static void ChangeMoney(float diff)
    {
        amount += diff;
    }
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = amount.ToString("0.00");
    }
    // Update is called once per frame
}
