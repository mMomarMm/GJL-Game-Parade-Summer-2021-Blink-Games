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
        if (timeBtwShots < 0) timeBtwShots -= Time.deltaTime;

        //Shooting
        if (Input.GetMouseButton(0))
        {
            if (BulletsText.bullets > 0)
            {
                
                muzzleFlash.Play();
                p.Stand();
                Instantiate(projectile, shotPoint.position, transform.rotation);
                an.SetBool("Shoot", true);
                an.SetBool("Jumping", false);
                BulletsText.bullets--;
                cc.ShakeCamera(shakeIntensity, shakeTime);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            an.SetBool("Shoot", false);
        }
    }
}
