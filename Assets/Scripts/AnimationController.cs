using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Doodle doodle;
    private Animator animator;
    void Start()
    {
        if (doodle == null)
        {
            doodle = gameObject.GetComponent<Doodle>();
            animator = gameObject.GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (doodle.rigid == null) return;
        animator.SetInteger("jump", doodle.vertical);
        animator.SetFloat("speedUp", Mathf.Abs(doodle.rigid.velocity.y));
        animator.SetFloat("speed", doodle.GetHorizontal());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "deadZone")
        {
            animator.SetBool("isDead", true);
        }
    }
}
