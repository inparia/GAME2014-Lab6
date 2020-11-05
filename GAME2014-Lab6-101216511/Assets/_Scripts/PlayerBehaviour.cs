using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joyStick;
    public float joyStickHorizontalSensitivity;
    public float horizontalForce;
    public float verticalForce;

    private Rigidbody2D m_rigidBody2D;
    private SpriteRenderer m_spriteRenderer;
    private Animator m_animator;
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
        if(joyStick.Horizontal > joyStickHorizontalSensitivity)
        {
            m_rigidBody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
        }
        else if (joyStick.Horizontal < -joyStickHorizontalSensitivity)
        {
            m_rigidBody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
        }
        else
        {

        }
    }
}
