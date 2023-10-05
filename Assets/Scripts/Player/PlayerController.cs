using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed;
    private float moveInput;
    private bool FacingRight;
    public float jumpForce;
    public float checkRadius;
    private bool isGrounded;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //이동
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * _speed, rb.velocity.y);
    }

    void Update()
    {
        //공중 체크
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        //좌우 확인 후 플레이어 회전
        if (moveInput > 0 && !FacingRight)
        {
            flip();
        }
        else if (moveInput < 0 && FacingRight)
        {
            flip();
        }

        //점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //길게 누르면 더 높게 점프하기
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void flip()
    {
        FacingRight = !FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
