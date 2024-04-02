
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impact = 30f;

    public Camera fpsCam;
    private StarterAssetsInputs starterAssetsInputs;
    public ParticleSystem muzzleFlash;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            muzzleFlash.Play();
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(damage);
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impact);
                }
            }

        }
    }
}
