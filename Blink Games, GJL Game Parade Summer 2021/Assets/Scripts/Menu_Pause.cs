using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu_Pause : MonoBehaviour
{
    public GameObject PausePanel, OptionsPanel;
    public void Pause()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (Time.timeScale != 0)
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
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
}
