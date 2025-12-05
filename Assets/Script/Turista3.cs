using UnityEngine;

public class Turista3 : MonoBehaviour
{
    private TuristaController3 turista;
    private bool cercaDelTurista = false;
    private Player player;

    void Start()
    {
        turista = GetComponent<TuristaController3>();
    }

    void Update()
    {
        if (cercaDelTurista && Input.GetKeyDown(KeyCode.E))
        {
            turista.RevisarObjetos(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();
            cercaDelTurista = true;
            Debug.Log("Presiona E para hablar con el turista");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cercaDelTurista = false;
        }
    }
}
