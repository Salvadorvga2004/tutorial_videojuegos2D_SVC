using UnityEngine;
public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] personajes; // Asigna los prefabs de los personajes en el Inspector
 
    void Start()
    {
        int index = PlayerPrefs.GetInt("PersonajeSeleccionado", 0);
        Instantiate(personajes[index],
       personajes[index].transform.position, Quaternion.identity);
    }
}
