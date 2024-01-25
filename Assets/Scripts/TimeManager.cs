using UnityEngine;

public class TimeManager : MonoBehaviour
{
    EnemyManager _enemyManager;
    UIManager _uiManager;
    float _minutes = 0;         //時間を入れておく変数(分)  
    float _seconds = 0;        //時間を入れておく変数(秒)   
    bool[] _stop = new bool[40];
    private void Awake()
    {
        _enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        _uiManager = GameObject.FindAnyObjectByType<UIManager>();
    }

    void Update()
    {
        _seconds += Time.deltaTime;
        //一分おきに_minutesに値をいれて_secondsを0にする
        if (_seconds >= 59)
        {
            _seconds = 0;
            _minutes += 1;
        }
        EnemyInstanceSpeedChange(1, 0, 0.5f);
        EnemyInstanceSpeedChange(2, 1, 1.5f);
        EnemyInstanceSpeedChange(5, 2, 0.5f);
        EnemyInstanceSpeedChange(6, 3, 1.5f);
        EnemyInstanceSpeedChange(10, 4, 0.5f);
        EnemyInstanceSpeedChange(11, 5, 1.5f);
        EnemyInstanceSpeedChange(15, 6, 0.5f);
        EnemyInstanceSpeedChange(16, 7, 1.5f);
        EnemyInstanceSpeedChange(20, 8, 0.5f);
        EnemyInstanceSpeedChange(21, 10, 1.5f);
        EnemyInstanceSpeedChange(25, 11, 0.5f);
        EnemyInstanceSpeedChange(26, 12, 1.5f);
        //時間の値をUIマネージャーに送る
        _uiManager.AddSecText(_seconds);
        _uiManager.AddMinText(_minutes);
    }
    /// <summary>エネミーの生成スピードを変更するメソッド</summary>
    /// <param name="min">何分にその処理をしたいか</param>
    /// <param name="count">boolの配列の番号</param>
    /// <param name="value">エネミーの生成スピードを何秒にするか</param>
    void EnemyInstanceSpeedChange(float min, int count, float value)
    {
        if (_minutes >= min)
        {
            //エネミーの生成スピードを変える
            if (!_stop[count])
            {
                _stop[count] = true;
                _enemyManager.IntervalValueChange(value);
            }
        }
    }
}
