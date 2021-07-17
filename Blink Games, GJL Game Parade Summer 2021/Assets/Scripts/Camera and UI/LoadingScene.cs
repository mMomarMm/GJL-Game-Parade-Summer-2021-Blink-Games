using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Text porcentage, tip;
    public static int LoadScene;
    AsyncOperation s;
    float progress;
    string[] tips = new string[]{"Dying is bad", "Contamination is bad", "Plastic bags are made out of plastic",
    "Apples taste like apples", "Game jams are streesfull", "Do you like the font?",
    "Subscribe to my youtube... pls", "If you get shot your health decreases", "A computer mouse isn't a mouse",
    "Inalambric computer mouse should be call hamster", "Drinking water will hydrate you",
    "You can hide behing crates if you crouch", "Enemies will try to cover fire, wait till they reload to attack"};

    // Start is called before the first frame update


    void Start()
    {
        progress = 0;
        s = SceneManager.LoadSceneAsync(LoadScene);
        s.allowSceneActivation = false;
        tip.text = tips[Random.Range(0, tips.Length)];
        StartCoroutine(l());
    }

    //Scene oader
    IEnumerator l()
    {
        while (s.progress < 0.9f)
        {
            progress = s.progress;
            yield return null;
        }
        progress = 1;
        yield return new WaitForSecondsRealtime(4);
        yield return new WaitForEndOfFrame();
        s.allowSceneActivation = true;
    }
    //Progress text
    private void Update()
    {
        porcentage.text = (progress * 100) + "%";
    }
}