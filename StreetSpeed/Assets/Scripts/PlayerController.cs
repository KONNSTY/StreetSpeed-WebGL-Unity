using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Bewegung")]
    public GameObject[] Arrows = new GameObject[3];
    public float speed = 10f;

    public float addspeed = 2f;

    public float speedIncreaseMilestone = 100f;

    


    public int ValueofPos = 2;
    
    [Header("Sprung")]
    public Rigidbody rb;
    public float jumpForce = 2f; // Erhöht für deutlichen Sprung
    
  public GameObject GunFx;
  public GameObject GunFx1;


    public float MaxSpeedIncrease = 100000f;

    private bool isGrounded;
    private bool hasJumped = false; // Verhindert mehrfaches Springen

    public GameObject playerSkin;
    public Animator playerAnimator;

    public static bool isGameOver = false;

    private bool cantMoveCauseDead = false;

    public GameObject DistanceMessureObj;
    public float DistanceMessureDistance;

    public static float Energy = 100f;


    void Start()
    {
        cantMoveCauseDead = false;
        rb = GetComponent<Rigidbody>();
        
        // Fallback: Wenn kein groundCheck zugewiesen, erstelle eins
     
        if(playerSkin == null)
        {
            playerSkin = transform.GetChild(1).gameObject;
        }

        if(playerAnimator == null)
        {
            playerAnimator = playerSkin.GetComponent<Animator>();
        }


if(GunFx != null && GunFx1 != null)
        {
        GunFx.SetActive(false);
        GunFx1.SetActive(false);

        
    }
    }

    void Update()
    {
DistanceMessureDistance = Vector3.Distance(transform.position, DistanceMessureObj.transform.position);

if(speedIncreaseMilestone < DistanceMessureDistance && DistanceMessureDistance < MaxSpeedIncrease)
{
    speedIncreaseMilestone += speedIncreaseMilestone;
    speed += addspeed;
    Debug.Log(">>> SPEED ERHÖHT! Neue Geschwindigkeit: " + speed);
}

        // Ground Check - prüft ob Spieler am Boden ist
       
        
   

if(cantMoveCauseDead == false)
        {
            
        
        // Lane switching
        if (Input.GetKeyDown(KeyCode.A) && ValueofPos > 1)
        {
            ValueofPos--;
        }

        if (Input.GetKeyDown(KeyCode.D) && ValueofPos < 3)
        {
            ValueofPos++;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ValueofPos = 2;
        }
        
        }

        if(Energy <= 100f)
        {
            Energy += 50f * Time.deltaTime;
        }

        // Waffen-System
        if(Input.GetKey(KeyCode.Space))
        {
            if(Energy > 90)
            {   
                GunFx.SetActive(true);
                GunFx1.SetActive(true);

                RaycastHit hitInfo1;
                if(Physics.Raycast(transform.position, Vector3.left, out hitInfo1, 100f))
                {
                    if(hitInfo1.collider.CompareTag("Car"))
                    {
                        hitInfo1.collider.GetComponent<Rigidbody>().AddForce(Vector3.left * 100, ForceMode.Impulse);
                    }
                }  
                
                RaycastHit hitInfo2;
                if(Physics.Raycast(transform.position, Vector3.right, out hitInfo2, 100f))
                {
                    if(hitInfo2.collider.CompareTag("Car"))
                    {
                        hitInfo2.collider.GetComponent<Rigidbody>().AddForce(Vector3.right * 100, ForceMode.Impulse);
                    }
                }
                Energy = 0;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            GunFx.SetActive(false);
            GunFx1.SetActive(false);
        }
    } // Ende von Update()

    void FixedUpdate()
    {
        // Lane Position setzen - NUR mit Velocity, NICHT mit MovePosition!
        Vector3 currentVel = rb.linearVelocity;
        
        // Berechne Ziel-X-Position
        float targetX = 0;
        if (ValueofPos == 1)
        {
            targetX = Arrows[0].transform.position.x;
        }
        else if (ValueofPos == 2)
        {
            targetX = Arrows[1].transform.position.x;
        }
        else if (ValueofPos == 3)
        {
            targetX = Arrows[2].transform.position.x;
        }
        
        // Setze nur X-Velocity für Lane-Wechsel, behalte Y (Sprung) bei!
        float xDifference = targetX - transform.position.x;
        currentVel.x = xDifference * 10f; // Schneller Lane-Wechsel
        currentVel.z = speed; // Konstante Vorwärts-Geschwindigkeit
        // currentVel.y bleibt unverändert für Sprünge!
        
        rb.linearVelocity = currentVel;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1,1) * 1000f * Time.deltaTime, ForceMode.Impulse);
            cantMoveCauseDead = true;
            playerAnimator.SetBool("IsDead", true);
            StartCoroutine(WaitTillEnd(0.8f));
            
        }
    }
    IEnumerator WaitTillEnd(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        PlayerPrefs.SetInt("LastScore", PlaneSpawner.Points);
        PlayerPrefs.Save();
        Debug.Log(PlaneSpawner.Points + " :TotalPoints");
        Time.timeScale = 0f;
       
    }


}