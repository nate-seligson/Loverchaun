using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocks : MonoBehaviour
{
    public static Dictionary<string, bool> unlocks = new Dictionary<string, bool>();
    void Start()
    {
        unlocks = new Dictionary<string, bool>()
        {
            {"Rock", true},
            {"Plant", false},
            {"Rose", false}
        };
    }
}
