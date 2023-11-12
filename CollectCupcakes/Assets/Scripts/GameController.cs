using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cupcakePrefab;
    public GameObject platePrefab;
    public int cupcakesToCollect = 10;
    public int cupcakesCollected = 0;  

    void Start()
    {
        Instantiate(platePrefab, new Vector3(0, -4, 0), Quaternion.identity);

        StartCoroutine(SpawnCupcakes());
    }

    IEnumerator SpawnCupcakes()
    {
        while (cupcakesToCollect > 0)
        {
            float randomX = Random.Range(-5f, 5f);
            Instantiate(cupcakePrefab, new Vector3(randomX, 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void CupcakeCollected()
    {
        cupcakesCollected++;

        if (cupcakesCollected >= cupcakesToCollect)
        {
            Debug.Log("You collected all cupcakes! Game Over!");
            EndGame();
        }
    }

    void EndGame()
    {
        StopAllCoroutines();
    }
}
