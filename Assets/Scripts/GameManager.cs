using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int ScoreCount { get;  set; } = 0;
    [SerializeField] Text _scoreText;



    public void ScoreUp(int count)
    {
        ScoreCount += count;
        _scoreText.text = ScoreCount.ToString("0000");
    }
}
