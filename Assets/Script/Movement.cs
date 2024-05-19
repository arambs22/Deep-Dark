using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool canJump = true;
    private float jumpCooldown = 1.3f;

    private void Awake()
    {
        //grab references for rigidbody and animator from the game object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        // Flip the player sprite based on the direction
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.3131477f, 0.3131477f, 0.3131477f);
        else if (horizontalInput < -0.01f)
        transform.localScale = new Vector3(-0.3131477f, 0.3131477f, 0.3131477f);


        if (Input.GetKey(KeyCode.Space) && grounded && canJump)
        {
            Jump();
        }

        //Set animator parameters
        anim.SetBool("Run",horizontalInput != 0);
        anim.SetBool("Grounded",grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");
        grounded = false;
        canJump = false;
        StartCoroutine(JumpCooldown());
    }

    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}