using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    [HideInInspector]
    public Player character;
    public PlayerController playerController;
    public Image meterImage;
    public Text trasText;   // Texto para basura
    public Text objectText; // Texto para objetos
    public Text timerText;

    private int basura = 0;
    private int objetos = 0;

    [Header("Configuración del tiempo")]
    public float tiempoTotal = 90f;
    public float dañoPorSegundo = 1.11f;

    private float tiempoRestante;
    private bool vidaQuitada = false;

    void Start()
    {
        tiempoRestante = tiempoTotal;

        if (character != null)
        {
            character.hitPoints.value = character.maxHitPoints;
        }

        ActualizarBasura(0);
        ActualizarObjetos(0);
        ActualizarTimer();
    }

    void Update()
    {
        if (character != null)
        {
            meterImage.fillAmount = character.hitPoints.value / character.maxHitPoints;

            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;

                if (tiempoRestante <= 0)
                    tiempoRestante = 0;

                ActualizarTimer();

                // Reducir vida
                character.hitPoints.value -= dañoPorSegundo * Time.deltaTime;

                if (character.hitPoints.value < 0)
                    character.hitPoints.value = 0;
            }

            if (tiempoRestante <= 0 && !vidaQuitada)
            {
                vidaQuitada = true;

                if (playerController != null)
                {
                    playerController.ReducirVida(1);
                }
                StartCoroutine(ReiniciarNivel());
            }
        }
    }

    // NUEVO MÉTODO: Reducir tiempo del timer
    public void ReducirTiempo(float segundos)
    {
        tiempoRestante -= segundos;

        // Asegurar que no sea negativo
        if (tiempoRestante < 0)
            tiempoRestante = 0;

        ActualizarTimer();

        // También reducir la vida proporcionalmente
        if (character != null)
        {
            character.hitPoints.value -= dañoPorSegundo * segundos;
            if (character.hitPoints.value < 0)
                character.hitPoints.value = 0;
        }
    }

    public void ActualizarBasura(int cantidad)
    {
        basura = Mathf.Clamp(cantidad, 0, 10);
        trasText.text = basura + "/ 10";
    }

    public void ActualizarObjetos(int cantidad)
    {
        objetos = Mathf.Clamp(cantidad, 0, 10);
        objectText.text = objetos + "/ 10";
    }

    void ActualizarTimer()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);

        timerText.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    public void AumentarTiempo(float segundos)
    {
        tiempoRestante += segundos;

        if (tiempoRestante > tiempoTotal)
            tiempoRestante = tiempoTotal;

        // Aumentar vida proporcional al tiempo que se agregó
        if (character != null)
        {
            character.hitPoints.value += dañoPorSegundo * segundos;

            if (character.hitPoints.value > character.maxHitPoints)
                character.hitPoints.value = character.maxHitPoints;
        }

        ActualizarTimer();
    }

    IEnumerator ReiniciarNivel()
    {
        // Evita que se ejecute más de una vez
        vidaQuitada = true;

        // Activar animación del jugador
        if (playerController != null)
            playerController.ActivarAnimacionTiempoTerminado();

        // Esperar 1.5 segundos (ajústalo según tu animación)
        yield return new WaitForSeconds(1.5f);

        // Reiniciar escena actual
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
}