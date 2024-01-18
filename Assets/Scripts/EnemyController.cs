using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;
    PlayerController playerController;  
    [SerializeField] int _hp = 1;       //�G�l�~�[��HP
    private void Awake()
    {
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        playerController = gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        //HP��0�ɂȂ�����f�X�g���C����
        if (_hp <= 0)
        {
            StartCoroutine(DelayDeath(1f));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Attack�̃^�O���t���Ă���I�u�W�F�N�g�ɐG�ꂽ��HP�����炷
        if (other.gameObject.tag == "Attack")
        {
            _hp -= EnemyManager.instance._damage;
        }
    }

    IEnumerator DelayDeath(float delayTime)
    {
        //�G�t�F�N�g�ƃ^�C�~���O�����킹�邽�߂ɒx�����Ă���
        yield return new WaitForSeconds(delayTime);
        GameManager.instance.AddScoreCount();
        Destroy(gameObject);
    }
}
