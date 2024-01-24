using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    EnemyManager enemyManager;
    LevelUpValue levelUpValue;
    RandomNumSystem randomNum;
    public float _enemyKillCount { get; private set; } = 0;       //�G�l�~�[��|�������ɃJ�E���g����ϐ�
    public float _money { get;private set; } = 100;                //�����ł����
    public float _bossEmergenceValue { private get; set; } = 0;   //�{�X���o������܂ł��J�E���g����
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
        //�G�l�~�[�̓|��������100�̎��Ƀ{�X���o��������
        if (_bossEmergenceValue >= 100)
        {
            for (int i = 0; i < 3; i++)
            {
                BossDeathReward();
            }
            _bossEmergenceValue = 0;
            enemyManager.BossInstance();
            Debug.Log("�{�X��|�������V" + _bossDeathRewardValue + "�{");
        }
        _money = _money;
    }

    public void AddEnemyKillCount()
    {
        //�G�l�~�[��|�����珊�����𑝂₷   
        _money += 1+ levelUpValue._valueStorage[1];                                                         
        _bossEmergenceValue += 1;
        uiManager.AddMoneyText(_money);
        //�{�X�o���Q�[�W��\������X���C�_�[�ɒl��n��
        uiManager.AddSliderValue(_bossEmergenceValue);    
    }

    public void BossKillScoreCount()
    {
        //�{�X��|�����珊������100���₷
        _money += 100 * _bossDeathRewardValue;
        _bossEmergenceValue = 0;
        uiManager.AddSliderValue(_bossEmergenceValue);
        uiManager.AddMoneyText (_money);
    }

    public void ChangeMoneyValue(float value)
    {
        //���̒l��ς���
        _money += value;
        uiManager.AddMoneyText(_money);
    }

    public void BossDeathReward()
    {
        //�{�X���j���ɑ������V�����߂郁�\�b�h
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
