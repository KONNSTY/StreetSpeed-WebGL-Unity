using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

public GameObject canvasObj;
   public GameObject TextHighTXP;
   public Button LoadGame;
   public Button Quiet;
   public Button Sound;

   public Sprite SoundOnIm;
   public Sprite SoundOffIm;

   private bool isMuted = false;

    void Start()
    {
        if(canvasObj != null)
        {
            TextHighTXP = canvasObj.transform.GetChild(2).gameObject;
            
            if(TextHighTXP != null)
            {
                int lastScore = PlayerPrefs.GetInt("LastScore", 0);
                TextHighTXP.GetComponent<TextMeshProUGUI>().text = lastScore.ToString();
            }
        }
        
        // Initialisiere Sound Button Sprite
        UpdateSoundButton();
    }

    public void LoadTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuietGame()
    {
        Application.Quit();
    }

    private void UpdateSoundButton()
    {
        if(Sound != null && Sound.image != null)
        {
            Sound.image.sprite = isMuted ? SoundOffIm : SoundOnIm;
        }
    }

    public void SwitcbSound()
    {
        isMuted = !isMuted;
        AudioManger.MuteGame(isMuted);
        UpdateSoundButton();
    }

   }

