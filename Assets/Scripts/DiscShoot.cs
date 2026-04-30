using UnityEngine;
using UnityEngine.InputSystem;

public class DiscShoot : MonoBehaviour
{
    public float force = 100f;
    public GameObject disc;
    [SerializeField] private InputActionReference shootAction;
    public Transform shootPoint;
    public bool hasDisc = true;
    public GameObject ico;
    // Update is called once per frame
    void Update()
    {
        //detectar input si se puede lanzar el disco
        if (shootAction.action.triggered && hasDisc)
        {
            //lanzar el disco
            GameObject projectile = Instantiate(disc, shootPoint.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward*force, ForceMode.VelocityChange);
            hasDisc = false;
        }

        if (!hasDisc)
        {
            ico.SetActive(false);
        }
        else
        {
            ico.SetActive(true);
        }
    }
}
