using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Animator anim;
    bool moving = false;
    [SerializeField] float speed = 5f;
    [SerializeField] int hp = 5;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        if (moveInput != Vector2.zero && !moving)
        {
            anim.SetBool("isMoving", true);
            moving = true;
        }
        else if (moveInput ==Vector2.zero && moving)
        {
            anim.SetBool("isMoving", false);
            moving = false;
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }

    void damaged()
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
            damaged();
    }

    public Vector2 getPos()
    {
        return (Vector2)transform.position;
    }
}
