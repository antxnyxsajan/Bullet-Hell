using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Gun: MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject nozzle;
    [SerializeField] int magSize = 5;
    [SerializeField] int mag;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float reloadRate = 5f;
    float nextFire;
    bool reloading = false;

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

        if (Input.GetMouseButtonDown(0) && mag > 0 && Time.time>nextFire)
        {
            Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
            mag--;
            nextFire = Time.time + fireRate;
        }
        if (mag <= 0 && !reloading)
            StartCoroutine(Reload());
    
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadRate);
        mag = magSize;
        reloading = false;
    }
}
