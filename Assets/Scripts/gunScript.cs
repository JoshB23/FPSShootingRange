using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class gunScript : MonoBehaviour
{
    
    public float damage, range;
    public Camera fpsCam;
    public AudioSource shoot, hitted;
    public ParticleSystem ps;

    void Update()
    {
        //input to fire gun, playing particle system for muzzle flash and playing audio source
        if(Input.GetButtonDown("Fire1") && Time.timeScale == 1)
        {
            Shoot();
            shoot.Play();
            ps.Play();
        }
    }

    void Shoot()
    {
        //raycast
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //checking raycast hit tag to confirm it is the target, then applying damage, playing audio source for a hit
            Target target = hit.transform.GetComponent<Target>();
            if (hit.collider.tag == "Target")
            {
                target.TakeDamage(damage);
                hitted.Play();
            }

        }
    }
}
