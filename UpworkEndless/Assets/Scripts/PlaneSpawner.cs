using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
public static int Points;

    public GameObject player;
    public GameObject plane;

    public GameObject DistaneT;

    public int loopValue = 10;

    public float planeSpacing = 10f; // Abstand zwischen den Planes
    
    private Vector3 nextSpawnPosition;




    void Start()
    {
        // Setze die erste Spawn-Position
        nextSpawnPosition = plane.transform.position;
        SpawnPlane();
    }

    void SpawnPlane()
    {
        for (int i = 0; i < 20; i++)
        {
            // Spawne jedes Plane mit korrektem Abstand
            Vector3 spawnPos = new Vector3(nextSpawnPosition.x, nextSpawnPosition.y, nextSpawnPosition.z + (i * planeSpacing));
            Instantiate(Resources.Load("Plane"), spawnPos, Quaternion.identity);
        }
        
        // Update die nächste Spawn-Position für das nächste Set von Planes
        nextSpawnPosition.z += loopValue * planeSpacing;
    }

    void Update()
    {
        float distancePD = Vector3.Distance(DistaneT.transform.position, player.transform.position);
        float towlessthanloopValue = loopValue - 2;
        if(distancePD < towlessthanloopValue)
        {
            // Update DistaneT Position für die nächste Überprüfung
            DistaneT.transform.position = new Vector3(DistaneT.transform.position.x, DistaneT.transform.position.y, nextSpawnPosition.z);
            SpawnPlane();
        }
    }





}
