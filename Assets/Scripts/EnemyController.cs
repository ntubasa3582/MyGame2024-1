using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    PlayerController playerController;
    GameManager gameManager;
    float _hp = 1;       //エネミーのHP
    private void Awake()
    {
        playerController = GameObject.FindAnyObjectByType<PlayerController>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        //HPが0になったらデストロイする
        if (_hp <= 0)
        {
            StartCoroutine(DelayDeath(1f));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Attackのタグが付いているオブジェクトに触れたらHPを減らす
        if (other.gameObject.CompareTag("Attack"))
        {
            _hp -= playerController.Damage;
        }
    }

    IEnumerator DelayDeath(float delayTime)
    {
        //エフェクトとタイミングを合わせるために遅延している
        yield return new WaitForSeconds(delayTime);
        gameManager.AddEnemyKillCount();
        Destroy(gameObject);
    }
}
