using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "Value")]

[System.Serializable]
public class Value : ScriptableObject
{
    [field: SerializeField] public float _moneyNeeded { get; private set; }                              //0+レベルアップに必要な金
    [field: SerializeField, Tooltip("済み")] public float _getMoneyPlace { get; private set; }           //1+倒した時に追加で貰える金
    [field: SerializeField, Tooltip("済み")] public float _enemyInstanceSpeedUp { get; private set; }    //2+エネミー生成時のインターバルを短くする
    [field: SerializeField, Tooltip("まだ")] public float _effectInstancePlace { get; private set; }     //3+攻撃エフェクトの数を増やす
    [field: SerializeField, Tooltip("済み")] public float _effectSizePlace { get; private set; }         //4+攻撃エフェクトのサイズを大きくする
}
