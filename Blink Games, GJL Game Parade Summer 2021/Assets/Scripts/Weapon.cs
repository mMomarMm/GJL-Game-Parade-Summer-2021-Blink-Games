using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Weapon : MonoBehaviour
{
    public float offset, startTimeBtwShots, shakeIntensity, shakeTime;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShots /*time between shots*/;
    private Vector3 scale;
    mouseCursor mouseC;
    CameraShake cc;

    private void Start()
    {
        scale = GetComponent<Transform>().localScale;
        cc = GameObject.FindGameObjectWithTag("CineMachine").GetComponent<CameraShake>();
        scale = GetComponent<Transform>().localScale;
        mouseC = GameObject.FindGameObjectWithTag("Respawn").GetComponent<mouseCursor>();
    }
    private void FixedUpdate()
    {
        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
    void Update()
    {

        if (timeBtwShots < 0) timeBtwShots -= Time.deltaTime;

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.localPosition.z)
        {
            offset = 180;
            scale.x = -1;
            transform.localScale = scale;
        }
        else
        {
            offset = 0;
            scale.x = 1;
            transform.localScale = scale;
        }

        if (Input.GetMouseButton(0))
        {
            StartCoroutine(mouseC.cursorAnim());
            if (Player.bullets != 0)
            {
                --Player.bullets;
                Instantiate(projectile, shotPoint.position, transform.rotation);
                cc.ShakeCamera(shakeIntensity, shakeTime);
                timeBtwShots = startTimeBtwShots;
            }/* else{
                play a sound
            }*/
        }
    }

}
