using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator ani;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Card SetParent(Transform parent)
    {
        transform.parent = parent;
        return this;
    }

    public Card SetPosition(Vector3 position)
    {
        transform.position = position;
        return this;
    }

    // builder pattern
    public Card SetFrontSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        return this;
    }

    public void Click()
    {
        transform.Find("back").gameObject.SetActive(false);
        transform.Find("front").gameObject.SetActive(true);
        ani.SetBool("isClick", true);

        if(GameManager.I.firstCard == null)
        {
            GameManager.I.firstCard = gameObject;
        }
        else
        {
            GameManager.I.secondCard = gameObject;
            GameManager.I.Match();
        }

        
    }
    public void DestroyCardI()
    {
        Invoke("DestroyCard", 1f);
    }

    void DestroyCard()
    {
        Destroy(gameObject);
    }

    public void CloseCardI()
    {
        Invoke("CloseCard", 1f);
    }

    void CloseCard()
    {
        transform.Find("front").gameObject.SetActive(false);
        transform.Find("back").gameObject.SetActive(true);
        ani.SetBool("isClick", false);
    }

    
}
