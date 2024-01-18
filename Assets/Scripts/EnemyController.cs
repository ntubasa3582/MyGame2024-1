using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;
    PlayerController playerController;  
    [SerializeField] int _hp = 1;       //エネミーのHP
    private void Awake()
    {
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        playerController = gameObject.GetComponent<PlayerController>();
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
            _hp -= EnemyManager.instance._damage;
        }
    }

    IEnumerator DelayDeath(float delayTime)
    {
        //エフェクトとタイミングを合わせるために遅延している
        yield return new WaitForSeconds(delayTime);
        GameManager.instance.AddScoreCount();
        Destroy(gameObject);
    }
}
