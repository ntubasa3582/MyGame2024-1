using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _MoneyText;
    Slider _enemyScoreSlider;
    public static GameManager instance;
    int _enemyKillScore = 0;                                               //�G�l�~�[���|���ꂽ��X�R�A�𑝂₷
    [SerializeField,Header("�|�������ɒǉ��ŖႦ���")] int[] _placeMoney; //���x�����ƂɖႦ����̗ʂ��ς��
    [SerializeField, Header("�����ɕK�v�ȋ�")] int[] _levelUpMoney;        //�����ɕK�v�ȋ�
    int _getMoneyValue = 0;                                                //�Ⴆ����̒l�����Ă����ϐ�
    int _addCount = -1;                                                     //_placeMoney�̃J�E���g�p�ϐ�
    int _bossEmergenceValue = 0;

    private void Awake()
    {
        _enemyScoreSlider = GameObject.FindAnyObjectByType<Slider>();
        _enemyScoreSlider.value = 0;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_bossEmergenceValue <= 100)
        {

        }
    }

    public void AddScoreCount()
    {

        _enemyKillScore += 1 + _getMoneyValue;
        _enemyScoreSlider.value += 1 + _getMoneyValue;
        _MoneyText.text = _enemyKillScore.ToString("0000");
    }

    public void GetMoneyUp()
    {
        //�����K�v�ʂ������狭������
        if (_levelUpMoney[_addCount + 1] <= _enemyKillScore)
        {
            _addCount += 1;
            _getMoneyValue = _placeMoney[_addCount];
            _enemyKillScore -= _levelUpMoney[_addCount];
            Debug.Log(_enemyKillScore);
            _MoneyText.text = _enemyKillScore.ToString("0000");
        }

    }


}
