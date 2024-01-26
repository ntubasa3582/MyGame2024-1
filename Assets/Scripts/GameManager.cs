using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    /// <summary>�Q�[�����|�[�Y���郁�\�b�h</summary>
    public event Action<bool> GamePause;
    bool _pauseFlag = false;    //�Q�[���̃|�[�Y�ɕK�v�ȃt���O
    UIManager uiManager;
    EnemyManager enemyManager;
    LevelUpValue levelUpValue;
    RandomNumSystem randomNum;
    [SerializeField] List<GameObject> _ddolObjects;
    public float _money { get;private set; } = 100;                 //�����ł����
    public float _bossEmergenceValue { private get; set; } = 0;     //�{�X���o������܂ł��J�E���g����
    float _bossDeathRewardValue = 0;                                //�{�X��|�������̕�V������ϐ�

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Escape�������ꂽ��Q�[�����X�g�b�v����@������x�����ƍĊJ����
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
