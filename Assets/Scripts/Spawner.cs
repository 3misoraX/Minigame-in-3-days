using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    private float timer;
    public int maxRand = 10;
    public int minRand = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //timer starts in a random amount
        timer = Random.Range(minRand, maxRand);
    }

    // Update is called once per frame
    void Update()
    {
        //countdown to 0
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            //When 0, spawns an enemy
            timer = Random.Range(minRand, maxRand);
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }
}
