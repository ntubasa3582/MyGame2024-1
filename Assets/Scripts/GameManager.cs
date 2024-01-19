using System;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    EnemyManager enemyManager;
    public float _enemyKillCount { get; private set; } = 0;       //エネミーを倒した時にカウントする変数
    public float _money { get; private set; } = 0;                //強化できる金
    public float _bossEmergenceValue { private get; set; } = 98;   //ボスが出現するまでをカウントする

    private void Awake()
    {
        uiManager = GameObject.FindAnyObjectByType<UIManager>();
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
    }

    private void Update()
    {
        //エネミーの倒した数が100の時にボスを出現させる
        if (_bossEmergenceValue >= 100)
        {
            _bossEmergenceValue = 0;
            enemyManager.BossInstance();
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
    }

    public void GetMoneyUp()
    {
        if (_money >= LevelUpValue.Instance._moneyNeeded[0])
        {
            //続き
        }
    }

    public void AttackSizeUp()
    {
        //金が必要量あったらエフェクトのサイズを大きくする
    }
}
