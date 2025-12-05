using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    public float tiempoARestar = 3f;
    private bool puedeHacerDaño = true;
    public float cooldownDaño = 1f; // evita que quite tiempo cada frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && puedeHacerDaño)
        {
            Player player = collision.GetComponent<Player>();

            if (player != null && player.healthBarPrefab != null)
            {
                // Acceso al healthbar instanciado
                HealthBar bar = FindObjectOfType<HealthBar>();
                bar.ReducirTiempo(tiempoARestar);
            }

            // Evitar daño continuo
            StartCoroutine(ReiniciarDaño());
        }
    }

    private IEnumerator ReiniciarDaño()
    {
        puedeHacerDaño = false;
        yield return new WaitForSeconds(cooldownDaño);
        puedeHacerDaño = true;
    }
}
