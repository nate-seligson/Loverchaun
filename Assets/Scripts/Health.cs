using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    public float health = 100;
    public AudioSource hitsound;
    float MaxHealth;
    public float moneyondeath = 0;
    public UnityEvent OnDamageTaken;
    // Update is called once per frame
    void Start()
    {
        MaxHealth = health;
    }
    void Update()
    {
        if(health <= 0)
        {
            if (TutorialFairy.index == 8 && TutorialFairy.waiting)
            {
                TutorialFairy.index++;
                TutorialFairy.waiting = false;
            }
            if (moneyondeath != 0)
            {
                Money.ChangeMoney(moneyondeath);
            }
            Destroy(gameObject);
        }
    }
    public void RemoveHealth(float damage)
    {
        if (hitsound)
        {
            hitsound.Play();
        }
        if (OnDamageTaken != null)
        {
            OnDamageTaken.Invoke();
        }
        health -= damage;
    }
    public void PotMoney()
    {
        Money.amount = (float)(Money.amount * (float)((float)health / (float)MaxHealth));
        if (health <= 0)
        {
            GameOver.gameOver = true;
        }
    }
    public void GetHit()
    {
        GetComponent<Animator>().SetTrigger("GetHit");
    }
}
