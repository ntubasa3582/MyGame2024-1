using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    GameManager gameManager;
    void Awake()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    void ChangeScale()
    {

    }

}
