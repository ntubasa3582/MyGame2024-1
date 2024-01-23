using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] int _score = 0;
    int Score => _score;
    Transform transform;
    LevelUpValue levelUpValue;
    private void Awake()
    {
        //Value�N���X��_effectSizePlace�̒l�ő傫����ς���
        transform = GetComponent<Transform>();
        levelUpValue = GameObject.FindAnyObjectByType<LevelUpValue>();
        float value = 1 + levelUpValue._valueStorage[4];
        this.transform.localScale = new Vector3(value, 1, value);
    }

}
