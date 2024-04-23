using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "TransformData")]
public class TransformData : ScriptableObject
{
    public string UnlockName;
    public string ScriptName;
    public float range,timeBetweenShots, damage, health;
    public GameObject bullet;
    public GameObject head;
}
