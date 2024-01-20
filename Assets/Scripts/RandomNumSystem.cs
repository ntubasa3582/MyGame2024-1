using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �K�`���̊m�����v�Z������J�[�h�̃f�[�^���i�[����N���X
/// </summary>
public class RandomNumSystem : MonoBehaviour
{
    [SerializeField]List<int> nums = new List<int>();//�d�ݐݒ�p�ϐ�
    [SerializeField]List<string> name = new List<string>();
    /// <summary>
    /// �K�`�����s</summary>
    public void ChooseStart10(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            int ans = 0;
            ans = Choose(nums);
            Debug.Log(name[ans]);
        }
    }
    /// <summary>���I���\�b�h</summary>
    public int Choose(List<int> weight)
    {
        float total = 0f;
        //�z��̗v�f��total�ɑ��
        for (int i = 0;i < weight.Count; i++)
        {
            total += weight[i];
        }
        //Random.value��0.1����1�܂ł̒l��Ԃ�
        float random = UnityEngine.Random.value * total;
        //weight��random���傫������T��
        for (int i = 0;i < weight.Count ; i++)
        {
            if (random < weight[i])
            {
                //�����_���̒l���d�݂��傫�������炻�̒l��Ԃ�
                return i;
            }
            else
            {
                //�傫���Ȃ�������d�݂����炷
                random -= weight[i];
            }
        }
        //�Ȃ�������Ō�̒l��Ԃ�
        return weight.Count -1;
    }
}
