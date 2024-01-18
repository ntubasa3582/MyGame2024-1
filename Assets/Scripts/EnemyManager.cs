using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    [SerializeField] GameObject _enemyPrefab;       //�G�l�~�[�̃v���n�u
    [SerializeField] GameObject _bossEnemyPrefab;   //�{�X�̃v���n�u
    [SerializeField] GameObject _bossSpawnPosition; //�{�X�̏o���ʒu
    [SerializeField] int[] _spawnPositionX;         //�G�l�~�[��X���W�̏o���ʒu
    [SerializeField] int[] _spawnPositionZ;         //�G�l�~�[��Y���W�̏o���ʒu

    public int _damage { get;private set; } = 1;           //�v���C���[�̃G�l�~�[�ւ̃_���[�W
    float _time = 0;                                //���Ԃ�����ϐ�
    [SerializeField] float _enemySpawnInterval = 0; //�G�l�~�[�̐����C���^�[�o��
    public bool _isBossEmergence { get; private set; } = false;      //�{�X���������ꂽ��G�l�~�[�𐶐��ł��Ȃ�����ϐ�
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
        if (!_isBossEmergence)
        {
            _time += Time.deltaTime;
            //��莞�Ԃ��ƂɃG�l�~�[���o��������
            if (_enemySpawnInterval < _time)
            {
                RandomPos();
                _time = 0;
            }
        }

    }

    void RandomPos()
    {
        //���߂�ꂽ�����_���Ȉʒu�ɃG�l�~�[���o��������
        float xR = 0; float zR = 0;
        xR = Random.Range(_spawnPositionX[0], _spawnPositionX[1]);
        zR = Random.Range(_spawnPositionZ[0], _spawnPositionZ[1]);
        Instantiate(_enemyPrefab, new Vector3(xR, 0, zR), Quaternion.identity);
    }

    public void BossInstance()
    {
        //���߂�ꂽ�ʒu�Ƀ{�X���o��������
        Vector3 bossPosition = new Vector3(_bossSpawnPosition.transform.position.x, _bossSpawnPosition.transform.position.y, _bossSpawnPosition.transform.position.z);
        Instantiate(_bossEnemyPrefab,bossPosition , Quaternion.identity);
    }
}
