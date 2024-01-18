using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] _particleEffect;  //�p�[�e�B�N���̃v���n�u
    RaycastHit _clickHit;                               //�N���b�N����ꏊ�Ɏh�����C
    Vector3 _clickPosition;                             //���C�̍��W���L�^����ϐ�
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //�N���b�N�����ʒu��Particle�𐶐�����
            Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePos, out _clickHit))
            {
                _clickPosition = _clickHit.point;
                Instantiate(_particleEffect[0], _clickPosition, Quaternion.identity);
            }
        }
    }
}
