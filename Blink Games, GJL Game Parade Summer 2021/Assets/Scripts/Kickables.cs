using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kickables : MonoBehaviour
{
    Animator a;
    CapsuleCollider2D cap;
    bool inRange;
    private void Start()
    {
        cap = GetComponent<CapsuleCollider2D>();
        a = GetComponent<Animator>();
        a.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        inRange = other.CompareTag("Player");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = other.CompareTag("Player");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && inRange)
        {
            Debug.Log("o");
            BoxCollider2D b = GetComponent<BoxCollider2D>();
            PolygonCollider2D p = GetComponent<PolygonCollider2D>();
            b.enabled = false;
            p.enabled = false;
            cap.enabled = true;
            a.enabled = true;
            transform.tag = "PlayerWeapon";
            Kickables kickables = GetComponent<Kickables>();
            kickables.enabled = false;
        }
    }
}
