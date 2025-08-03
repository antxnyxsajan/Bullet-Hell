using UnityEngine;

public class Gun: MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject nozzle;


    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(0))
            Instantiate(bullet, nozzle.transform.position, nozzle.transform.rotation);
    
    }
}
