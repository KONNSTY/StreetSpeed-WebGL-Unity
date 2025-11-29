using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
 
    private Transform player;
    public GameObject PlayerGO;
    public float distanceToPlayer = 10f;

    void Start()
    {
        if (player == null)
        {
          PlayerGO = GameObject.FindWithTag("Player");
          player = PlayerGO.transform;  
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z - distanceToPlayer);
    }
}
