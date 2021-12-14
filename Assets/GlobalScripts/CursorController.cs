using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CursorProps
{
    public string name;
    public Texture2D image;
    public Vector2 clickPosition;
}

public class CursorController : MonoBehaviour
{
    public static CursorController instance;
    public List<CursorProps> cursors = new List<CursorProps> ();
    public string defaultCursor;

    void Awake()
    {
        instance = this;
    }

    void Start() {
        if (cursors.Count == 0) return;

        if (defaultCursor == null || defaultCursor == "")
        {
            defaultCursor = cursors[0].name;
        }

        int index = FindCursorIndexByName(defaultCursor);
        if (index == -1) index = 0;

        ActivateCursor(index);
    }

    public int FindCursorIndexByName(string name)
    {
        return cursors.FindIndex(x => x.name == name);
    }

    public void ActivateCursor(int index)
    {
        Cursor.SetCursor(cursors[index].image, cursors[index].clickPosition, CursorMode.Auto);
    }
}
