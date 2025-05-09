using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            EndTheGame();
        }
    }

    private void EndTheGame()
    {
        SceneManager.LoadScene("Outro Cutscene");
    }
}
