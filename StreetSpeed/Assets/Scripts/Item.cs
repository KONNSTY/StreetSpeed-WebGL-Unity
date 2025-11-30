using UnityEngine;

public class Item : MonoBehaviour
{
    void Start()
    {
       int randombool = Random.Range(0,2);

       if(randombool == 0)
       {
      gameObject.SetActive(false);
       
       }else if(randombool == 1)
       {
      gameObject.SetActive(true);
     
    }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlaneSpawner.Points += 1;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}
