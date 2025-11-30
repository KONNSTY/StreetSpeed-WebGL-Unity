using TMPro;
using UnityEngine;

public class PlaneDestroy : MonoBehaviour
{
   public GameObject player;

    private bool isCollided = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isCollided = true;
        }
    }

    void Update()
    {
        if (isCollided)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer > 12f)
            {
                Destroy(gameObject);
                isCollided = false; // Reset the flag to prevent multiple destructions
            }
        }
    }



}
