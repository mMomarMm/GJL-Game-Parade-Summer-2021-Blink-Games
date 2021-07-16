using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Text porcentage, tip;
    public static int LoadScene;
    string[] tips = new string[]{"Dying is bad", "Contamination is bad", "Plastic bags are made out of plastic",
    "Apples taste like apples", "Game jams are streesfull", "Many gramatical mistakes were made",
    "Subscribe to my youtube... pls", "If you get shot your health decreases", "A computer mouse isn't a mouse",
    "Inalambric computer mouse should be call hamster", "Drinking water will hydrate you",
    "You can hide behing crates if you crouch", "Enemies will try to cover fire, wait till they reload to attack"};

    // Start is called before the first frame update


    void Start()
    {
        tip.text = tips[Random.Range(0, tips.Length)];
        StartCoroutine(LoadAsyncOperation());
    }

    //gamelevel
    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation s = SceneManager.LoadSceneAsync(0);
        s.allowSceneActivation = false;
        while (s.progress < .9)
        {
            porcentage.text = s.progress * 100 + "%";
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(5);
        s.allowSceneActivation = true;
    }
}