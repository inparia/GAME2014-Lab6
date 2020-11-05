using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joyStick;
    public float joyStickHorizontalSensitivity;
    public float joyStickVerticalSensitivity;
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;
    public bool isJumping;

    private Rigidbody2D m_rigidBody2D;
    private SpriteRenderer m_spriteRenderer;
    private Animator m_animator;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (isGrounded)
        {
            if (joyStick.Horizontal > joyStickHorizontalSensitivity)
            {
                m_rigidBody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
                m_spriteRenderer.flipX = false;
                m_animator.SetInteger("AnimState", 1);
            }
            else if (joyStick.Horizontal < -joyStickHorizontalSensitivity)
            {
                m_rigidBody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
                m_spriteRenderer.flipX = true;
                m_animator.SetInteger("AnimState", 1);
            }
           


            else if (!isJumping)
            {
                m_animator.SetInteger("AnimState", 0);
            }

            if ((joyStick.Vertical > joyStickVerticalSensitivity) && (!isJumping))
            {
                m_rigidBody2D.AddForce(Vector2.up * verticalForce * Time.deltaTime);
                m_animator.SetInteger("AnimState", 2);
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            transform.position = spawnPoint.position;
        }
        
    }
}
