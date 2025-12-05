using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public HealthBar healthBarPrefab;
    private HealthBar healthBar;

    private int trashCount = 0;
    private int objectCount = 0;

    public int TrashCount => trashCount;
    public int ObjectCount => objectCount;

    private void Start()
    {
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
            if (hitObject != null)
            {
                bool shouldDisappear = false;

                switch (hitObject.itemType)
                {
                    case Item.ItemType.TRASH:
                        trashCount += hitObject.quantity;
                        healthBar.ActualizarBasura(trashCount);
                        shouldDisappear = true;
                        break;

                    case Item.ItemType.OBJECT:
                        objectCount += hitObject.quantity;
                        healthBar.ActualizarObjetos(objectCount);

                        // SUMAR 3 SEGUNDOS POR CADA OBJETO
                        healthBar.AumentarTiempo(3f);

                        shouldDisappear = true;
                        break;

                    case Item.ItemType.DAMANGE:
                        // NUEVO: Reducir tiempo en lugar de aplicar daño directo
                        shouldDisappear = ApplyTimeDamage(hitObject.quantity);
                        break;
                }

                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    // NUEVO MÉTODO: Aplicar daño reduciendo tiempo
    private bool ApplyTimeDamage(int amount)
    {
        // Por cada unidad de cantidad, restar 5 segundos
        float segundosARestar = amount * 5f;

        if (healthBar != null)
        {
            healthBar.ReducirTiempo(segundosARestar);
        }

        Debug.Log("Reduciendo tiempo: -" + segundosARestar + " segundos");
        return true;
    }

    // Método original mantenido por si acaso
    private bool ApplyDamage(int amount)
    {
        hitPoints.value -= amount;
        if (hitPoints.value < 0)
            hitPoints.value = 0;

        Debug.Log("Reduciendo vida: -" + amount + " → Vida actual: " + hitPoints.value);
        return true;
    }
}