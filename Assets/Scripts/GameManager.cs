using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    EnemyManager enemyManager;
    LevelUpValue levelUpValue;
    RandomNumSystem randomNum;
    public float _enemyKillCount { get; private set; } = 0;       //エネミーを倒した時にカウントする変数
    public float _money { get;private set; } = 100;                //強化できる金
    public float _bossEmergenceValue { private get; set; } = 0;   //ボスが出現するまでをカウントする
    float _bossDeathRewardValue = 0;

    private void Awake()
    {
        uiManager = GameObject.FindAnyObjectByType<UIManager>();
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        levelUpValue = GameObject.FindAnyObjectByType<LevelUpValue>();
        randomNum = GameObject.FindAnyObjectByType<RandomNumSystem>();
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
        _money = _money;
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
