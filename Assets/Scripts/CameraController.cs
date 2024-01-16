using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]float _moveX = 0.1f;
    [SerializeField] float _moveZ = 0.1f;
    bool _isMove = false;
    void Start()
    {

    }

    void Update()
    {
        if (_isMove)
        {
            transform.position += new Vector3(_moveX, 0, _moveZ);
        }
        if (Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(0, 21.87f, 0);
            _isMove = false;
        }
    }

    public void LeftMove()
    {
        _isMove = true;
        Move(-0.05f, 0);
    }

    public void RightMove()
    {
        _isMove = true;
        Move(0.05f,0);
    }

    public void UpMove()
    {
        _isMove = true;
        Move(0, 0.05f);
    }

    public void DownMove()
    {
        _isMove = true;
        Move(0, -0.05f);
    }

    public void UpperRight()
    {
        _isMove = true;
        Move(0.05f, 0.05f);
    }

    public void LowerRight()
    {
        _isMove = false;
    }

    public void NoMove()
    {
        _isMove = false;
    }


    public void Move(float x,float y)
    {
        _moveX = x;
        _moveZ = y;
    }
}
