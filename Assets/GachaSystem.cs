using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �K�`���̊m�����v�Z������J�[�h�̃f�[�^���i�[����N���X
/// </summary>
public class GachaSystem : MonoBehaviour
{
    [SerializeField, Tooltip("�e�J�[�h�̏��")]
    private List<Data> _cardData = new List<Data>();
    [SerializeField, Tooltip("�J�[�h��Prefab")]
    private Card _testCard;
    [SerializeField, Tooltip("�������J�[�h��u���ꏊ")]
    private GameObject _panel;

    public void Reset()
    {
        for(int i = 0; i < _panel.transform.childCount; i++)
        {
            Destroy(_panel.transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// �K�`�����s(1�A)
    /// </summary>
    public void ChooseStart()
    {
        int index = Choose(_cardData);
        Card card = Instantiate(_testCard, _panel.transform.position, Quaternion.identity);
        card.transform.SetParent(_panel.transform);
        card.CardSprite = _cardData[index].Card;
    }

    /// <summary>
    /// �K�`�����s(10�A)
    /// </summary>
    public void ChooseStart10()
    {
        for (int i = 0; i < 10; i++)
        {
            int index = Choose(_cardData);
            Card card = Instantiate(_testCard, _panel.transform.position, Quaternion.identity);
            card.transform.SetParent(_panel.transform);
            card.CardSprite = _cardData[index].Card;
        }
    }�@�@�@�@�@�@�@�@�@�@�@


    /// <summary></summary>
    public int Choose(List<Data> card)
    {
        //weight/total = �m��
        float total = 0f;
        foreach (var data in card)
        {
            total += data.Weight;
        }

        float random = UnityEngine.Random.value * total;

        for (int i = 0; i < card.Count; i++)
        {
            if (random < card[i].Weight)
            {
                return i;
            }
            else
            {
                random -= card[i].Weight;
            }
        }
        return card.Count - 1;
    }

}

[Serializable]
public class Data
{
    [SerializeField]
    private float _weight;
    public float Weight { get => _weight; set => _weight = value; }

    [SerializeField]
    private Sprite _cardImage;
    public Sprite Card { get => _cardImage; set => _cardImage = value; }
}
