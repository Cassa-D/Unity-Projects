using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CursorProps
{
    public string name;
    public Texture2D image;
    public Vector2 clickPosition;
}

public class CursorController : MonoBehaviour, ISerializationCallbackReceiver
{
    public static CursorController instance;
    public static List<string> TMPcursors;
    public List<CursorProps> cursors = new List<CursorProps> ();
    
    [ListToPopup(typeof(CursorController), "TMPcursors")]
    public string defaultCursor;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    void Start() {
        if (cursors.Count == 0) return;

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

    private List<string> GetCursorsNames()
    {
        List<string> list = new List<string>();
        foreach (CursorProps cursor in cursors)
        {
            list.Add(cursor.name);
        }
        return list;
    }

    public void OnBeforeSerialize()
    {
        TMPcursors = GetCursorsNames();
    }

    public void OnAfterDeserialize() {}
}
