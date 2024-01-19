using UnityEngine;

public class LevelUpValue : MonoBehaviour
{
    public static LevelUpValue Instance;
    [SerializeField] public float[] _moneyNeeded;               //0+レベルアップに必要な金
    [SerializeField] public float[] _GetMoneyPlace;             //1+倒した時に追加で貰える金
    [SerializeField] public float[] _enemyInstanceSpeedPlace;   //2+エネミー生成時のインターバルを短くする
    [SerializeField] public float[] _enemyHpPlace;              //3+エネミーのHPを増やす
    [SerializeField] public float[] _effectInstancePlace;       //4+攻撃エフェクトの数を増やす
    [SerializeField] public float[] _effectSizePlace;           //5+攻撃エフェクトのサイズを大きくする
    [SerializeField] public float[] _playerDamagePlace;         //6:プレイヤーがエネミーに与えるダメージを上げる
    [SerializeField]float[,] _valueStorage = new float[7, 2];
    int _storageNum = 0;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
    /// <param name="value1">必要な配列の番号</param>
    /// <param name="value2">保存する値</param>
    void AddValueStorage0(int value1, int value2)
    {
        _storageNum = value1;

        _valueStorage[_storageNum,value1] = value2;
    }
}
