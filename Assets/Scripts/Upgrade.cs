using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class Upgrade : MonoBehaviour
{
    public TextMeshProUGUI nameGO, descriptionGO, priceGO, buyGO;
    public Image spriteGO;
    public Button buttonGO;
    public string name, description;
    public float price;
    public Sprite sprite;
    public UnityEvent onclick;
    public GameObject Rock;
    public GameObject Plant;
    public GameObject Rose;
    // Start is called before the first frame update
    void Start()
    {
        buttonGO.onClick.AddListener(clicked);
        nameGO.text = name;
        descriptionGO.text = description;
        priceGO.text = price.ToString();
        spriteGO.sprite = sprite;
    }
    void clicked()
    {
        GetComponent<AudioSource>().Play();
        if(Money.amount >= price)
        {
            onclick.Invoke();
            Money.ChangeMoney(-price);
        }
        else
        {
            StartCoroutine("insufficient");
        }
    }
    IEnumerator insufficient()
    {
        buyGO.text = "INSUFFICIENT FUNDS";
        yield return new WaitForSeconds(1);
        buyGO.text = "BUY";
        StopCoroutine("insufficient");
    }
    public void SpawnRock()
    {
        Spawn(Rock);
    }
    public void SpawnPlant()
    {
        Spawn(Plant);
    }
    public void SpawnRose()
    {
        Spawn(Rose);
    }
    public void EnablePlant()
    {
        Enable("Plant");
    }
    public void EnableRose()
    {
        Enable("Rose");
    }
    public void Enable(string name)
    {
        Unlocks.unlocks[name] = true;
    }
    void Spawn(GameObject tospawn)
    {
        GameObject obj = Instantiate(tospawn, GameObject.FindWithTag("Player").transform.position, transform.rotation);
        SpawnObjects.PutDown(obj);

    }
    public void Win() {
        SceneManager.LoadScene("Win");
    }
}
