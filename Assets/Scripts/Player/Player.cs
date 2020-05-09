using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed =  0.5f;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;
    private Rigidbody2D playerRigidBody;
    private bool isFacingRight = true;

    /*
        =========  TODO  =========
        1. Play Left animation and move player
        2. Play Right animation and move player
        3. Play Up animation and move up player
        4. Play down animation and move down player
        5. play the shooting animation in  all these states
        6. Idle state
    */
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        playerAnimator.SetFloat("Moving", 0);
        float moveHorizontal = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Moving", Mathf.Abs(moveHorizontal));
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(moveHorizontal > 0 && !isFacingRight)
        {
            Flip();
        }

        else if (moveHorizontal < 0 && isFacingRight)
        {
            Flip();
        }
        else
        {
            playerAnimator.SetFloat("Moving", Mathf.Abs(moveHorizontal));

        }

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        playerSpriteRenderer.flipX = !playerSpriteRenderer.flipX;
    }
}
