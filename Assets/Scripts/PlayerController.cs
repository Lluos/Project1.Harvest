using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 6f;
    private Vector2 movement;

    private bool facingRight = true;
    public Animator anim;
    public Rigidbody2D rb;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        if (facingRight == false && movement.x > 0f)
        {
            Flip();
        }
        else if (facingRight == true && movement.x < 0f)
        {
            Flip();
        }
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void Movement()
    {

        rb.velocity = movement.normalized * moveSpeed;
        anim.SetFloat("inMove", Mathf.Abs(movement.y * movement.y + movement.x * movement.x));
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
