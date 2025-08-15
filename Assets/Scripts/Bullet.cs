using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]float speed = 20f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.linearVelocity = (mousePos - (Vector2)transform.position).normalized * speed;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().damaged();
            Destroy(gameObject);
        }
    }
}
 