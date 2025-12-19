using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Vector2 movePos;
    Rigidbody2D rb;
    [SerializeField] int hp = 3;
    [SerializeField] float speed = 5f;
    void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movePos = Vector2.MoveTowards(rb.position, player.transform.position, speed*Time.deltaTime);
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
