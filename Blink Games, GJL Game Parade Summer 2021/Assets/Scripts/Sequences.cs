using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Sequences : MonoBehaviour
{
    public Player player;
    public Text text;
    public GameObject image, Mainmenu, mouse;
    public bool isEnd;
    bool isPlaying;
    private void Start()
    {
        if (!isEnd) StartCoroutine(Intro());
    }

    private void Update()
    {
        if (!isEnd)
        {
            if (Input.anyKeyDown)
            {
                gameObject.SetActive(false);
                player.enabled = true;
            }
        }
        else if (isPlaying)
        {
            image.transform.position += Vector3.up * Time.deltaTime;
            Mainmenu.transform.position += Vector3.up * Time.deltaTime;
            if (Input.anyKeyDown)
            {
                isPlaying = false;
                image.SetActive(false);
                mouse.SetActive(true);
                Mainmenu.transform.localPosition = Vector3.zero;
            }
        }
    }
    IEnumerator Intro()
    {
        yield return new WaitForSecondsRealtime(3f);
        text.text = "All the plastic bags bullied and no one wanted to keep their groceries in him";
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        text.fontSize = 72;
        yield return new WaitForSecondsRealtime(3.9f);
        text.fontSize = 84;
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
        text.text = "Until one day he saw the red doors to his salvation";
        yield return new WaitForSecondsRealtime(4f);
        text.fontSize = 70;
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        text.color = Color.black;
        text.text = "And now with the tommy gun to support him he is teady to save the enviroment and kill those plastic motherfuckers";
        yield return new WaitForSecondsRealtime(4);
        player.enabled = true;
        if (!isEnd) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            image.SetActive(true);
            isPlaying = true;
            player.gameObject.SetActive(false);
        }
    }
}