using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool pasarNivel;
    public int indiceNivel;   // Nivel al que quieres ir

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IrConTransicion(indiceNivel);
        }

        if (pasarNivel)
        {
            IrConTransicion(indiceNivel);
        }
    }

    public void IrConTransicion(int indice)
    {
        // Guardar qué nivel queremos cargar después de la transición
        PlayerPrefs.SetInt("Nivel", indice);

        // Cargar escena de transición
        SceneManager.LoadScene("SceneTransition");
    }
}