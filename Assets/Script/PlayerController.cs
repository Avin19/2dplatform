using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask movingLayerMask;
    private BoxCollider2D boxcolldier2d;
    private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform pfDeathpartical, pfwinpartical;


    public event EventHandler OnPlayerDeath;
    public event EventHandler OnCoinCollected;
    public event EventHandler OnLevelCompleted;
    public event EventHandler OnPlayerJump;
    private bool isOnPlatform =false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcolldier2d = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        GameObject.Find("GameManager").GetComponent<GameManager>().OnNewLevelStarted += PlayerController_OnNewLevelStarted; ;

    }

    private void PlayerController_OnNewLevelStarted(object sender, EventArgs e)
    {
        transform.position = new Vector3(0, 1, 0);
    }


    private void Update()
    {

        HandleMovement();
        SprinterRenderFlip();


    }

    private void HandleMovement()
    {
        Vector2 movDir = new Vector2();
        float moveSpeed = 10f;
        movDir.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        movDir.y = rb.velocity.y;
        rb.velocity = movDir;

        if (rb.velocity.x == 0)
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Vector2 playertransform2d = new Vector2(transform.position.x, transform.position.y);
            RaycastHit2D raycastHit = Physics2D.BoxCast(playertransform2d + boxcolldier2d.offset, boxcolldier2d.size, 0f, new Vector2(0f, -1f), 0.1f, groundLayerMask);
            
            
     
            if (raycastHit.collider.IsTouchingLayers() )
            {
              
                

                float jumpSpeed = 25f;
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                // Jump Animation
                animator.SetBool("IsJumping", true);
                OnPlayerJump?.Invoke(this, EventArgs.Empty);
               

            }
        }
        else
        {
            animator.SetBool("IsJumping", false);

        }

    }
    private void SprinterRenderFlip()
    {
        bool flix = spriteRenderer.flipX;
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x == 0)
        {
            spriteRenderer.flipX = flix;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.layer == 7)
        {
            //harazds
            OnPlayerDeath?.Invoke(this, EventArgs.Empty);
            Instantiate(pfDeathpartical, transform.position, Quaternion.identity);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            //Coin
            OnCoinCollected?.Invoke(this, EventArgs.Empty);
            other.gameObject.SetActive(false);


        }
        if (other.gameObject.layer == 9)
        {
            //Star
            OnLevelCompleted?.Invoke(this, EventArgs.Empty);
            other.gameObject.SetActive(false);
            Instantiate(pfwinpartical, transform.position, Quaternion.identity);
        }
    }

}
