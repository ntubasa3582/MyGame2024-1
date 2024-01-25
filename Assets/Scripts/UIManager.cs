using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _moneyText;           //��������\������e�L�X�g
    [SerializeField] Text _minText;             //�o�ߎ���(��)��\������e�L�X�g
    [SerializeField] Text _secText;             //�o�ߎ���(�b)��\������e�L�X�g
    [SerializeField] Text _enemyCountText;      //���݂̃G�l�~�[�̐���\������e�L�X�g
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
        //���݂̋����e�L�X�g�ŕ\������
        _moneyText.text = value.ToString("0000");
    }

    public void AddMinText(float value)
    {
        //���ԁi���j���e�L�X�g�ŕ\������
        _minText.text = value.ToString("00");
    }
    public void AddSecText(float value)
    {
        //���ԁi�b�j���e�L�X�g�ŕ\������
        _secText.text = value.ToString("00");
    }
    public void AddEnemyText(float value)
    {
        //���݂̃G�l�~�[�̐����e�L�X�g�ŕ\������
        _enemyCountText.text = value.ToString("0000");
    }
}
