using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Gun: MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] int magSize = 5;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float reloadRate = 5f;
    [SerializeField] Sprite GunLeft;
    [SerializeField] Sprite GunRight;
    SpriteRenderer gSprite;
    GameObject player;
    GameObject nozzle;
    float nextFire;
    int mag;
    bool reloading = false;
    bool isRight = true;

    void Awake()
    {
        gSprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        nozzle = transform.GetChild(0).gameObject;
    }

    void Start()
    {
        mag = magSize;
        nextFire = fireRate;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(0) && mag > 0 && Time.time > nextFire)
        {
            Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
            mag--;
            nextFire = Time.time + fireRate;
        }
        if (mag <= 0 && !reloading)
            StartCoroutine(Reload());

        if ((mousePos.x > player.transform.position.x) && !isRight)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
            gSprite.sprite = GunRight;
            isRight = true;
        }
        else if ((mousePos.x <= player.transform.position.x) && isRight)
        {
            player.transform.localScale = new Vector3(-1, 1, 1) ;
            gSprite.sprite = GunLeft;
            isRight = false;
        }
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadRate);
        mag = magSize;
        reloading = false;
    }
}
