using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EscenaJuego(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void BotonVolver(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir() {
        Application.Quit();
    }

    public void Instrucciones(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
