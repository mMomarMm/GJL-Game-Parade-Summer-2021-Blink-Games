using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Text porcentage, tip;
    public static int LoadScene;
    AsyncOperation s;
    float progress, time;
    string[] tips = new string[]{"Dying is bad", "If you contaminate i'll kill you", "Plastic bags are made out of plastic",
    "Apples taste like apples", "Game jams are streesfull", "Do you like the font?",
    "Subscribe to my youtube... pls", "If you get shot your health decreases", "A computer mouse isn't a real mouse",
    "Inalambric computer mouse should be call hamster", "Drinking water will hydrate you",
    "You can hide behing crates if you crouch", "Ignore the grammatical mistakes",
    "Enemies will try to cover fire, wait till they reload to attack", "Shoot first, this enemies are bad coded"};
    void Start()
    {
        time = 0;
        progress = 0;
        s = SceneManager.LoadSceneAsync(LoadScene);
        s.allowSceneActivation = false;
        tip.text = tips[Random.Range(0, tips.Length)];
    }
    private void Update()
    {
        progress = s.progress;
        porcentage.text = (progress * 100) + "%";
        if (time >= 4)
        {
            s.allowSceneActivation = true;
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
