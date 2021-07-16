using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour
{
    public float detectRange;
    GameObject player;
    public GameObject bullet;
    public Transform shotPoint;
    Vector2 scale;
    Player playerScript;
    bool attackMode, playerVisible; //has seen the player so it will be in attack mode
    float Health = 10;
    void Start()
    {
        scale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attackMode)
        {
        }
        else
        {
            if ((player.transform.position - transform.position).magnitude <= detectRange) attackMode = true;
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(.5f);
        GameObject b = Instantiate(bullet, shotPoint.position, transform.rotation);
        Projectile p = b.GetComponent<Projectile>();
        //p.dir = scale.x;
    }

    public void Damaga(float damage)
    {
        if (Health <= 0)
        {
            StartCoroutine(playerScript.Kill());
        }
        else
        {
            Health -= damage;
            //play a sound that was shot
        }
    }
}
