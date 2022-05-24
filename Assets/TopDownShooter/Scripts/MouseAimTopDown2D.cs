using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimTopDown2D : MonoBehaviour
{
    Camera cam;

    Rigidbody2D rb;
    Vector2 mousePos;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
