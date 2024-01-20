using System;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    EnemyManager enemyManager;
    LevelUpValue levelUpValue;
    public float _enemyKillCount { get; private set; } = 0;       //エネミーを倒した時にカウントする変数
    public float _money { get;private set; } = 0;                //強化できる金
    public float _bossEmergenceValue { private get; set; } = 98;   //ボスが出現するまでをカウントする

    private void Awake()
    {
        uiManager = GameObject.FindAnyObjectByType<UIManager>();
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        levelUpValue = gameObject.GetComponent<LevelUpValue>();
    }

    private void Update()
    {
        //エネミーの倒した数が100の時にボスを出現させる
        if (_bossEmergenceValue >= 100)
        {
            _bossEmergenceValue = 0;
            enemyManager.BossInstance();
        }
        if (_bossEmergenceValue == 25)
        {

        }
    }

    public void AddEnemyKillCount()
    {
        //エネミーを倒したら所持金を増やす   
        _money += 1;                                                         
        _bossEmergenceValue += 1;
        uiManager.AddMoneyText(_money);
        //ボス出現ゲージを表示するスライダーに値を渡す
        uiManager.AddSliderValue(_bossEmergenceValue);    

    }

    public void BossKillScoreCount()
    {
        //ボスを倒したら所持金を100増やす
        _money += 100;
        _bossEmergenceValue = 0;
        uiManager.AddSliderValue(_bossEmergenceValue);
        uiManager.AddMoneyText (_money);
    }

    public void ChangeMoneyValue(float value)
    {
        _money += value;
        uiManager.AddMoneyText(_money);
    }

    public void AttackSizeUp()
    {
        //金が必要量あったらエフェクトのサイズを大きくする
    }
}
