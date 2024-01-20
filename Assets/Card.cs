using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    string _cardImage;

    private Sprite _card;
    public Sprite CardSprite
    {
        get => _card;
        set
        {
            _card = value;
            //_cardImage.sprite = _card;
        }
    }
}
