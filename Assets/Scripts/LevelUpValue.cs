using System.Collections.Generic;
using UnityEngine;

public class LevelUpValue : MonoBehaviour
{

    GameManager gameManager;
    EnemyManager enemyManager;
    [SerializeField] List<Value> _value = new List<Value>();
    public static LevelUpValue Instance;
    public float[] _valueStorage { get; private set; } = new float[7];          //上の配列の各要素を入れておく変数
    public int[] _levelCount { get; private set; } = new int[7];

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
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
    }

    public void LevelUpMoney()
    {
        //エネミー撃破時に貰える金の量が増える
        if (gameManager._money > _value[_levelCount[1]]._moneyNeeded)
        {
            _valueStorage[1] = _value[_levelCount[1]]._getMoneyPlace;
            gameManager.ChangeMoneyValue( -_value[_levelCount[1]]._moneyNeeded);
            _levelCount[1] += 1;
            Debug.Log("敵を倒したら" + _valueStorage[1] + "倍になる");
        }
    }

    public void EnemyInstanceSpeed()
    {
        //エネミーの生成時間が短縮される
        if (gameManager._money > _value[_levelCount[2]]._moneyNeeded)
        {
            _valueStorage[2] = _value[_levelCount[2]]._enemyInstanceSpeedUp;
            gameManager.ChangeMoneyValue(-_value[_levelCount[2]]._moneyNeeded);
            _levelCount[2] += 1;
            Debug.Log("敵を倒したら" + _valueStorage[2] + "倍になる");
        }
    }

    public void EffectSizeUp()
    {
        //アタックエフェクトのサイズが大きくなる
        if (gameManager._money > _value[_levelCount[4]]._moneyNeeded)
        {
            _valueStorage[4] = _value[_levelCount[4]]._effectSizePlace;
            gameManager.ChangeMoneyValue(-_value[_levelCount[4]]._moneyNeeded);
            _levelCount[4] += 1;
            Debug.Log("敵を倒したら" + _valueStorage[4] + "倍になる");
        }
    }

}
