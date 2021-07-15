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
    bool attackMode, playerVisible; //has seen the player so it will be in attack mode
    void Start()
    {
        scale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, detectRange);
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(.5f);
        GameObject b = Instantiate(bullet, shotPoint.position, transform.rotation);
        Projectile p = b.GetComponent<Projectile>();
        //p.dir = scale.x;
    }

    void Dead()
    {
        Player.PlayerI = 0;
    }
}
