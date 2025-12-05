using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vida = 3;
    public float runSpeed = 2;
    public float jumpSpeed = 3;

    public Animator animator;



    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            vida -= 1;
            Destroy(collision.gameObject);
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReducirVida(int cantidad)
    {
        vida -= cantidad;
        if (vida < 0) vida = 0;

        Debug.Log("Vida actual: " + vida);

    }
    public void ActivarAnimacionTiempoTerminado()
    {
        if (animator != null)
        {
            animator.SetTrigger("TiempoTerminado");
        }
    }


}
