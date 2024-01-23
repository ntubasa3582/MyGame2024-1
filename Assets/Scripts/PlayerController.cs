using UnityEngine;

public class PlayerController : MonoBehaviour
{
    LevelUpValue levelUpValue;
    [SerializeField] ParticleSystem[] _particleEffect;  //パーティクルのプレハブ
    RaycastHit _clickHit;                               //クリックする場所に刺すレイ
    Vector3 _clickPosition;                             //レイの座標を記録する変数
    public float Damage { get; private set; } = 1f;
    private void Awake()
    {
        levelUpValue = GameObject.FindAnyObjectByType<LevelUpValue>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //クリックした位置にParticleを生成する
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
