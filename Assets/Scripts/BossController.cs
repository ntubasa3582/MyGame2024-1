using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    PlayerController playerController;
    GameManager gameManager;
    float _hp = 15;                      //ボスのHP 
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
        if (other.gameObject.tag == "Attack")
        {
            _hp -= playerController.Damage;
        }
    }

    IEnumerator DelayDeath(float delayTime)
    {
        //エフェクトとタイミングを合わせるために遅延している
        yield return new WaitForSeconds(delayTime);
        gameManager.BossKillScoreCount();
        Destroy(gameObject);
    }
}
