using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] RawImage _playerArrowImage;
    [SerializeField] RawImage _arrowImage;
    float _rotatevalue = 0;

    public void EnemyPosArrow(float num)
    {

    }

    public void ArrowRotate(float num)
    {
        //�v���C���[��������ς������ɖ�̌������v���C���[�������Ă�������ɕς���
        _rotatevalue += num;
        _arrowImage.rectTransform.DOLocalRotate(new Vector3(0, 0, _rotatevalue), 0.1f);
    }
}
