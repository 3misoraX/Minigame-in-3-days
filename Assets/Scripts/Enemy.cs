using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private GameObject player;
    private Vector3 dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Player") == true)
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.TakeDmg();
        }
       else if(collision.gameObject.name == "Disc(Clone)")
        {
            //Destroying the enemy
            //Make a particle effect
            //Destroy after some time
            Destroy(this.gameObject);
        }
    }
}
