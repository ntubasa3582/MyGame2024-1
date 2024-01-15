using UnityEngine;

public class PlayerController : MonoBehaviour
{
    RaycastHit _clickHit;
    Vector3 _clickPosition;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePos, out _clickHit))
            {
                _clickPosition = _clickHit.point;

            }
        }
    }
}
