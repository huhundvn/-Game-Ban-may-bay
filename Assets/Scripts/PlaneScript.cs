using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public float speedPlane;

    public float offsetScale;

    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public GameObject explode;

    private bool canShoot = true;

    private Rigidbody2D rigidbody;
    private float minX, minY, maxX, maxY;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        meetBound();
    }

    void Update()
    {
        setBound();
        fire();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlane();
    }

    IEnumerator shoot()
    {
        canShoot = false;
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }

    void fire()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine(shoot());
        }
    }

    void meetBound()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, 0f)
        );
        minX = -bounds.x + offsetScale;
        maxX = bounds.x - offsetScale;
        minY = -bounds.y + offsetScale;
        maxY = bounds.y - offsetScale;
    }

    void setBound()
    {
        Vector3 temp = transform.position;

        if (temp.x < minX)
        {
            temp.x = minX;
        } else if (temp.x > maxX)
        {
            temp.x = maxX;
        } else if (temp.y > maxY)
        {
            temp.y = maxX;
        } else if (temp.y < minY)
        {
            temp.y = minY;
        }

        transform.position = temp;
    }

    void movePlane()
    {
        var xAxis = Input.GetAxisRaw("Horizontal") * speedPlane;
        var yAxis = Input.GetAxisRaw("Vertical") * speedPlane;
        rigidbody.velocity = new Vector2(xAxis, yAxis);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet_enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(explode, transform.position, Quaternion.identity);
           
        }
    }
}
