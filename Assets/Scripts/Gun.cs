using System.Collections;
using UnityEngine;
using StarterAssets;
using System.Collections.Generic;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impact = 500f;

    public Camera fpsCam;
    private StarterAssetsInputs starterAssetsInputs;

    public ParticleSystem muzzleFlash;
    public GameObject impactFX;
    public ParticleSystem bulletFX;

    public Target target;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            muzzleFlash.Play();
            bulletFX.Play();
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();


            if (target != null)
            {
                target.TakeDamage(damage);
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impact);
                }
            }
            yield return new WaitForSeconds(.2f);
            Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
