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
    public GameObject poseParent;
    private Vector3 pos;
    //public GameObject pickUpItemCamera;

    private void Start()
    {
        pos = poseParent.transform.position;
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
            if (hit.transform.gameObject.tag == "Shield" && starterAssetsInputs.pickUp)
            {
                itemPickedUp = hit.transform.gameObject;
                hit.transform.SetParent(playerCapsule.transform);
                hit.transform.localPosition = Vector3.zero;
                hit.transform.localPosition = pos;
                hit.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                mainCamera.GetComponent<Camera>().cullingMask = LayerMask.GetMask("TransparentFX", "UI", "Ignore Raycast", "Water", "Default");
                //pickUpItemCamera.gameObject.SetActive(true);
            }
        }
        if (starterAssetsInputs.drop && itemPickedUp)
        {
            itemPickedUp.transform.SetParent(null);
            itemPickedUp.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
            itemPickedUp.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            itemPickedUp = null;
            //pickUpItemCamera.gameObject.SetActive(false);
            mainCamera.GetComponent<Camera>().cullingMask = -1;
        }
        if (starterAssetsInputs.pickUp)
        {
            starterAssetsInputs.pickUp = false;
        }
        if (starterAssetsInputs.drop)
        {
            starterAssetsInputs.drop = false;
        }
    }
}
