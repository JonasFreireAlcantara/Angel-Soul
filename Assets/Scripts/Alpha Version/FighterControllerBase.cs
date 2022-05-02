using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class with basic functions to make the control of fighters.
 */
public class FighterControllerBase : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    protected Rigidbody2D rigidbody2D;
    protected bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Tag.GROUND))
        {
            isGrounded = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag(Tag.GROUND))
        {
            isGrounded = true;
        }
    }

    protected void Move(float direction)
    { 
        rigidbody2D.velocity = new Vector2(direction * speed * Time.deltaTime, rigidbody2D.velocity.y);
    }

    protected void Jump(ForceMode2D forceMode2D = ForceMode2D.Impulse)
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce, forceMode2D);
    }
}
