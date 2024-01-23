using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    [SerializeField] GameObject _enemyPrefab;         //エネミーのプレハブ
    [SerializeField] GameObject _bossEnemyPrefab;     //ボスのプレハブ
    [SerializeField] GameObject _bossSpawnPosition;   //ボスの出現位置
    [SerializeField] float[] _spawnPositionX;         //エネミーのX座標の出現位置
    [SerializeField] float[] _spawnPositionZ;         //エネミーのY座標の出現位置
    [SerializeField] float _enemySpawnInterval = 0;   //エネミーの生成インターバル
    float _time = 0;                                  //時間を入れる変数
    bool _isBoss = false;                             //ボスが出現しているかどうかの変数
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _time = 10;
    }

    private void Update()
    {
        if (!_isBoss)
        {
            _time += Time.deltaTime;
            //一定時間ごとにエネミーを出現させる
            if (_enemySpawnInterval < _time)
            {
                RandomPos();
                _time = 0;
            }
        }
    }

    public void RandomPos()
    {
        //決められたランダムな位置にエネミーを出現させる
        float xR = 0; float zR = 0;
        xR = Random.Range(_spawnPositionX[0], _spawnPositionX[1]);
        zR = Random.Range(_spawnPositionZ[0], _spawnPositionZ[1]);
        Instantiate(_enemyPrefab, new Vector3(xR, 1, zR), Quaternion.identity);
    }

    public void BossInstance()
    {
        //決められた位置にボスを出現させる
        Vector3 bossPosition = new Vector3(_bossSpawnPosition.transform.position.x, _bossSpawnPosition.transform.position.y, _bossSpawnPosition.transform.position.z);
        Instantiate(_bossEnemyPrefab, bossPosition, Quaternion.identity);
    }

    public void SpawnIntervalValueChange(float value)
    {
        //エネミの生成インターバル
        _enemySpawnInterval -= value;
    }
}
