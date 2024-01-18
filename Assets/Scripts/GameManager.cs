using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _MoneyText;
    Slider _enemyScoreSlider;
    public static GameManager instance;
    int _enemyKillScore = 0;                                               //エネミーが倒されたらスコアを増やす
    [SerializeField,Header("倒した時に追加で貰える金")] int[] _placeMoney; //レベルごとに貰える金の量が変わる
    [SerializeField, Header("強化に必要な金")] int[] _levelUpMoney;        //強化に必要な金
    int _getMoneyValue = 0;                                                //貰える金の値を入れておく変数
    int _addCount = -1;                                                     //_placeMoneyのカウント用変数
    int _bossEmergenceValue = 0;

    private void Awake()
    {
        _enemyScoreSlider = GameObject.FindAnyObjectByType<Slider>();
        _enemyScoreSlider.value = 0;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_bossEmergenceValue <= 100)
        {

        }
    }

    public void AddScoreCount()
    {

        _enemyKillScore += 1 + _getMoneyValue;
        _enemyScoreSlider.value += 1 + _getMoneyValue;
        _MoneyText.text = _enemyKillScore.ToString("0000");
    }

    public void GetMoneyUp()
    {
        //金が必要量あったら強化する
        if (_levelUpMoney[_addCount + 1] <= _enemyKillScore)
        {
            _addCount += 1;
            _getMoneyValue = _placeMoney[_addCount];
            _enemyKillScore -= _levelUpMoney[_addCount];
            Debug.Log(_enemyKillScore);
            _MoneyText.text = _enemyKillScore.ToString("0000");
        }

    }


}
