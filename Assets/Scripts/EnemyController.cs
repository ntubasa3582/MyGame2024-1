using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;
    private void Awake()
    {
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            StartCoroutine(DelayAttack(1f));
            //1•b‚½‚Á‚½‚ç“G‚ð“|‚·
        }
    }

    IEnumerator DelayAttack(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GameManager.instance.AddScoreCount(1);
        enemyManager.DeathEnemy();
        Destroy(gameObject);
    }
}
