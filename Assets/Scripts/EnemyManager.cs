using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    UIManager _uiManager;
    private ObjectPool<GameObject> m_objectPool;                // オブジェクトプール
    [SerializeField] GameObject[] _enemyPrefabs;                //エネミーのプレハブ
    [SerializeField] GameObject[] _spawnPoints;                 //エネミーのスポーン場所のプレハブ
    [SerializeField] float[] _spawnPositionX;                   //エネミーのX座標の出現位置
    [SerializeField] float[] _spawnPositionZ;                   //エネミーのY座標の出現位置
    public int _enemyInstanceCount { get; private set; }        //エネミーの生成カウント
    //public int _enemyKillCount { get; private set; }          //エネミーを倒した時にカウントする変数
    public int _enemyUpperLimit { get; private set; } = 100;    //エネミーの生成上限
    float _time = 0;                                            //時間をいれる変数
    public float _interval { get; private set; } = 1.5f;        //エネミーの生成にかかる時間

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _time = 10; //最初にエネミーを生成するために値を入れておく
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _uiManager.AddEnemyLimitText(_enemyUpperLimit);
    }

    private void Update()
    {
        //一定時間ごとにエネミーを生成
        if (_enemyUpperLimit <= _enemyInstanceCount)
        {
            _time = 0;
            Debug.Log("ゲームオーバー");
        }
        _time += Time.deltaTime;
        if (_time > _interval)
        {
            EnemyInstance(0);
            EnemyInstance(1);
            EnemyInstance(2);
            _time = 0;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="count">生成したい場所のプレハブの番号</param>
    public void EnemyInstance(int count)
    {
        //決められたランダムな位置にエネミーを出現させる
        float xR = 0; float zR = 0;
        xR = Random.Range(_spawnPositionX[0], _spawnPositionX[1]);
        zR = Random.Range(_spawnPositionZ[0], _spawnPositionZ[1]);
        Vector3 _spawnPos = new Vector3(_spawnPoints[count].transform.position.x + xR, _spawnPoints[count].transform.position.y + 1.2f, _spawnPoints[count].transform.position.z + zR);
        Instantiate(_enemyPrefabs[0], _spawnPos, Quaternion.identity);
        AddEnemyInstanceCount(1);
    }

    public void BossInstance()
    {
        //決められた位置にボスを出現させる
        Vector3 bossPosition = new Vector3(0, 0, 0);
        Instantiate(_enemyPrefabs[0], bossPosition, Quaternion.identity);
        AddEnemyInstanceCount(1);
    }
    public void AddEnemyInstanceCount(int count)
    {
        //_enemyInstanceCountの値を増やす
        _enemyInstanceCount += count;
        _uiManager.AddEnemyText(_enemyInstanceCount);
    }

    public void IntervalValueChange(float count)
    {
        //生成時間を早くしたり、遅くする
        _interval = count;
    }
}
