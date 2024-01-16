using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    public static GameManager instance;
    int _enemyKillScore = 0;//�G�l�~�[���|���ꂽ��X�R�A�𑝂₷



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
        //�G�l�~�[���|���ꂽ��X�R�A���P�v���X����
        _enemyKillScore += count;
        _scoreText.text = _enemyKillScore.ToString("0000");
    }
}
