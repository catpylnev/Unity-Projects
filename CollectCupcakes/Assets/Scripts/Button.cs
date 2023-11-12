using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Function to be called when the button is clicked
    public void LoadGameScene()
    {
        // Load Scene 1 (replace "YourScene1Name" with the actual name of your Scene 1)
        SceneManager.LoadScene("Game");
    }
}