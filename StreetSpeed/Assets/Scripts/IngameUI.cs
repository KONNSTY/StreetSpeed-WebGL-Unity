
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
public bool isPaused = false;

public Canvas canvas1;
public Canvas canvas2;

public Image Energy;
public TextMeshProUGUI ScoreText;
public GameObject TextObj;

public Image MusicSwitch;

public Sprite imageMuteON;
public Sprite imageMuteOFF;

[HideInInspector] public bool switchImage;

private bool isMuted = false;

    void Start()
    {
canvas1.enabled = true;
canvas2.enabled = false;

        if(TextObj != null)
        {
            ScoreText = TextObj.GetComponent<TextMeshProUGUI>();
        }
        
        // Initialisiere Music Button Sprite
        UpdateMusicButton();
    }

    void Update()
    {
        if(Energy != null)
        {
            Energy.fillAmount = PlayerController.Energy / 100f;
        }

        if(PlayerController.isGameOver)
        {
            if(canvas1 != null) canvas1.enabled = false;
            if(canvas2 != null) canvas2.enabled = false;
        }

        if(ScoreText != null)
        {
            ScoreText.text = PlaneSpawner.Points.ToString();
        }
    }






    public void OnPause()
    {
        isPaused = !isPaused;
        switchImage = !switchImage;

        if(!isPaused)
        {
            Time.timeScale = 1f;
        }else
        {
            Time.timeScale = 0f;
        }
        
        if(canvas1 != null) canvas1.enabled = !isPaused;
        if(canvas2 != null) canvas2.enabled = isPaused;
    }





    public void SwitchSound()
    {
        isMuted = !isMuted;
        AudioManger.MuteGame(isMuted);
        UpdateMusicButton();
    }
    
    private void UpdateMusicButton()
    {
        if(MusicSwitch != null)
        {
            MusicSwitch.sprite = isMuted ? imageMuteOFF : imageMuteON;
        }
    }
}
