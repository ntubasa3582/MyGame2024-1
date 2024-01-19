using System;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    EnemyManager enemyManager;
    public float _enemyKillCount { get; private set; } = 0;       //�G�l�~�[��|�������ɃJ�E���g����ϐ�
    public float _money { get; private set; } = 0;                //�����ł����
    public float _bossEmergenceValue { private get; set; } = 98;   //�{�X���o������܂ł��J�E���g����

    private void Awake()
    {
        uiManager = GameObject.FindAnyObjectByType<UIManager>();
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
    }

    private void Update()
    {
        //�G�l�~�[�̓|��������100�̎��Ƀ{�X���o��������
        if (_bossEmergenceValue >= 100)
        {
            _bossEmergenceValue = 0;
            enemyManager.BossInstance();
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
    }

    public void GetMoneyUp()
    {
        if (_money >= LevelUpValue.Instance._moneyNeeded[0])
        {
            //����
        }
    }

    public void AttackSizeUp()
    {
        //�����K�v�ʂ�������G�t�F�N�g�̃T�C�Y��傫������
    }
}
