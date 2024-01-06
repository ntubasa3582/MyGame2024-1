using System;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 playerPos = new Vector3(_player.transform.position.x ,7, _player.transform.position.z - 7);
        transform.position = playerPos;    
    }
}
