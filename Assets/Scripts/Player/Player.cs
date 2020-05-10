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
    private bool isRunningUp = true;

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
        playerAnimator.SetFloat("Horizontal", 0);
        float moveHorizontal = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Vertical", Mathf.Abs(moveHorizontal));
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Horizontal animations
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
            playerAnimator.SetFloat("Horizontal", Mathf.Abs(moveHorizontal));

        }

        //Vertical animations
        if (moveVertical > 0 && !isRunningUp)
        {
            Rotation();
        }

        else if (moveVertical < 0 && isRunningUp)
        {
            Rotation();
        }
        else
        {
            playerAnimator.SetFloat("Vertical", Mathf.Abs(moveVertical));

        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        playerSpriteRenderer.flipX = !playerSpriteRenderer.flipX;
    }

    private void Rotation()
    {
        isRunningUp = !isRunningUp;
        playerSpriteRenderer.transform.eulerAngles = Vector3.forward * 40;
    }
}
