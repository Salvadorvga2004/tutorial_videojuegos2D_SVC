using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;

    private Vector3 startPos;
    private bool movingRight = true;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            // Voltear mirando a la derecha
            transform.localScale = new Vector3(1, 1, 1);

            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            // Voltear mirando a la izquierda
            transform.localScale = new Vector3(-1, 1, 1);

            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;
        }
    }
}
