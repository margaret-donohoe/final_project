using UnityEngine;
using StarterAssets;

public class PickUpItem : MonoBehaviour
{
    private StarterAssetsInputs starterAssetsInputs;
    [SerializeField]
    private float maxDistance = 4;
    private CharacterController playerCapsule;
    private GameObject itemPickedUp;
    public GameObject mainCamera;
    public Vector3 shieldPos;
    //public GameObject poseParent;
    //private Vector3 pos;
    private PlayerHealth h;

    private void Start()
    {
        h = gameObject.GetComponent<PlayerHealth>();
        //pos = poseParent.transform.position;
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        playerCapsule = transform.GetComponentInChildren<CharacterController>();
    }

    void Update()
    {
        Vector3 direction = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, maxDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            if (hit.transform.gameObject.tag == "Shield" && Input.GetButtonDown("Cancel"))
            {
                h.SetShield(true);
                itemPickedUp = hit.transform.gameObject;
                hit.transform.SetParent(playerCapsule.transform);
                hit.transform.localPosition = Vector3.zero;
                hit.transform.localPosition = shieldPos;
                hit.transform.localScale = new Vector3(4, 4, 4);
                hit.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
                hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.gameObject.GetComponent<Collider>().enabled = false;
                mainCamera.GetComponent<Camera>().cullingMask = LayerMask.GetMask("TransparentFX", "UI", "Ignore Raycast", "Water", "Default");
                //pickUpItemCamera.gameObject.SetActive(true);
            }
        }
        if (Input.GetButtonDown("Fire2") && itemPickedUp)
        {
            h.SetShield(false);
            itemPickedUp.transform.SetParent(null);
            itemPickedUp.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
            itemPickedUp.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            itemPickedUp.transform.gameObject.GetComponent<Collider>().enabled = true;
            itemPickedUp.transform.localScale = new Vector3(9,9,9);
            itemPickedUp = null;
            //pickUpItemCamera.gameObject.SetActive(false);
            mainCamera.GetComponent<Camera>().cullingMask = -1;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            //starterAssetsInputs.pickUp = false;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            //starterAssetsInputs.drop = false;
        }
    }


}
