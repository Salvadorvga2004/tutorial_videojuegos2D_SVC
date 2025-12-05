using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TuristaController : MonoBehaviour
{
    public int totalObjetosTipicos = 10;
    public int totalBasura = 10;

    [TextArea]
    public string dialogoInicial = "Hola soy un turista visitando este pueblo mágico. Estoy buscando los objetos típicos de este pueblo, me puedes ayudar?";

    [TextArea]
    public string dialogoFaltanCosas = "Seguro que ya son todas las cosas típicas?";

    [TextArea]
    public string dialogoFaltanBasura = "Seguro que ya recogiste toda la basura?";

    [TextArea]
    public string dialogoCompletado = "¡Excelente! Ya tienes todos los objetos típicos y recogiste toda la basura. Puedes pasar al siguiente nivel.";

    private bool yaMostroDialogoInicial = false;

    public string RevisarObjetos(Player player)
    {
        string mensaje = "";

        // Primera interacción
        if (!yaMostroDialogoInicial)
        {
            yaMostroDialogoInicial = true;
            mensaje = dialogoInicial;
            Debug.Log(mensaje);
            return mensaje;
        }

        // Objetos típicos faltantes
        if (player.ObjectCount < totalObjetosTipicos)
        {
            mensaje = dialogoFaltanCosas;
            Debug.Log(mensaje);
            return mensaje;
        }

        // Basura faltante
        if (player.TrashCount < totalBasura)
        {
            mensaje = dialogoFaltanBasura;
            Debug.Log(mensaje);
            return mensaje;
        }

        // COMPLETADO
        mensaje = dialogoCompletado;
        Debug.Log(mensaje);

        // Iniciar corrutina para cambiar de nivel después de 2 segundos
        StartCoroutine(CambiarDeNivelConDelay());

        return mensaje;
    }

    private IEnumerator CambiarDeNivelConDelay()
    {
        // Espera 2 segundos (puedes ajustar el tiempo)
        yield return new WaitForSeconds(3f);

        // Cargar siguiente nivel
        PlayerPrefs.SetInt("Nivel", 2);
        SceneManager.LoadScene("SceneTransition");

    }
}
