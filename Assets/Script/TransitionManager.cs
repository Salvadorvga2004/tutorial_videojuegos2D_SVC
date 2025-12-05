using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class TransitionManager : MonoBehaviour
{
    public TextMeshProUGUI textoNivel;
    public float duracion = 5f;

    void Start()
    {
        StartCoroutine(Transicion());
    }

    IEnumerator Transicion()
    {
        int nivelDestino = PlayerPrefs.GetInt("Nivel", 1);

        textoNivel.text = "Nivel " + nivelDestino;

        yield return new WaitForSeconds(duracion);

        SceneManager.LoadScene(nivelDestino);
    }
}
