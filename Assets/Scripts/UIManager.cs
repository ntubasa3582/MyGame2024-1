using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _MoneyText;           //所持金を表示するテキスト
    [SerializeField] Slider _enemyScoreSlider;  //ボス出現までのカウントを表示するスライダー

    private void Awake()
    {
        _enemyScoreSlider.value = 0;        //スライダーの値を0に設定
        _enemyScoreSlider.maxValue = 100;   //スライダーの最大値を設定
    }

    void Update()
    {
        
    }

    public void AddSliderValue(float value)
    {
        _enemyScoreSlider.value = value;
    }

    public void AddMoneyText(float  value)
    {
        _MoneyText.text = value.ToString("0000");
    }
}
