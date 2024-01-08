using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//A very quick and dirty implementation of a GameStateManager.
//The job the GameStateManager is to mediate between different GameStates.
//At the moment it can only switch between MainMenu and the GameLoop.
//Additional responsibilities would be:
// - keep actual track of the GameState
// - pause the GameLoop without stopping it
// - Quitting the application
//and possibly more.
public class GameStateManager : MonoBehaviour
{
    private static GameStateManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public static void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public static void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    private IEnumerator LoadScenesCoroutine(int oldScene, int newScene)
    {
        LoadingScreen.Show(this);
        yield return SceneLoader.Instance.UnloadSceneViaIndex(oldScene);
        yield return SceneLoader.Instance.LoadSceneViaIndex(newScene);
        LoadingScreen.Hide(this);
    }
}
