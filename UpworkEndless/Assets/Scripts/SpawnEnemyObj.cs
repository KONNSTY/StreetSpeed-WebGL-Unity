using UnityEngine;

public class SpawnEnemyObj : MonoBehaviour
{
public Transform[] spawnPoints = new Transform[3];
public GameObject[] spawnEnemyObj = new GameObject[5];

private bool canspawn;

public int RandomObj;
public int RandomPos;

public float speedCars = 4f;

private GameObject Go;

public int index;
public GameObject player;




    void Awake()
    {
if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

      int canspawnInt = Random.Range(0, 2);

        if(canspawnInt == 0)
        {
            canspawn = false;
        }
        else
        {
            canspawn = true;
        }

        if(canspawn == true)
        {
RandomObj = Random.Range(0, spawnEnemyObj.Length);
RandomPos = Random.Range(0, spawnPoints.Length);

           Go = Instantiate(spawnEnemyObj[RandomObj], spawnPoints[RandomPos].position, Quaternion.Euler(0, 180, 0));
           Go.transform.SetParent(this.transform);
 
        }
    }

}
