using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{

    private Animator animator;
    private Player _PlayerReference;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (!animator)
        {
            //Debug.Log("Not Animator On soil");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        //Animate Destroy
        if(animator)
        {
            animator.SetTrigger("Destroy");
        }
        Destroy(this.gameObject, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _PlayerReference = collision.GetComponent<Player>();
        }
        if (collision.tag == "Dig")
        {
            if (_PlayerReference != null)
            {
                _PlayerReference.PlayerMovement(false);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Dig")
        {
            if (_PlayerReference != null)
            {
                _PlayerReference.PlayerMovement(true);
            }
        }
    }
}
