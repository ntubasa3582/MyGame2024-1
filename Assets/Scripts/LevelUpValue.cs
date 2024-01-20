using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpValue : MonoBehaviour
{
    GameManager gameManager;
    public static LevelUpValue Instance;
    [SerializeField,Header("")] float[] _moneyNeeded;                           //0+レベルアップに必要な金
    [SerializeField, Header("済み")] float[] _getMoneyPlace;                    //1+倒した時に追加で貰える金
    [SerializeField, Header("まだ")] float[] _enemyInstanceSpeedPlace;          //2+エネミー生成時のインターバルを短くする
    [SerializeField, Header("なし")] float[] _enemyHpPlace;                     //3+エネミーのHPを増やす
    [SerializeField, Header("まだ")] float[] _effectInstancePlace;              //4+攻撃エフェクトの数を増やす
    [SerializeField, Header("まだ")] float[] _effectSizePlace;                  //5+攻撃エフェクトのサイズを大きくする
    [SerializeField, Header("なし")] float[] _playerDamagePlace;                //6:プレイヤーがエネミーに与えるダメージを上げる
    float[] _valueStorage = new float[7];                       //上の配列の各要素を入れておく変数
    public int[] _valueCount { get; private set; } = new int[7];

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    public void LevelUpMoney()
    {
        if (gameManager._money >= _moneyNeeded[_valueCount[1]])
        {
            gameManager.ChangeMoneyValue(- _moneyNeeded[_valueCount[1]]);
            _valueStorage[1] = Array.IndexOf(_getMoneyPlace, _valueCount[1]);
            _valueCount[1] += 1;
            Debug.Log(_valueCount[1] + "アップ");
        }
    }

}
