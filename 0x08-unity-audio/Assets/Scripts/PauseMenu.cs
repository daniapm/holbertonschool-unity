using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    //public AudioMixer master;
    //public AudioMixerSnapshot unpaused;
    //public AudioMixerSnapshot paused;
    public GameObject PauseCanvas;
    public bool Paused = false;
    public GameObject camera;
    private Scene current;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        camera.gameObject.GetComponent<CameraController>().enabled = false;
        //master.ClearFloat("BGM");
        //paused.TransitionTo(0.01f);
    }
    public void Resume()
    {
        PauseCanvas.SetActive(false);
        camera.gameObject.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1f;
        Paused = false;
        //unpaused.TransitionTo(0.01f);
        //master.SetFloat("BGM", Mathf.Log10(PlayerPrefs.GetFloat("bgm", 1f)) * 20);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        current = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("Prev", current.name);
        Resume();
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Single);
    }
}
