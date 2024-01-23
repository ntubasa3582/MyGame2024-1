using UnityEngine;

public class PlayerController : MonoBehaviour
{
    LevelUpValue levelUpValue;
    [SerializeField] ParticleSystem[] _particleEffect;  //�p�[�e�B�N���̃v���n�u
    RaycastHit _clickHit;                               //�N���b�N����ꏊ�Ɏh�����C
    Vector3 _clickPosition;                             //���C�̍��W���L�^����ϐ�
    public float Damage { get; private set; } = 1f;
    private void Awake()
    {
        levelUpValue = GameObject.FindAnyObjectByType<LevelUpValue>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //�N���b�N�����ʒu��Particle�𐶐�����
            Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePos, out _clickHit))
            {
                _clickPosition = _clickHit.point;
                _clickPosition.y = 1;
                Instantiate(_particleEffect[0], _clickPosition, Quaternion.identity);
            }
        }
    }


}
