using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line for SceneManager

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Invoke the NextLevel function after 3 seconds
            Invoke("LoadNextLevel", 1.5f);
        }
    }

    // Function to load the next level
    private void LoadNextLevel()
    {
        SceneController.instance.NextLevel();
    }
}
