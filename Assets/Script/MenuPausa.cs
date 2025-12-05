using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject botonOpciones;
    [SerializeField] private GameObject basura;
    [SerializeField] private GameObject objetos;
    [SerializeField] private GameObject tiempo;
    [SerializeField] private GameObject vida;
    public void Pausa()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
        botonOpciones.SetActive(false);
        basura.SetActive(false);
        objetos.SetActive(false);
        tiempo.SetActive(false);
        vida.SetActive(false);
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        botonOpciones.SetActive(true);
        basura.SetActive(true);
        objetos.SetActive(true);
        tiempo.SetActive(true);
        vida.SetActive(true);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicio");
    }
}
