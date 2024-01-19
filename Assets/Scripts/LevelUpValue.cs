using UnityEngine;

public class LevelUpValue : MonoBehaviour
{
    public static LevelUpValue Instance;
    [SerializeField] public float[] _moneyNeeded;               //0+���x���A�b�v�ɕK�v�ȋ�
    [SerializeField] public float[] _GetMoneyPlace;             //1+�|�������ɒǉ��ŖႦ���
    [SerializeField] public float[] _enemyInstanceSpeedPlace;   //2+�G�l�~�[�������̃C���^�[�o����Z������
    [SerializeField] public float[] _enemyHpPlace;              //3+�G�l�~�[��HP�𑝂₷
    [SerializeField] public float[] _effectInstancePlace;       //4+�U���G�t�F�N�g�̐��𑝂₷
    [SerializeField] public float[] _effectSizePlace;           //5+�U���G�t�F�N�g�̃T�C�Y��傫������
    [SerializeField] public float[] _playerDamagePlace;         //6:�v���C���[���G�l�~�[�ɗ^����_���[�W���グ��
    [SerializeField]float[,] _valueStorage = new float[7, 2];
    int _storageNum = 0;


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
    }

    void Update()
    {

    }
    /// <param name="value1">�K�v�Ȕz��̔ԍ�</param>
    /// <param name="value2">�ۑ�����l</param>
    void AddValueStorage0(int value1, int value2)
    {
        _storageNum = value1;

        _valueStorage[_storageNum,value1] = value2;
    }
}
