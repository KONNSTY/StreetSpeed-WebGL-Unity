using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
   public GameObject TextHigh;
   public TextMeshPro TextHighTXP;
   public Button LoadGame;
   public Button Quiet;
   public Button Sound;

   public Image SoundOnIm;
   public Image SoundOffIm;

   public bool soundbool;

public void LoadTheGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuietGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if(soundbool == false)
        {
            SoundImageSwitch(SoundOnIm);

        }else
        {
            SoundImageSwitch(SoundOffIm);
        }
    }

    private void SoundImageSwitch(Image soundimage)
    {
      
        Sound.image = soundimage;
    }

    public void SwitcbSound()
    {
        soundbool = !soundbool;
    }

   }

