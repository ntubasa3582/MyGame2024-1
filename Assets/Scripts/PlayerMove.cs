using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject _movePosObject;
    Vector3 PlayerPos;
    bool _coolTime = false;
    void Start()
    {

    }

    void Update()
    {
        if (!_coolTime)
        {
            PlayerPos = transform.eulerAngles;
            if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerRotate("A");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerRotate("D");
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
        StartCoroutine(CoolTime(0.5f));
        if (data == "A")
        {
            PlayerPos = new Vector3(PlayerPos.x, PlayerPos.y - 45, PlayerPos.z);
            transform.DOLocalRotate(PlayerPos, 0.5f);
        }
        if (data == "D")
        {
            PlayerPos = new Vector3(PlayerPos.x, PlayerPos.y + 45, PlayerPos.z);
            transform.DOLocalRotate(PlayerPos, 0.5f);
        }
    }
}
