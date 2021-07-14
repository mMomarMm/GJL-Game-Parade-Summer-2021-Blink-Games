using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Weapon : MonoBehaviour
{
    public float offset, startTimeBtwShots, shakeIntensity, shakeTime;
    public ParticleSystem muzzleFlash;
    public GameObject projectile;
    public Transform shotPoint;
    float timeBtwShots, /*time between shots*/ rotZ;
    private Vector3 scale;
    CameraShake cc;
    Animator an;
    Player p;


    private void Start()
    {
        p = GetComponentInParent<Player>();
        scale = GetComponent<Transform>().localScale;
        cc = GameObject.FindGameObjectWithTag("CineMachine").GetComponent<CameraShake>();
        an = transform.parent.gameObject.GetComponentInChildren<Animator>();
    }
    private void FixedUpdate()
    {
        // Handles the weapon rotation
        /*Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);*/
    }
    void Update()
    {
        //Flips the weapon
        /*if (rotZ < 89 && rotZ > -89)
        {
            scale.y = 1;
            transform.localScale = scale;
        }
        else
        {
            scale.y = -1;
            transform.localScale = scale;
        }*/

        //Shooting Cooldown
        if (timeBtwShots < 0) timeBtwShots -= Time.deltaTime;

        //Shooting
        if (Input.GetMouseButton(0))
        {
            if (BulletsText.bullets != 0)
            {
                muzzleFlash.Play();
                p.Stand();
                an.SetBool("Shoot", true);
                an.SetBool("Jumping", false);
                BulletsText.bullets--;
                Instantiate(projectile, shotPoint.position, transform.rotation);
                cc.ShakeCamera(shakeIntensity, shakeTime);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                //play a sound
            }
        }
        else
        {
            an.SetBool("Shoot", false);
        }
    }

}
