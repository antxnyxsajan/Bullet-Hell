using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Gun: MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject nozzle;
    [SerializeField] int magSize = 5;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float reloadRate = 5f;
    GameObject pSprite;
    GameObject player;
    float nextFire;
    int mag;
    bool reloading = false;
    bool isRight = true;

    void Start()
    {
        mag = magSize;
        nextFire = fireRate;
        pSprite = GameObject.FindWithTag("pSprite");
        player = GameObject.FindWithTag("Player");
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
            //transform.localScale = new Vector3(1, 1, 1);
            isRight = true;
        }
        else if ((mousePos.x <= player.transform.position.x) && isRight)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
            isRight = false;
        }
        if(!isRight)
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadRate);
        mag = magSize;
        reloading = false;
    }
}
