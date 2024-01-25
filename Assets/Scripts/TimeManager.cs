using UnityEngine;

public class TimeManager : MonoBehaviour
{
    EnemyManager _enemyManager;
    UIManager _uiManager;
    float _minutes = 0;         //���Ԃ����Ă����ϐ�(��)  
    float _seconds = 0;        //���Ԃ����Ă����ϐ�(�b)   
    bool[] _stop = new bool[40];
    private void Awake()
    {
        _enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        _uiManager = GameObject.FindAnyObjectByType<UIManager>();
    }

    void Update()
    {
        _seconds += Time.deltaTime;
        //�ꕪ������_minutes�ɒl�������_seconds��0�ɂ���
        if (_seconds >= 59)
        {
            _seconds = 0;
            _minutes += 1;
        }
        EnemyInstanceSpeedChange(1, 0, 0.5f);
        EnemyInstanceSpeedChange(2, 1, 1.5f);
        EnemyInstanceSpeedChange(5, 2, 0.5f);
        EnemyInstanceSpeedChange(6, 3, 1.5f);
        EnemyInstanceSpeedChange(10, 4, 0.5f);
        EnemyInstanceSpeedChange(11, 5, 1.5f);
        EnemyInstanceSpeedChange(15, 6, 0.5f);
        EnemyInstanceSpeedChange(16, 7, 1.5f);
        EnemyInstanceSpeedChange(20, 8, 0.5f);
        EnemyInstanceSpeedChange(21, 10, 1.5f);
        EnemyInstanceSpeedChange(25, 11, 0.5f);
        EnemyInstanceSpeedChange(26, 12, 1.5f);
        //���Ԃ̒l��UI�}�l�[�W���[�ɑ���
        _uiManager.AddSecText(_seconds);
        _uiManager.AddMinText(_minutes);
    }
    /// <summary>�G�l�~�[�̐����X�s�[�h��ύX���郁�\�b�h</summary>
    /// <param name="min">�����ɂ��̏�������������</param>
    /// <param name="count">bool�̔z��̔ԍ�</param>
    /// <param name="value">�G�l�~�[�̐����X�s�[�h�����b�ɂ��邩</param>
    void EnemyInstanceSpeedChange(float min, int count, float value)
    {
        if (_minutes >= min)
        {
            //�G�l�~�[�̐����X�s�[�h��ς���
            if (!_stop[count])
            {
                _stop[count] = true;
                _enemyManager.IntervalValueChange(value);
            }
        }
    }
}
