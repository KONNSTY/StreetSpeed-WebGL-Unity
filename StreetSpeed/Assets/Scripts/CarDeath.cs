using UnityEngine;

public class CarDeath : MonoBehaviour
{

public float speed;
private Rigidbody rb;
    void Start()
    {
        speed = 10f;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.back * speed * Time.fixedDeltaTime);
    }


}
