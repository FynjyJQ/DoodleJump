using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Doodle : MonoBehaviour
{
    public static UnityEvent isDefeat = new UnityEvent();
    float horizontal;
    public int vertical = 0;
    public float horizontalSpeed = 2000f;
    public float verticalSpeed = 5000f;
    public Rigidbody2D rigid;

    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D collider2d;
    private bool isCollide;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider2d = gameObject.GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate()
    {
        if (rigid == null) return;
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x * Time.deltaTime * horizontalSpeed;
            if (Input.touches.Length > 0 && isCollide) { vertical = 1; } else { vertical = 0; }

            if (Input.acceleration.x > 0)
            {
                spriteRenderer.flipX = true;
            } else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * horizontalSpeed;
            if ((Input.GetAxis("Vertical") > 0 || Input.GetKeyDown(KeyCode.Space)) && isCollide) { vertical = 1; } else { vertical = 0; }

            if (horizontal > 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (horizontal < 0)
            {
                spriteRenderer.flipX = false;
            }
        }

        if (!isCollide || rigid.velocity.y > 5)
        {
            rigid.velocity = new Vector2(horizontal * 10f * Time.deltaTime, rigid.velocity.y);
        } else
        {
            rigid.velocity = new Vector2(horizontal * 10f * Time.deltaTime, vertical * verticalSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollide = true;
        if (collision.collider.tag == "deadZone")
        {
            isDefeat?.Invoke();
            Destroy(rigid);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollide = false;
    }

    public float GetHorizontal()
    {
        return Mathf.Abs(horizontal);
    }
}
