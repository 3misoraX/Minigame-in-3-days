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
        //movement and rotation, always towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        //Damaging the player
       if(collision.gameObject.CompareTag("Player") == true)
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.TakeDmg();
        }
       //Damaging the enemy
       else if(collision.gameObject.name == "Disc(Clone)")
        {
            Destroy(this.gameObject);
        }
    }
}
