using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _moneyText;           //所持金を表示するテキスト
    [SerializeField] Text _minText;             //経過時間(分)を表示するテキスト
    [SerializeField] Text _secText;             //経過時間(秒)を表示するテキスト
    [SerializeField] Text _enemyCountText;      //現在のエネミーの数を表示するテキスト
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
        //現在の金をテキストで表示する
        _moneyText.text = value.ToString("0000");
    }

    public void AddMinText(float value)
    {
        //時間（分）をテキストで表示する
        _minText.text = value.ToString("00");
    }
    public void AddSecText(float value)
    {
        //時間（秒）をテキストで表示する
        _secText.text = value.ToString("00");
    }
    public void AddEnemyText(float value)
    {
        //現在のエネミーの数をテキストで表示する
        _enemyCountText.text = value.ToString("0000");
    }
}
