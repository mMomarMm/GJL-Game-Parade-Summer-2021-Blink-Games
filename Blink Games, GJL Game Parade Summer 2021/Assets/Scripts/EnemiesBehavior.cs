using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour, TakeDamage
{
    public float detectRange;
    GameObject player;
    public GameObject bullet, ammoDrop;
    public bool canPatrol;
    public Transform shotPoint;
    public ParticleSystem muzzleFlash;
    Animator animator;
    Rigidbody2D rb;
    Vector2 Scale;
    Player playerScript;
    bool attackMode = false; //has seen the player so it will be in attack mode
    float Health = 10, maxbullets = 10, currentBullets, horizontal, timeBtwShoots, startTimebtwShoots = .3f;
    public LayerMask Layers;
    LayerMask groundL, playerL;
    void Start()
    {
        timeBtwShoots = 0;
        currentBullets = maxbullets;
        groundL = LayerMask.GetMask("Ground");
        playerL = LayerMask.GetMask("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        Scale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = Scale;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position,
        detectRange, Layers);
        if (attackMode)
        {
            if (player.transform.position.x - transform.position.x > 0)
                horizontal = 1;
            else
            {
                horizontal = -1;
            }

            //shooting
            if (hit)
            {
                //Jump
                if (player.transform.position.y - transform.position.y >= .7f)
                {
                    if (Physics2D.Raycast(transform.position, Vector2.down, 1.27f, groundL))
                    {
                        animator.SetBool("Jumping", true);
                        rb.velocity = new Vector2(rb.velocity.x, 8);
                        StartCoroutine(Wait());
                    }
                }
                //running
                animator.SetBool("Walking", true);
                rb.velocity = new Vector2(7 * horizontal, rb.velocity.y);
                Scale.x = horizontal;
                //Shoot
                if (currentBullets > 0)
                {
                    if (timeBtwShoots <= 0)
                    {
                        timeBtwShoots = startTimebtwShoots;
                        Shoot();
                    }
                    else
                    {
                        timeBtwShoots -= Time.deltaTime;
                    }
                }
                else
                {
                    StartCoroutine(Reload());
                }
            }
            else
            {
                animator.SetBool("Shooting", false);
                animator.SetBool("Reload", false);
            }
        }
        else if (hit && hit.collider.CompareTag("Player")) attackMode = true;
        else { if (canPatrol) Patrol(); }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("Jumping", true);
    }

    void Patrol()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * Scale.x, 3, groundL);
        if (hit)
        {
            Scale.x *= -1;
        }
        animator.SetFloat("Speed", .7f);
        float elapsedTime = 0.0f;
        if (elapsedTime < Random.Range(0, 10f))
        {
            rb.velocity = new Vector2(4.9f * Scale.x, 0);
        }
    }

    void Shoot()
    {
        animator.SetBool("Reload", false);
        muzzleFlash.Play();
        currentBullets--;
        animator.SetBool("Shooting", true);
        GameObject b = Instantiate(bullet, shotPoint.position, transform.rotation);
        Projectile p = b.GetComponent<Projectile>();
        p.dir = Scale.x;
    }
    IEnumerator Reload()
    {
        animator.SetBool("Shooting", false);
        animator.SetBool("Reload", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Reload", false);
        currentBullets = maxbullets;
    }

    public void Damage(float damage, GameObject effect)
    {
        if (Health <= 0)
        {
            StartCoroutine(playerScript.Kill());
            Instantiate(ammoDrop, transform.position, ammoDrop.transform.rotation);
            foreach (AnimatorControllerParameter parameter in animator.parameters)
            {
                if (parameter.type == AnimatorControllerParameterType.Bool)
                    animator.SetBool(parameter.name, false);
            }
            transform.GetChild(0).position = new Vector3(transform.position.x, -.99f, transform.position.z);
            for (int i = 1; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            animator.SetTrigger("Dead");
            Destroy(this);
        }
        else
        {
            Health -= damage;
        }
    }
    public void Stop()
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Bool)
                animator.SetBool(parameter.name, false);
        }
        Destroy(this);
    }
}