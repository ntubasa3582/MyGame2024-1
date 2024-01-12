using System;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    [SerializeField] GameObject _player;

    void Update()
    {
        Vector3 playerPos = new Vector3(_player.transform.position.x ,13.5f, _player.transform.position.z - 7f);
        transform.position = playerPos;    
    }
}
