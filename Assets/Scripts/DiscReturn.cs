using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiscReturn : MonoBehaviour
{
    private DiscShoot ds;
    private float timer = 5f;
    public InputActionReference shoot;
    private Transform shootpoint;
    private Vector3 direction;
    private Rigidbody rb;

    void Awake()
    {
        ds = GameObject.Find("Main Camera").GetComponent<DiscShoot>();
        shootpoint = GameObject.Find("Main Camera").GetComponentInChildren<Transform>();
        direction = Vector3.forward;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
         
        timer -= Time.deltaTime;
        if(timer <= 0 || shoot.action.triggered)
        {
            ds.hasDisc = true;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var contact = collision.contacts[0];
        Vector3 newVel = Vector3.Reflect(direction.normalized, contact.normal);
        rb.AddForce(ds.force * newVel, ForceMode.Impulse);
    }
}
