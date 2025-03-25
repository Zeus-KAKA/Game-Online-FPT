using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;       // Tốc độ di chuyển
    public float jumpForce = 20f;   // Lực nhảy
    private bool isGrounded;       // Kiểm tra chạm đất

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
        UpdateAnimation();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Lấy input từ A/D hoặc phím mũi tên
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // Lật nhân vật khi di chuyển trái/phải
        if (moveInput > 0)
            sprite.flipX = false;
        else if (moveInput < 0)
            sprite.flipX = true;

        // Gán giá trị tốc độ cho Animator
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            anim.SetBool("isJumping", true);
        }
    }

    private void UpdateAnimation()
    {
        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        else
        {
            if (rb.linearVelocity.y > 0)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isFalling", false);
            }
            else if (rb.linearVelocity.y < 0)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
