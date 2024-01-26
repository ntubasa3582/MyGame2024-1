using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    /// <summary>ゲームをポーズするメソッド</summary>
    public event Action<bool> GamePause;
    bool _pauseFlag = false;    //ゲームのポーズに必要なフラグ
    UIManager uiManager;
    EnemyManager enemyManager;
    LevelUpValue levelUpValue;
    RandomNumSystem randomNum;
    [SerializeField] List<GameObject> _ddolObjects;
    public float _money { get;private set; } = 100;                 //強化できる金
    public float _bossEmergenceValue { private get; set; } = 0;     //ボスが出現するまでをカウントする
    float _bossDeathRewardValue = 0;                                //ボスを倒した時の報酬を入れる変数

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        uiManager = GameObject.FindAnyObjectByType<UIManager>();
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        levelUpValue = GameObject.FindAnyObjectByType<LevelUpValue>();
        randomNum = GameObject.FindAnyObjectByType<RandomNumSystem>();
        for (int i = 0;i < _ddolObjects.Count; i++)
        {
            DontDestroyOnLoad(_ddolObjects[i]);
        }
        _ddolObjects[1].SetActive(false);
    }

    private void Update()
    {
        //エネミーの倒した数が100の時にボスを出現させる
        if (_bossEmergenceValue >= 100)
        {
            for (int i = 0; i < 3; i++)
            {
                BossDeathReward();
            }
            _bossEmergenceValue = 0;
            enemyManager.BossInstance();
            Debug.Log("ボスを倒したら報酬" + _bossDeathRewardValue + "倍");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Escapeが押されたらゲームをストップする　もう一度押すと再開する
            _pauseFlag = !_pauseFlag;
            //GamePause(_pauseFlag);
            if (_pauseFlag)
            {
                _ddolObjects[1].SetActive(_pauseFlag);
            }
            else
            {
                _ddolObjects[1].SetActive(_pauseFlag);
            }

        }
    }

    public void AddEnemyKillCount()
    {
        //エネミーを倒したら所持金を増やす   
        _money += 1+ levelUpValue._valueStorage[1];                                                         
        _bossEmergenceValue += 1;
        uiManager.AddMoneyText(_money);
        //ボス出現ゲージを表示するスライダーに値を渡す
        uiManager.AddSliderValue(_bossEmergenceValue);   
    }

    public void BossKillScoreCount()
    {
        //ボスを倒したら所持金を100増やす
        _money += 100 * _bossDeathRewardValue;
        _bossEmergenceValue = 0;
        uiManager.AddSliderValue(_bossEmergenceValue);
        uiManager.AddMoneyText (_money);
    }

    public void ChangeMoneyValue(float value)
    {
        //金の値を変える
        _money += value;
        uiManager.AddMoneyText(_money);
    }

    public void BossDeathReward()
    {
        //ボス撃破時に増える報酬を決めるメソッド
        _bossEmergenceValue += 1;
        randomNum.ChooseStart();
        switch (randomNum.ChooseStart())
        {

            case 0:
                _bossDeathRewardValue += 10;
                return;
            case 1:
                _bossDeathRewardValue += 5;
                return;
            case 2:
                _bossDeathRewardValue += 2.5f;
                return;
            case 3:
                _bossDeathRewardValue += 1.5f;
                return;
        }
    }
}
