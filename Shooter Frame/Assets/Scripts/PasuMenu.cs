using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PasuMenu : MonoBehaviour
{
    
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject ThePlayer;
    public GameObject ShootPoint;
    private bool muted = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {

                Resume();
            }
            else
            {
                Cursor.visible = true;
                Pause();
            }

        }
        
    }

    public void Resume()
    {
        ShootPoint.GetComponent<Pistol>().enabled = true;
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;


    }

    void Pause()
    {
        ShootPoint.GetComponent<Pistol>().enabled = false;
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MuteMusic()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;

        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

    }

    public void IrMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
