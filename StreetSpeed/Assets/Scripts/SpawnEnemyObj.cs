using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemyObj : MonoBehaviour
{
public Transform[] spawnPoints = new Transform[3];
public GameObject[] spawnEnemyObj = new GameObject[5];

public int RandomObj;
public int RandomPos;

public float speedCars = 4f;
public float minSpawnDistance = 15f; // Minimaler Abstand zwischen Autos

private GameObject Go;

public int index;
public GameObject player;

// Statisches System um zu tracken welche Spuren blockiert sind
private static int lastBlockedLane = -1; // -1 = keine, 0-2 = Spur-Index
private static float lastSpawnZPosition = -1000f; // Z-Position des letzten gespawnten Autos
private static int consecutiveSpawns = 0; // Zählt aufeinanderfolgende Spawns

    void Awake()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        // Berechne aktuelle Z-Position
        float currentZPosition = transform.position.z;
        
        // Prüfe ob genug Abstand zum letzten Auto ist
        bool hasEnoughDistance = (currentZPosition - lastSpawnZPosition) >= minSpawnDistance;
        
        // Reduziere Spawn-Chance wenn bereits mehrere Autos hintereinander gespawnt wurden
        float spawnChance = 0.7f;
        if(consecutiveSpawns >= 2)
        {
            spawnChance = 0.3f; // Nur 30% Chance nach 2 aufeinanderfolgenden Spawns
        }
        else if(consecutiveSpawns >= 1)
        {
            spawnChance = 0.5f; // 50% Chance nach 1 Spawn
        }
        
        bool canSpawn = Random.Range(0f, 1f) < spawnChance && hasEnoughDistance;

        if(canSpawn && spawnPoints.Length > 0 && spawnEnemyObj.Length > 0)
        {
            // Bestimme welche Spuren verfügbar sind
            List<int> availableLanes = new List<int>();
            
            for(int i = 0; i < spawnPoints.Length; i++)
            {
                availableLanes.Add(i);
            }
            
            // Wenn die letzte Spur blockiert war, entferne sie aus den verfügbaren Spuren
            if(lastBlockedLane != -1 && availableLanes.Contains(lastBlockedLane))
            {
                availableLanes.Remove(lastBlockedLane);
            }
            
            // Wenn es verfügbare Spuren gibt, wähle eine zufällige
            if(availableLanes.Count > 0)
            {
                RandomPos = availableLanes[Random.Range(0, availableLanes.Count)];
                RandomObj = Random.Range(0, spawnEnemyObj.Length);
                
                Go = Instantiate(spawnEnemyObj[RandomObj], spawnPoints[RandomPos].position, Quaternion.Euler(0, 180, 0));
                Go.transform.SetParent(this.transform);
                
                // Merke dir dass diese Spur jetzt blockiert ist
                lastBlockedLane = RandomPos;
                lastSpawnZPosition = currentZPosition;
                consecutiveSpawns++;
            }
            else
            {
                // Wenn keine Spuren verfügbar sind, resette das System
                lastBlockedLane = -1;
                consecutiveSpawns = 0;
            }
        }
        else
        {
            // Kein Auto gespawnt, resette die blockierte Spur und reduziere Counter
            lastBlockedLane = -1;
            consecutiveSpawns = 0;
        }
    }
    
    void OnDestroy()
    {
        // Wenn dieses Plane zerstört wird und es das Auto enthält, resette lastBlockedLane
        if(Go != null && lastBlockedLane == RandomPos)
        {
            lastBlockedLane = -1;
        }
    }

}
