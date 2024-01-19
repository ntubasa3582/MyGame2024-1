using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _MoneyText;           //��������\������e�L�X�g
    [SerializeField] Slider _enemyScoreSlider;  //�{�X�o���܂ł̃J�E���g��\������X���C�_�[

    private void Awake()
    {
        _enemyScoreSlider.value = 0;        //�X���C�_�[�̒l��0�ɐݒ�
        _enemyScoreSlider.maxValue = 100;   //�X���C�_�[�̍ő�l��ݒ�
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
