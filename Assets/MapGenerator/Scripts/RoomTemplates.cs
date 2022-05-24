using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room {
    public GameObject roomPrefab;

    public bool topDor;
    public bool bottomDor;
    public bool leftDor;
    public bool rightDor;
}

public class RoomTemplates : MonoBehaviour
{
    public List<Room> rooms;
    public GameObject closedRoom;
}
