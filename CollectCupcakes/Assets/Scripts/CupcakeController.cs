using UnityEngine;

public class CupcakeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plate")
        {
            Destroy(gameObject);
            GameController gameController = FindObjectOfType<GameController>();
            gameController.cupcakesToCollect--;
            gameController.cupcakesCollected++;

            if (gameController.cupcakesToCollect <= 0)
            {
                Debug.Log("You collected all cupcakes! Game Over!");
                // You can add game over logic here.
            }
        }
    }

    void Update()
    {
        transform.Translate(Vector3.down * 3f * Time.deltaTime);

        // Destroy cupcake if it goes out of screen
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
