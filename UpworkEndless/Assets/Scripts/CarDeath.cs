using UnityEngine;

public class CarDeath : MonoBehaviour
{

public float speed = 50f;
private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    void Update()
    {
rb.linearVelocity = transform.forward * speed;
    }
}
