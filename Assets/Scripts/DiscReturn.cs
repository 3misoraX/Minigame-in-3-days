using UnityEngine;
using UnityEngine.InputSystem;

public class DiscReturn : MonoBehaviour
{
    private DiscShoot ds;
    private float timer = 5f;
    public InputActionReference shoot;

    void Awake()
    {
        ds = GameObject.Find("Main Camera").GetComponent<DiscShoot>();
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
}
