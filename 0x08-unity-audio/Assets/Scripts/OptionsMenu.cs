using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle toogle;
    private bool invertY;

    void Start()
    {
        if (PlayerPrefs.GetInt("Y", 0) == 0)
            invertY = false;
        else
            invertY = true;
        toogle.isOn = invertY;
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Prev", "MainMenu"), LoadSceneMode.Single);
    }

    public void Apply()
    {
        if (toogle.isOn)
        {
            PlayerPrefs.SetInt("Y", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Y", 0);
        }
        Back();
    }
}
