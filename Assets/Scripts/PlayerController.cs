using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] _particleEffect;
    RaycastHit _clickHit;
    Vector3 _clickPosition;
    int _particleCount = 0;
    [SerializeField] float _clickCoolTime = 3f;
    bool _isAttackCoolTime;
    private void Awake()
    {
    }
    void Update()
    {
        if (!_isAttackCoolTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mousePos, out _clickHit))
                {
                    _clickPosition = _clickHit.point;
                    Instantiate(_particleEffect[_particleCount], _clickPosition, Quaternion.identity);
                }
                AttackCoolTime();
                StartCoroutine(CoolTime());
            }
        }
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(_clickCoolTime);
        AttackCoolTime();
    }

    private void AttackCoolTime()
    {
        _isAttackCoolTime = !_isAttackCoolTime;
    }
}
