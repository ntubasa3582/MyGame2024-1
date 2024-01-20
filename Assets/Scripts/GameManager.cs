using System;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    EnemyManager enemyManager;
    LevelUpValue levelUpValue;
    public float _enemyKillCount { get; private set; } = 0;       //�G�l�~�[��|�������ɃJ�E���g����ϐ�
    public float _money { get;private set; } = 0;                //�����ł����
    public float _bossEmergenceValue { private get; set; } = 98;   //�{�X���o������܂ł��J�E���g����

    private void Awake()
    {
        uiManager = GameObject.FindAnyObjectByType<UIManager>();
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        levelUpValue = gameObject.GetComponent<LevelUpValue>();
    }

    private void Update()
    {
        //�G�l�~�[�̓|��������100�̎��Ƀ{�X���o��������
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
        //�G�l�~�[��|�����珊�����𑝂₷   
        _money += 1;                                                         
        _bossEmergenceValue += 1;
        uiManager.AddMoneyText(_money);
        //�{�X�o���Q�[�W��\������X���C�_�[�ɒl��n��
        uiManager.AddSliderValue(_bossEmergenceValue);    

    }

    public void BossKillScoreCount()
    {
        //�{�X��|�����珊������100���₷
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
        //�����K�v�ʂ�������G�t�F�N�g�̃T�C�Y��傫������
    }
}
