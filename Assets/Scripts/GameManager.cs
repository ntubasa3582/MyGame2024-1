using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    public static GameManager instance;
    int _enemyKillScore = 0;//エネミーが倒されたらスコアを増やす



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
    }

    public void AddScoreCount(int count)
    {
        //エネミーが倒されたらスコアを１プラスする
        _enemyKillScore += count;
        _scoreText.text = _enemyKillScore.ToString("0000");
    }
}
