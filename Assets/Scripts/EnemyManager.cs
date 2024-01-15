using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;//�G�l�~�[�v���n�u
    [SerializeField] int[] _spawnPositionX;//�G�l�~�[��������X���W
    [SerializeField] int[] _spawnPositionZ;//�G�l�~�[����
    [SerializeField] int _enemySpawnInterval = 0;//�G�l�~�[�����������p�x
    [SerializeField] int _spawnCount = 1;//�G�l�~�[�̃X�|�[�����
    float _time = 0;
    private void Awake()
    {
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_enemySpawnInterval < _time)
        {
            RandomPos();
            _time = 0;
        }
    }

    void RandomPos()
    {
        float xR = 0; float zR = 0;
        xR = Random.Range(_spawnPositionX[0], _spawnPositionX[1]);
        zR = Random.Range(_spawnPositionZ[0], _spawnPositionZ[1]);
        Instantiate(_enemyPrefab, new Vector3(xR, 0, zR), Quaternion.identity);
    }
}
