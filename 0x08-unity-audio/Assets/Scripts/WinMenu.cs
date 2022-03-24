using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject camera;
    private Scene current;

    public void MainMenu()
    {
        camera.gameObject.GetComponent<CameraController>().enabled = true;
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
    public void Next()
    {
        camera.gameObject.GetComponent<CameraController>().enabled = true;
        current = SceneManager.GetActiveScene();
        if (current.name == "Level01")
        {
            SceneManager.LoadSceneAsync(current.buildIndex + 2, LoadSceneMode.Single);
        }
        else if(current.name != "Level03")
            SceneManager.LoadSceneAsync(current.buildIndex + 1, LoadSceneMode.Single);
        else
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
