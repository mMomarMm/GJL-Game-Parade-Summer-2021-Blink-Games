using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Pause : MonoBehaviour
{
    public GameObject PausePanel, OptionsMenu, ControlsMenu, cursor;
    public Text AudioState;
    public void Pause()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (Time.timeScale != 0)
            {
                cursor.SetActive(true);
                PausePanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                cursor.SetActive(false);
                PausePanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();
    }
    public void SendToScene(int scene)
    {
        LoadingScene.LoadScene = scene;
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Options()
    {
        if (OptionsMenu.activeSelf) OptionsMenu.SetActive(false);
        else
        {
            OptionsMenu.SetActive(true);
        }
    }
    public void AudioActivation()
    {
        AudioSource Audio = GameObject.FindGameObjectWithTag("Respawn").transform.GetComponentInChildren<AudioSource>();
        if (Audio.isPlaying) { Audio.Pause(); AudioState.text = "Sound off"; }
        else { Audio.UnPause(); AudioState.text = "Sound on"; }
    }
    public void Controls()
    {
        if (ControlsMenu.activeSelf) ControlsMenu.SetActive(false);
        else
        {
            ControlsMenu.SetActive(true);
        }
    }
    public void Volume(float i)
    {
        AudioSource Audio = GameObject.FindGameObjectWithTag("Respawn").transform.GetComponentInChildren<AudioSource>();
        Audio.volume = i * i;
    }
}
