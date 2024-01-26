using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    UIManager _uiManager;
    private ObjectPool<GameObject> m_objectPool;                // �I�u�W�F�N�g�v�[��
    [SerializeField] GameObject[] _enemyPrefabs;                //�G�l�~�[�̃v���n�u
    [SerializeField] GameObject[] _spawnPoints;                 //�G�l�~�[�̃X�|�[���ꏊ�̃v���n�u
    [SerializeField] float[] _spawnPositionX;                   //�G�l�~�[��X���W�̏o���ʒu
    [SerializeField] float[] _spawnPositionZ;                   //�G�l�~�[��Y���W�̏o���ʒu
    public int _enemyInstanceCount { get; private set; }        //�G�l�~�[�̐����J�E���g
    //public int _enemyKillCount { get; private set; }          //�G�l�~�[��|�������ɃJ�E���g����ϐ�
    public int _enemyUpperLimit { get; private set; } = 100;    //�G�l�~�[�̐������
    float _time = 0;                                            //���Ԃ������ϐ�
    public float _interval { get; private set; } = 1.5f;        //�G�l�~�[�̐����ɂ����鎞��

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _time = 10; //�ŏ��ɃG�l�~�[�𐶐����邽�߂ɒl�����Ă���
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _uiManager.AddEnemyLimitText(_enemyUpperLimit);
    }

    private void Update()
    {
        //��莞�Ԃ��ƂɃG�l�~�[�𐶐�
        if (_enemyUpperLimit <= _enemyInstanceCount)
        {
            _time = 0;
            Debug.Log("�Q�[���I�[�o�[");
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
    /// <param name="count">�����������ꏊ�̃v���n�u�̔ԍ�</param>
    public void EnemyInstance(int count)
    {
        //���߂�ꂽ�����_���Ȉʒu�ɃG�l�~�[���o��������
        float xR = 0; float zR = 0;
        xR = Random.Range(_spawnPositionX[0], _spawnPositionX[1]);
        zR = Random.Range(_spawnPositionZ[0], _spawnPositionZ[1]);
        Vector3 _spawnPos = new Vector3(_spawnPoints[count].transform.position.x + xR, _spawnPoints[count].transform.position.y + 1.2f, _spawnPoints[count].transform.position.z + zR);
        Instantiate(_enemyPrefabs[0], _spawnPos, Quaternion.identity);
        AddEnemyInstanceCount(1);
    }

    public void BossInstance()
    {
        //���߂�ꂽ�ʒu�Ƀ{�X���o��������
        Vector3 bossPosition = new Vector3(0, 0, 0);
        Instantiate(_enemyPrefabs[0], bossPosition, Quaternion.identity);
        AddEnemyInstanceCount(1);
    }
    public void AddEnemyInstanceCount(int count)
    {
        //_enemyInstanceCount�̒l�𑝂₷
        _enemyInstanceCount += count;
        _uiManager.AddEnemyText(_enemyInstanceCount);
    }

    public void IntervalValueChange(float count)
    {
        //�������Ԃ𑁂�������A�x������
        _interval = count;
    }
}
