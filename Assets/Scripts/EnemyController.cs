using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject _movePoint;
    PlayerController playerController;
    GameManager gameManager;
    EnemyManager _enemyManager;
    Animator _animator;
    [SerializeField] float _moveSpeed = 1f;
    float _hp = 1;       //�G�l�~�[��HP

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        playerController = GameObject.FindAnyObjectByType<PlayerController>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        _enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
    }
    private void Start()
    {
        RandomDirection(0, 360);
    }

    private void Update()
    {
        //HP��0�ɂȂ�����f�X�g���C����
        if (_hp <= 0)
        {
            StartCoroutine(DelayDeath(1f));
        }
    }

    /// <summary>Rotation��Y�Ƀ����_���Ȓl������</summary>
    /// <param name="value1">�ŏ��l</param>
    /// <param name="value2">�ő�l</param>
    void RandomDirection(float value1, float value2)
    {
        _animator.SetBool("IsWalk", false);
        float _randomDirection = Random.Range(value1, value2);
        transform.DOLocalRotate(new Vector3(0, _randomDirection, 0), 1).OnComplete(() => Move()).SetLink(this.gameObject);
    }
    /// <summary>�����Ă�������Ɉړ�����</summary>
    void Move()
    {
        _animator.SetBool("IsWalk", true);
        transform.DOMove(_movePoint.transform.position, _moveSpeed).OnComplete(() => RandomDirection(0, 360)).SetLink(this.gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        //Attack�̃^�O���t���Ă���I�u�W�F�N�g�ɐG�ꂽ��HP�����炷
        if (other.gameObject.CompareTag("Attack"))
        {
            _hp -= playerController.Damage;
        }
    }

    IEnumerator DelayDeath(float delayTime)
    {
        //�G�t�F�N�g�ƃ^�C�~���O�����킹�邽�߂ɒx�����Ă���
        yield return new WaitForSeconds(delayTime);
        _enemyManager.AddEnemyKillCount(1);
        gameManager.AddEnemyKillCount();
        Destroy(gameObject);
    }
}
