using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] GameObject front, back;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator ani;
    public int index { get; private set; }

    public Card SetParent(Transform parent)
    {
        transform.parent = parent;
        return this;
    }

    public Card SetIndex(int index)
    {
        this.index = index;
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
        back.SetActive(false);
        front.SetActive(true);
        ani.SetBool("isClick", true);

        if(GameManager.I.firstCard == null)
        {
            GameManager.I.firstCard = this;
        }
        else
        {
            GameManager.I.secondCard = this;
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
        front.SetActive(false);
        back.SetActive(true);
        ani.SetBool("isClick", false);
    }

    
}
