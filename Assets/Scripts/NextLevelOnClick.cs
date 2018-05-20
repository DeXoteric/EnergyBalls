using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelOnClick : MonoBehaviour
{
    public void NextLevel()
    {
        try
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
            LevelController.ResetLevel();
        }
        catch
        {
            int lastScene = SceneManager.sceneCount;
            SceneManager.LoadScene(lastScene - 1);
            LevelController.ResetLevel();
        }
    }
}