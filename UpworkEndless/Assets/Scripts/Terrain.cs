using UnityEngine;

public class Terrain : MonoBehaviour
{
public GameObject player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    void Update()
    {
        transform.position = new Vector3(-500, -1, player.transform.position.z - 500);
    }
}
