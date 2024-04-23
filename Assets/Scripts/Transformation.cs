using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    public TransformData data;
    public bool transformed = false;
    public AudioSource hitsound;
  
    // Update is called once per frame
    void Update()
    {
        if (Unlocks.unlocks[data.UnlockName])
        {
            GetComponent<Popup>().text = "[Click] Pickup \n [E] Charm";
        }
        else
        {
            GetComponent<Popup>().text = "[Click] Pickup";
        }
        if(Input.GetKeyDown(KeyCode.E) && Controller.InRange == gameObject && !transformed)
        {
            if (Unlocks.unlocks[data.UnlockName])
            {
                Transform();
                GetComponent<AudioSource>().Play();
                transformed = true;
            }
            else {
                Debug.Log("not unlocked");
            }
        }
    }
    void Transform()
    {
        gameObject.AddComponent(System.Type.GetType(data.ScriptName));
        Health();
        GetComponent<Collider2D>().isTrigger = false;
        Destroy(GetComponent<Pickupable>());
        gameObject.layer = LayerMask.NameToLayer("Default");
        GetComponent<Animator>().SetTrigger("transform");

    }
    void Health()
    {
        gameObject.AddComponent<Health>();
        GetComponent<Health>().health = data.health;
        GetComponent<Health>().hitsound = hitsound; 
    }
}
