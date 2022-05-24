using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public Transform image;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    int direction = 1;
    Vector2 playerDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            direction = -1;
            playerDir = transform.position - player.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            playerDir = Vector2.zero;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            direction = 1;
            playerDir = transform.position - player.position;
        }
        playerDir.Normalize();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerDir * (direction * speed) * Time.fixedDeltaTime);
        RotateImage();
    }

    void RotateImage()
    {
        Vector2 lookDir = transform.position - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        image.rotation = Quaternion.Euler(0, 0, angle);
    }
}
