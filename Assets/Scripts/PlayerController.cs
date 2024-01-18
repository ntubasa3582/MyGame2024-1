using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] _particleEffect;  //パーティクルのプレハブ
    RaycastHit _clickHit;                               //クリックする場所に刺すレイ
    Vector3 _clickPosition;                             //レイの座標を記録する変数
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //クリックした位置にParticleを生成する
            Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePos, out _clickHit))
            {
                _clickPosition = _clickHit.point;
                Instantiate(_particleEffect[0], _clickPosition, Quaternion.identity);
            }
        }
    }
}
