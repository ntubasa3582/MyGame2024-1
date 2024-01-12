using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject _movePosObject;
    UIManager _uiManager;
    GameManager _gameManager;
    ItemManager _itemManager;
    Vector3 _playerAngles;
    bool _coolTime = false;
    int _getItem = 0;
    void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
        _uiManager = GameObject.FindFirstObjectByType<UIManager>();
        _itemManager = GameObject.FindFirstObjectByType<ItemManager>();
    }

    void Update()
    {
        if (!_coolTime)
        {
            _playerAngles = transform.eulerAngles;
            if (Input.GetKeyDown(KeyCode.A))
            {
                //A����������v���C���[������]������
                PlayerRotate("A");
                _uiManager.ArrowRotate(+45);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //D����������v���C���[���E��]������
                PlayerRotate("D");
                _uiManager.ArrowRotate(-45);
            }
            else if (Input.GetKeyDown (KeyCode.Space))
            {
                //Space��������������Ă�������Ɉړ�����
                transform.DOLocalMove(_movePosObject.transform.position, 0.1f);
            }
        }
    }

    IEnumerator CoolTime(float num)
    {
        yield return new WaitForSeconds(num);
        _coolTime = false;
    }

    void PlayerRotate(string data)
    {
        _coolTime = true;
        StartCoroutine(CoolTime(0.1f));
        if (data == "A")
        {
            _playerAngles = new Vector3(_playerAngles.x, _playerAngles.y - 45, _playerAngles.z);
            transform.DOLocalRotate(_playerAngles, 0.1f);
        }
        if (data == "D")
        {
            _playerAngles = new Vector3(_playerAngles.x, _playerAngles.y + 45, _playerAngles.z);
            transform.DOLocalRotate(_playerAngles, 0.1f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScoreItem")
        {
            _getItem += 1;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.name == "Circle"&& _getItem != 0)
        {
            //����n�_�Ƀv���C���[���ړ�������G�ꂽ�A�C�e���̃J�E���g���[���ɂ���
            _gameManager.ScoreUp(_getItem);
            _getItem = 0;
            _itemManager.InstanceObject();
        }
    }
}
