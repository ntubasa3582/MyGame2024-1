using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] _particleEffect;
    [SerializeField] Image _attackCount;
    RaycastHit _clickHit;
    Vector3 _clickPosition;
    int _particleCount = 0;
    float _maxAttackCount = 0.7f;
    public bool _isAttackCoolDown { private set; get; }
    private void Awake()
    {
        _attackCount.fillAmount = 0.7f;
    }
    void Update()
    {
        if (!_isAttackCoolDown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mousePos, out _clickHit))
                {
                    _clickPosition = _clickHit.point;
                    Instantiate(_particleEffect[_particleCount], _clickPosition, Quaternion.identity);
                }
                if (_attackCount.fillAmount != 0)
                {
                    if (_isAttackCoolDown == false)
                    {
                        float _fillAmountValue = _attackCount.fillAmount;
                        _attackCount.DOFillAmount(_fillAmountValue - 0.1f, 0.3f);
                    }
                }
            }
        }
        if (_attackCount.fillAmount == 0)
        {
            _isAttackCoolDown = true;
            _attackCount.DOFillAmount(_maxAttackCount, 1f)
                .OnComplete(() => _isAttackCoolDown = false);
        }
    }
}
