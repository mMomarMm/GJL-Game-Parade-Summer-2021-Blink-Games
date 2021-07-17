using System.Collections;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    Vector2 ogScale;
    // Start is called before the first frame update
    private void OnEnable()
    {
        ogScale = transform.localScale;
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
        transform.localScale = ogScale - (Vector2.one * 0.1f);
        yield return new WaitForSecondsRealtime(.02f);
        transform.localScale = ogScale;
    }
}