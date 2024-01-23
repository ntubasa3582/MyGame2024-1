using System.Collections.Generic;
using UnityEngine;

public class LevelUpValue : MonoBehaviour
{

    GameManager gameManager;
    EnemyManager enemyManager;
    [SerializeField] List<Value> _value = new List<Value>();
    public static LevelUpValue Instance;
    public float[] _valueStorage { get; private set; } = new float[7];          //��̔z��̊e�v�f�����Ă����ϐ�
    public int[] _levelCount { get; private set; } = new int[7];

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
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
    }

    public void LevelUpMoney()
    {
        //�G�l�~�[���j���ɖႦ����̗ʂ�������
        if (gameManager._money > _value[_levelCount[1]]._moneyNeeded)
        {
            _valueStorage[1] = _value[_levelCount[1]]._getMoneyPlace;
            gameManager.ChangeMoneyValue( -_value[_levelCount[1]]._moneyNeeded);
            _levelCount[1] += 1;
            Debug.Log("�G��|������" + _valueStorage[1] + "�{�ɂȂ�");
        }
    }

    public void EnemyInstanceSpeed()
    {
        //�G�l�~�[�̐������Ԃ��Z�k�����
        if (gameManager._money > _value[_levelCount[2]]._moneyNeeded)
        {
            _valueStorage[2] = _value[_levelCount[2]]._enemyInstanceSpeedUp;
            gameManager.ChangeMoneyValue(-_value[_levelCount[2]]._moneyNeeded);
            _levelCount[2] += 1;
            Debug.Log("�G��|������" + _valueStorage[2] + "�{�ɂȂ�");
        }
    }

    public void EffectSizeUp()
    {
        //�A�^�b�N�G�t�F�N�g�̃T�C�Y���傫���Ȃ�
        if (gameManager._money > _value[_levelCount[4]]._moneyNeeded)
        {
            _valueStorage[4] = _value[_levelCount[4]]._effectSizePlace;
            gameManager.ChangeMoneyValue(-_value[_levelCount[4]]._moneyNeeded);
            _levelCount[4] += 1;
            Debug.Log("�G��|������" + _valueStorage[4] + "�{�ɂȂ�");
        }
    }

}
