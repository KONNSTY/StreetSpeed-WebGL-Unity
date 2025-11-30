using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayUi : MonoBehaviour
{
public void LoadTheGame()
    {
Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
