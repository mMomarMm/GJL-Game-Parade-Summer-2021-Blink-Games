using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public GameObject weapon;
    bool animPos;
    public float posAmplitude;
    public float posSpeed;
    private float origY;

    private float startAnimOffset = 0;
    void Awake()
    {
        animPos = true;
        origY = transform.position.y;
        startAnimOffset = Random.Range(0f, 540f);        // so that the xyz anims are already offset from each other since the start
    }

    void Update()
    {
        /* position */
        if (animPos)
        {
            Vector2 pos;
            pos.x = transform.position.x;
            pos.y = origY + posAmplitude * Mathf.Sin(posSpeed * Time.time + startAnimOffset);
            transform.position = pos;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.name == "ammo")
            {
                Player.bullets += Random.Range(1, 9);
                Destroy(gameObject);
            }
            else
            {
                weapon.SetActive(true);
                //play a gun recharging sound
                Destroy(gameObject);
            }
        }
    }
}
