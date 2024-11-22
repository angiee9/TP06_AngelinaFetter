using System.Transactions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] bool onGround = false;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    [SerializeField] private LayerMask groundLayer;


    private Animator playerAnimator;
    private bool doubleJump;

    private Rigidbody2D rb;
    SoundManager soundManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(7.04924f, 7.04924f, 7.04924f);
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-7.04924f, 7.04924f, 7.04924f);
        }

        playerAnimator.SetBool("walk", horizontalInput != 0);

        onGround = CheckIsGrounded();
        playerAnimator.SetBool("isGrounded", onGround);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(CheckIsGrounded() || doubleJump)
            {
                soundManager.PlaySFX(soundManager.jump);
                onGround = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                playerAnimator.SetBool("isGrounded", onGround);

                doubleJump = !doubleJump;
            }
            
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
        }
        
    }

    private bool CheckIsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool CanAttack()
    {
        return horizontalInput == 0 && CheckIsGrounded();
    }
}

