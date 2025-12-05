using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterSelector : MonoBehaviour
{
    public void SeleccionarPersonaje(int index)
    {
        // Guarda el personaje seleccionado (por ejemplo, 0, 1 o 2)
        PlayerPrefs.SetInt("PersonajeSeleccionado", index);
        PlayerPrefs.Save();
        // Cargar la escena del juego
        SceneManager.LoadScene("Nivel1");
    }
}
