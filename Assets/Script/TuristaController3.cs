using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TuristaController3 : MonoBehaviour
{
    public int totalObjetosTipicos = 10;
    public int totalBasura = 10;

    [TextArea]
    public string dialogoFaltanCosas = "Hola, ya recogiste todo?";

    [TextArea]
    public string dialogoFaltanBasura = "Ya recogiste toda la basura?";

    [TextArea]
    public string dialogoCompletado = "Muchas Gracias Amigo, gracias a ti podre regresar a mi pais con muchos recuerdos, te lo agradezco";


    public string RevisarObjetos(Player player)
    {
        string mensaje = "";

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
        SceneManager.LoadScene("Felicidades");
    }
}
