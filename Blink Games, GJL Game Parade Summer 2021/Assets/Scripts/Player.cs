using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float vertical, horizontal;
    public static float bullets;
    public float runSpeed;
    Rigidbody2D rb;
    Vector3 Scale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Scale = transform.localScale;
        bullets = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMov();
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
    }
    void HorizontalMov()
    {
        rb.velocity = new Vector2(runSpeed * horizontal, rb.velocity.y);
        Scale.x = horizontal;
        if (horizontal != 0) transform.localScale = Scale;
    }
}
