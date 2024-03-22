using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject card;
    public GameObject endTxt;
    public Text timeTxt;
    float checkTime = 0;
    public GameObject firstCard;
    public GameObject secondCard;

    private void Awake()
    {
        I = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1f,1f)).ToArray();
        for(int i = 0; i<16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;
            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f -3f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i];
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;
        timeTxt.text = checkTime.ToString("N2");

        if(checkTime>30)
        {
            Time.timeScale = 0;
            endTxt.SetActive(true);
        }
    }

    public void Match()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<card>().DestroyCardI();
            secondCard.GetComponent<card>().DestroyCardI();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.GetComponent<card>().CloseCardI();
            secondCard.GetComponent<card>().CloseCardI();
        }

        firstCard = null;
        secondCard = null;
    }
}
