using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Back to Desktop");
        Application.Quit();
    }

}