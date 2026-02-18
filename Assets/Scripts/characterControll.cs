using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    
    public float minX = -8.5f; 
    public float maxX = 8.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Keyboard.current != null)
        {
            moveInput = 0;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveInput = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveInput = 1;
        }
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        anim.SetBool("isRunning", moveInput != 0);

        if (moveInput > 0) sprite.flipX = false;
        else if (moveInput < 0) sprite.flipX = true;
    }
}