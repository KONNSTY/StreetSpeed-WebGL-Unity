using UnityEngine;

public class IngameUI : MonoBehaviour
{
public bool isPaused = false;

public Canvas canvas1;
public Canvas canvas2;


    void Update()
    {
        if(isPaused == false)
        {
            Time.timeScale = 1f;
        }else if(isPaused == true)
        {
            Time.timeScale = 0f;
        }
    }
}
