using UnityEngine;

public class PlaneRandomObjects : MonoBehaviour
{
    public GameObject RightHouse;

    public GameObject RightHouse1;
    public GameObject LeftHouse;

    public GameObject LeftHouse1;
    public GameObject RightObj;
    public GameObject LeftObj;

    

    public Mesh[] houseTypes = new Mesh[4];
    public Mesh[] ObjType = new Mesh[12];

    public float randomRangeHouse;
    public float randomRangeObj;
    
    [Header("Haus-Größen (für jedes Gebäude)")]
    public Vector3[] houseScales = new Vector3[4] // Größe für jedes Gebäude separat
    {
        new Vector3(0.2f, 0.2f, 0.2f),  // Größe für Gebäude 0
        new Vector3(0.2f, 0.2f, 0.2f),  // Größe für Gebäude 1
        new Vector3(0.2f, 0.2f, 0.2f),  // Größe für Gebäude 2
        new Vector3(0.2f, 0.2f, 0.2f)   // Größe für Gebäude 3
    };


    void Start()
    {
       
        


        randomRangeHouse = houseTypes.Length;
        randomRangeObj = ObjType.Length;

        // Jedes Haus bekommt eine eigene zufällige Mesh-Auswahl
        int randomHouseLeft = Random.Range(0, (int)randomRangeHouse);
        int randomHouseLeft1 = Random.Range(0, (int)randomRangeHouse);
        int randomHouseRight = Random.Range(0, (int)randomRangeHouse);
        int randomHouseRight1 = Random.Range(0, (int)randomRangeHouse);
        int randomObj = Random.Range(0, (int)randomRangeObj);



        // Prüfe ob MeshFilter-Komponenten vorhanden sind
        MeshFilter meshFilterRH = RightHouse?.GetComponent<MeshFilter>();
        MeshFilter meshFilterRH1 = RightHouse1?.GetComponent<MeshFilter>();
        MeshFilter meshFilterLH = LeftHouse?.GetComponent<MeshFilter>();
        MeshFilter meshFilterLH1 = LeftHouse1?.GetComponent<MeshFilter>();
        MeshFilter meshFilterRObj = RightObj?.GetComponent<MeshFilter>();
        MeshFilter meshFilterLObj = LeftObj?.GetComponent<MeshFilter>(); 
        
        
      
        
        // LeftHouse1 und RightHouse1 spawnen IMMER an ihrer gesetzten Position mit unterschiedlichen Häusern
        if (meshFilterLH1 != null && randomHouseLeft1 < houseTypes.Length)
        {
            meshFilterLH1.mesh = houseTypes[randomHouseLeft1];
            LeftHouse1.transform.localScale = houseScales[randomHouseLeft1]; // Größe abhängig vom Gebäude-Typ
            LeftHouse1.SetActive(true);
            Debug.Log("LeftHouse1 Mesh gesetzt auf: " + houseTypes[randomHouseLeft1].name);
        }

        if (meshFilterRH1 != null && randomHouseRight1 < houseTypes.Length)
        {
            meshFilterRH1.mesh = houseTypes[randomHouseRight1];
            RightHouse1.transform.localScale = houseScales[randomHouseRight1]; // Größe abhängig vom Gebäude-Typ
            RightHouse1.SetActive(true);
            Debug.Log("RightHouse1 Mesh gesetzt auf: " + houseTypes[randomHouseRight1].name);
        }

        // Entscheide ob normale Häuser oder Objekte spawnen
        if (ShouldSpawnHouses())
        {
            Debug.Log("Spawne Häuser - Deaktiviere Objekte");
            
            if (meshFilterRH != null && randomHouseRight < houseTypes.Length)
            {
                meshFilterRH.mesh = houseTypes[randomHouseRight];
                RightHouse.transform.localScale = houseScales[randomHouseRight]; // Größe abhängig vom Gebäude-Typ
                RightHouse.SetActive(true);
            }
            
            if (meshFilterLH != null && randomHouseLeft < houseTypes.Length)
            {
                meshFilterLH.mesh = houseTypes[randomHouseLeft];
                LeftHouse.transform.localScale = houseScales[randomHouseLeft]; // Größe abhängig vom Gebäude-Typ
                LeftHouse.SetActive(true);
            }
            
            RightObj?.SetActive(false);
            LeftObj?.SetActive(false);
        }
        else
        {
            Debug.Log("Spawne Objekte - Deaktiviere normale Häuser");
            
            if (meshFilterRObj != null && randomObj < ObjType.Length)
            {
                meshFilterRObj.mesh = ObjType[randomObj];
                RightObj.SetActive(true);
            }
            
            if (meshFilterLObj != null && randomObj < ObjType.Length)
            {
                meshFilterLObj.mesh = ObjType[randomObj];
                LeftObj.SetActive(true);
            }
            
            RightHouse?.SetActive(false);
            LeftHouse?.SetActive(false);
        }
    }
    
    // Methode um zu entscheiden ob Häuser oder Objekte gespawnt werden sollen
    private bool ShouldSpawnHouses()
    {
        // 50% Chance für Häuser, 50% für Objekte
        return Random.Range(0f, 1f) > 0.5f;
    }
}
