using System.Collections;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    Vector2 ogScale;
    // Start is called before the first frame update
    private void OnEnable()
    {
        ogScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        if (Input.GetMouseButtonDown(0)) transform.localScale = Vector2.one * 0.25f;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * Vector2.one;
        if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = ogScale;
        }
    }
}