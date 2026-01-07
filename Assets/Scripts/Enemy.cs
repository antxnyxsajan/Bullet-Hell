using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Vector2 movePos;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    [SerializeField] int hp = 3;
    [SerializeField] float speed = 5f;
    void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        movePos = Vector2.MoveTowards(rb.position, player.transform.position, speed*Time.deltaTime);

        if (transform.position.x >= player.transform.position.x)
            sprite.flipX = false;
        else
            sprite.flipX = true;
    }

    void FixedUpdate()
    {
        rb.MovePosition(movePos);
    }

    public void damaged()
    {
        hp--;
        if (hp <= 0)
            Destroy(gameObject);
    }
}
