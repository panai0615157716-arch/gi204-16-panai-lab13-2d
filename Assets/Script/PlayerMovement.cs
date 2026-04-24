using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    [SerializeField] float Speed;
    float move;
    
    [SerializeField] float JumpForce;
    [SerializeField] bool IsJumping;

    Rigidbody2D rb2d; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);*/

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * Speed);


        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));
            Debug.Log("Jump");
        
        }
    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        { 
            IsJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            IsJumping = true; 
        
        }


    }




}
