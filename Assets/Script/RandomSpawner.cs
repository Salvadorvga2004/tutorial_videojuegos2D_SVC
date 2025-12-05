using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabs;   // Lista de prefabs para spawnear
    public int cantidad = 5;       // Cuántos objetos quieres generar

    public Vector2 area = new Vector2(5, 5); // Rango de spawn (X, Y)

    void Start()
    {
        SpawnObjetos();
    }

    void SpawnObjetos()
    {
        for (int i = 0; i < cantidad; i++)
        {
            // Seleccionar un prefab aleatorio
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            // Crear posición aleatoria en 2D (X, Y)
            Vector3 pos = new Vector3(
                transform.position.x + Random.Range(-area.x, area.x),
                transform.position.y + Random.Range(-area.y, area.y),
                0 // z fijo porque es 2D
            );

            // Instanciar prefab
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}
