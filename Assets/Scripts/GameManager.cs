using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class GameManager : MonoBehaviour
{
    const int TIME = 30;
    public Transform cards;
    public Card card;
    public GameObject endTxt;
    public Text timeTxt;
    
    int checkTime;

    Card firstCard, secondCard;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InvokeCoTime());
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1f,1f)).ToArray();

        for (int i = 0; i<16; i++)
        {
            int index = rtans[i];
            Card newCard = Instantiate(card);

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3f;
            string rtanName = "rtan" + index;
            Sprite sprite = Resources.Load<Sprite>(rtanName);

            newCard.SetFrontSprite(sprite)
                   .SetParent(cards)
                   .SetPosition(new Vector3(x, y, 0))
                   .SetIndex(index)
                   .SetActionOnClick(OnClickCard);
        }
    }

    void OnClickCard(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
            Match();
        }
    }

    IEnumerator InvokeCoTime()
    {
        yield return new WaitForSeconds(1f);
        checkTime++;
        timeTxt.text = checkTime.ToString();
        if (checkTime <= TIME)
        {
            StartCoroutine(InvokeCoTime());
        }
        else
        {
            Time.timeScale = 0;
            endTxt.SetActive(true);
        }
    }

    public void Match()
    {
        int index1 = firstCard.index;
        int index2 = secondCard.index;

        if (index1 == index2)
        {
            firstCard.DestroyCardI();
            secondCard.DestroyCardI();

            int cardsLeft = cards.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.CloseCardI();
            secondCard.CloseCardI();
        }

        firstCard = null;
        secondCard = null;
    }
}
