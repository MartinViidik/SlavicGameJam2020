using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    private bool open;

    private AudioSource ac;
    public AudioClip doorOpen;
    public AudioClip doorClosed;

    private void Awake()
    {
        open = false;
        anim = GetComponent<Animator>();
        ac = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!open && isValid(collision))
        {
            ac.PlayOneShot(doorOpen);
            open = true;
            anim.SetBool("open", open);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (open && isValid(collision))
        {
            ac.PlayOneShot(doorClosed);
            open = false;
            anim.SetBool("open", open);
        }
    }

    private bool isValid(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            return true;
        } else {
            return false;
        }
    }
}
