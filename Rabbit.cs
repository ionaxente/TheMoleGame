using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField]
    private Heart _heartRef;

    private UIManager _UIManager;

    private Animator _Animator;
    private AudioSource audio;

    void Start()
    {
        _UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player _player = collision.GetComponent<Player>();
            _UIManager.GameWinPlayer(_player._NumberOfPlayer);
            _player.PlayerMovement(false);
            _player.Kiss();
            Instantiate(_heartRef, new Vector3(-0.64f,3,0), Quaternion.identity);
            _Animator.SetTrigger("Kiss");
            audio.Play();
        }
    }
}
