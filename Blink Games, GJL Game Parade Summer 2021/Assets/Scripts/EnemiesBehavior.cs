using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour, TakeDamage
{
    public float detectRange;
    GameObject player;
    public GameObject bullet;
    public Transform shotPoint;
    Vector2 scale;
    Player playerScript;
    bool attackMode = false, playerVisible; //has seen the player so it will be in attack mode
    float Health = 10;
    LayerMask GroundL;
    void Start()
    {
        GroundL = LayerMask.GetMask("Ground");
        scale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position,
        detectRange, GroundL);
        if (attackMode)
        {
            if (hit) { }
        }
        else if (hit) attackMode = true;
        else { Patrol(); }
    }

    void Patrol()
    {

    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(.5f);
        GameObject b = Instantiate(bullet, shotPoint.position, transform.rotation);
        Projectile p = b.GetComponent<Projectile>();
        //p.dir = scale.x;
    }

    public void Damage(float damage, GameObject effect)
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
