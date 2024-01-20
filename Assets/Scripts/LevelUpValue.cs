using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpValue : MonoBehaviour
{
    GameManager gameManager;
    public static LevelUpValue Instance;
    [SerializeField,Header("")] float[] _moneyNeeded;                           //0+���x���A�b�v�ɕK�v�ȋ�
    [SerializeField, Header("�ς�")] float[] _getMoneyPlace;                    //1+�|�������ɒǉ��ŖႦ���
    [SerializeField, Header("�܂�")] float[] _enemyInstanceSpeedPlace;          //2+�G�l�~�[�������̃C���^�[�o����Z������
    [SerializeField, Header("�Ȃ�")] float[] _enemyHpPlace;                     //3+�G�l�~�[��HP�𑝂₷
    [SerializeField, Header("�܂�")] float[] _effectInstancePlace;              //4+�U���G�t�F�N�g�̐��𑝂₷
    [SerializeField, Header("�܂�")] float[] _effectSizePlace;                  //5+�U���G�t�F�N�g�̃T�C�Y��傫������
    [SerializeField, Header("�Ȃ�")] float[] _playerDamagePlace;                //6:�v���C���[���G�l�~�[�ɗ^����_���[�W���グ��
    float[] _valueStorage = new float[7];                       //��̔z��̊e�v�f�����Ă����ϐ�
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
            Debug.Log(_valueCount[1] + "�A�b�v");
        }
    }

}
