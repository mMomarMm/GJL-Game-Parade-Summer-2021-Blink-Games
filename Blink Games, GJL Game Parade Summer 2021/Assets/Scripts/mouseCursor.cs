using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) StartCoroutine(cursorAnim());
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -5);
    }
    public IEnumerator cursorAnim()
    {
        transform.localScale = new Vector2(.5f, .5f);
        yield return new WaitForSeconds(.02f);
        transform.localScale = new Vector2(.6f, .6f);
    }
}