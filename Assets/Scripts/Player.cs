using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] float speed = 5f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();      
    }
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();
        rb.linearVelocity = moveInput * speed;
    }
    void FixedUpdate()
    {
        
    }
}
