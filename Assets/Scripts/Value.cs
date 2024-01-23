using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "Value")]

[System.Serializable]
public class Value : ScriptableObject
{
    [field: SerializeField] public float _moneyNeeded { get; private set; }                              //0+���x���A�b�v�ɕK�v�ȋ�
    [field: SerializeField, Tooltip("�ς�")] public float _getMoneyPlace { get; private set; }           //1+�|�������ɒǉ��ŖႦ���
    [field: SerializeField, Tooltip("�ς�")] public float _enemyInstanceSpeedUp { get; private set; }    //2+�G�l�~�[�������̃C���^�[�o����Z������
    [field: SerializeField, Tooltip("�܂�")] public float _effectInstancePlace { get; private set; }     //3+�U���G�t�F�N�g�̐��𑝂₷
    [field: SerializeField, Tooltip("�ς�")] public float _effectSizePlace { get; private set; }         //4+�U���G�t�F�N�g�̃T�C�Y��傫������
}
