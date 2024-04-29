using System.Collections;
using UnityEngine;
using StarterAssets;
using System.Collections.Generic;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impact = 1000f;

    public Camera fpsCam;
    private StarterAssetsInputs starterAssetsInputs;

    public ParticleSystem muzzleFlash;
    public GameObject impactFX;
    public ParticleSystem bulletFX;

    //public Gun gun;
    private PlayerHealth shield;
    private bool hasShield;

    private AudioSource shoot1;
    public Target target;

    private void Awake()
    {
        shoot1 = gameObject.GetComponentInParent<AudioSource>();
        shield = gameObject.GetComponentInParent<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && hasShield == false)
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
            shoot1.Play();

            if (target != null)
            {
                target.TakeDamage(damage);
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impact);
                }
            }
            Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
        }
        yield return new WaitForSeconds(.2f);
    }

    public void SendShield(bool b)
    {
        hasShield = b;
    }
}
