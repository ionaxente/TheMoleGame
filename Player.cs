using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private uint _Energy = 10;
    private bool _CanMove = true;
    private float _HorizontalAxis = 0.0f;
    private float _VerticalAxis = 0.0f;
    private bool isDead = false;

    [SerializeField]
    public uint _NumberOfPlayer = 0;

    [SerializeField]
    private KeyCode LeftKey, RightKey, UpKey, DownKey, BreakKey;

    [SerializeField]
    private Dig _dig;

    [SerializeField]
    private AudioClip DestructClip, SadClip, WalkClip;

    private CircleCollider2D _DigColider;

    private UIManager _UIManager;
    private SpawnRoots _SpawnRoots;
    private Animator _Animator;
    private AudioSource _AudioSource;

    void Start()
    {
        _UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _SpawnRoots = GameObject.Find("SpawnRoots").GetComponent<SpawnRoots>();
        _Animator = GetComponent<Animator>();
        _AudioSource = GetComponent<AudioSource>();
        if (!_Animator)
            Debug.Log("NotFound Animator for Player" + _NumberOfPlayer);
        if (!_dig)
        {
            Debug.Log("Dig Not Found");
        }
        else
        {
            _DigColider = _dig.GetComponent<CircleCollider2D>();
        }
    }

    void Update()
    {
        Vector3 Direction = new Vector3(0,0,0);
        if (Input.GetKey(LeftKey))
        {
            _HorizontalAxis = -1;
        }
        else if (Input.GetKey(RightKey))
        {
            _HorizontalAxis = 1;
        }
        else
        {
            _HorizontalAxis = 0;
        }
            

        if (Input.GetKey(DownKey))
            _VerticalAxis = -1;
        else if (Input.GetKey(UpKey))
            _VerticalAxis = 1;
        else
            _VerticalAxis = 0;

        bool _isMove = false;

       if(_HorizontalAxis > 0)
       {
            transform.localScale = new Vector3(1, 1, 1);
            _DigColider.offset = new Vector2(0.245f, 0.0f);
            Direction = Vector3.right;
            _isMove = true;
       }
       else if(_HorizontalAxis < 0)
       {
            transform.localScale = new Vector3(-1, 1, 1);
            _DigColider.offset = new Vector2(0.245f, 0.0f);
            Direction = Vector3.left;
            _isMove = true;
        }
       else if (_VerticalAxis > 0)
       {
            _DigColider.offset = new Vector2(0.0f, 0.245f);
            Direction = Vector3.up;
            _isMove = true;
        }
       else if (_VerticalAxis < 0)
       {
            _DigColider.offset = new Vector2(0.0f, -0.245f);
            Direction = Vector3.down;
            _isMove = true;
        }
        if (_isMove)
        {
            
        }
        if ((_CanMove) && _isMove && (_Energy > 0))
       {
            transform.Translate(Direction * Time.deltaTime);
            _Animator.SetBool("Walk", true);
            if (_AudioSource.clip != WalkClip && !_AudioSource.isPlaying)
                _AudioSource.clip = WalkClip;
            if (!_AudioSource.isPlaying)
                _AudioSource.Play();
        }
        else
        {
            _Animator.SetBool("Walk", false);
            if (_AudioSource.clip == WalkClip && _AudioSource.isPlaying)
                _AudioSource.Stop();
        }
        if (_Energy == 0 && !isDead)
        {
            isDead = true;
            _Animator.SetBool("Dead", true);
            if (_AudioSource.isPlaying)
                _AudioSource.Stop();
            _AudioSource.clip = SadClip;
            _AudioSource.Play();
        }

        
            
           

       if(Input.GetKey(BreakKey)) // Destroy Obstacly if Can
       {
            _Animator.SetBool("Break", true);
            if (_dig)
            {
                if(_dig.isAnObjectToDestroy())
                {
                    if (_dig.destroyThatObject())
                    {
                        _Energy--;
                        if (_UIManager)
                            if(_NumberOfPlayer == 0)
                                _UIManager.setEnergyPlayerOne(_Energy);
                            else
                                _UIManager.setEnergyPlayerTwo(_Energy);
                        if (_SpawnRoots)
                        {
                            _SpawnRoots.showOneRoot();
                            _SpawnRoots.showOneRoot();
                            _SpawnRoots.showOneRoot();
                        }
                        if (_AudioSource.clip != DestructClip)
                        {
                            _AudioSource.clip = DestructClip;
                            _AudioSource.Play();
                        }
                        
                        if(_Energy == 0)
                        {
                            if (_UIManager)
                                _UIManager.GameOverPlayer(_NumberOfPlayer);
                        }
                        _CanMove = true;
                    }
                }

            }
        }
        else
        {
            if (_Animator.GetBool("Break"))
            {
                _Animator.SetBool("Break", false);
            }
        }
    }
    
    public void PlayerMovement(bool _state)
    {
        _CanMove = _state;
    }

    public void Kiss()
    {
        _Animator.SetBool("Kiss", true);
    }
}
