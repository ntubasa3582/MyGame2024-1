using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    PlayerController playerController;
    GameManager gameManager;
    float _hp = 15;                      //�{�X��HP 
    private void Awake()
    {
        playerController = GameObject.FindAnyObjectByType<PlayerController>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
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
            _hp -= playerController.Damage;
        }
    }

    IEnumerator DelayDeath(float delayTime)
    {
        //�G�t�F�N�g�ƃ^�C�~���O�����킹�邽�߂ɒx�����Ă���
        yield return new WaitForSeconds(delayTime);
        gameManager.BossKillScoreCount();
        Destroy(gameObject);
    }
}