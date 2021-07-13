using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public GameObject weapon;

    private void Update() {
        //transform.position=5.53;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (transform.name != "pick Ak")
            {
                Player.bullets += Random.Range(1, 9);
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
