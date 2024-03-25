using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerMovemant : MonoBehaviour
{

    public Rigidbody2D rb;

    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;
   

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }

        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
       
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
