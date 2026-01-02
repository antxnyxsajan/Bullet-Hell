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
    GameObject pointCam;
    float nextFire;
    int mag;
    bool reloading = false;
    bool isRight = true;

    void Awake()
    {
        gSprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        //pointCam = GameObject.FindWithTag("pointCam");
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
        //pointCam.transform.rotation = Quaternion.Euler(0f,0f,angle);

        if (Input.GetMouseButtonDown(0) && mag > 0 && Time.time > nextFire)
        {
            Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
            mag--;
            nextFire = Time.time + fireRate;
        }
        if (mag <= 0 && !reloading)
            StartCoroutine(Reload());


        //pointing direction
        if ((mousePos.x > player.transform.position.x) && !isRight) //right checking
        {
            player.transform.localScale = new Vector3(1, 1, 1);
            gSprite.sprite = GunRight;
            //pointCam.transform.position = new Vector3(Mathf.Abs(pointCam.transform.position.x),pointCam.transform.position.y,pointCam.transform.position.z);
            isRight = true;
        }
        else if ((mousePos.x <= player.transform.position.x) && isRight) //left checking
        {
            player.transform.localScale = new Vector3(-1, 1, 1) ;
            gSprite.sprite = GunLeft;
            //pointCam.transform.position = new Vector3(Mathf.Abs(pointCam.transform.position.x)*-1f,pointCam.transform.position.y,pointCam.transform.position.z);
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
