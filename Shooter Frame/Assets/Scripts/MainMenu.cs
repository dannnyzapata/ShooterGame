using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    


    public void EscenaJuego()
    {
        SceneManager.LoadScene("Main Level");
    }

    public void CargarOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
