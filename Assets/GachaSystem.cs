using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ガチャの確率を計算したりカードのデータを格納するクラス
/// </summary>
public class GachaSystem : MonoBehaviour
{
    [SerializeField, Tooltip("各カードの情報")]
    private List<Data> _cardData = new List<Data>();
    [SerializeField, Tooltip("カードのPrefab")]
    private Card _testCard;
    [SerializeField, Tooltip("引いたカードを置く場所")]
    private GameObject _panel;

    public void Reset()
    {
        for(int i = 0; i < _panel.transform.childCount; i++)
        {
            Destroy(_panel.transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// ガチャ実行(1連)
    /// </summary>
    public void ChooseStart()
    {
        int index = Choose(_cardData);
        Card card = Instantiate(_testCard, _panel.transform.position, Quaternion.identity);
        card.transform.SetParent(_panel.transform);
        card.CardSprite = _cardData[index].Card;
    }

    /// <summary>
    /// ガチャ実行(10連)
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
    }　　　　　　　　　　　


    /// <summary></summary>
    public int Choose(List<Data> card)
    {
        //weight/total = 確率
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
