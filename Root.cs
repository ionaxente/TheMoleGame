using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{

    private float _lastTimeDetected;
    private bool _playerDetected;

    private Player _referencePlayer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerDetected && (Time.unscaledTime - _lastTimeDetected > 0.2))
        {
            _playerDetected = false;
            if (_referencePlayer)
                _referencePlayer.PlayerMovement(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!_referencePlayer || (_referencePlayer != collision.GetComponent<Player>()))
            {
                _referencePlayer = collision.GetComponent<Player>();
                _playerDetected = true;
                _referencePlayer.PlayerMovement(false);
                _lastTimeDetected = Time.unscaledTime;
            }
                
        }
        if (collision.tag == "Dig")
        {
            if (!_playerDetected)
            {
                _playerDetected = true;
                if (_referencePlayer)
                {
                    _referencePlayer.PlayerMovement(false);
                }
            }
            _lastTimeDetected = Time.unscaledTime;
        }
    }
}
