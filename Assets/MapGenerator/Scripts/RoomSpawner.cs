using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

class Sides
{
    public bool topDor;
    public bool bottomDor;
    public bool leftDor;
    public bool rightDor;
}

public class RoomSpawner : MonoBehaviour
{
    public RoomTemplates templates;

    public bool randomRooms = false;
    public int maxRooms;
    public int minRooms;
    int MAX_ROOMS;

    public int[,] map;
    int center;
    int createdRooms;

    [SerializeField]
    List<GameObject> renderedRooms;

    public float roomsSize;

    void Start()
    {
        Spawn();
    }

    public void ReSpawn()
    {
        foreach (GameObject room in renderedRooms)
        {
            Destroy(room);
        }

        createdRooms = 0;

        Spawn();
    }

    void Spawn()
    {
        if(randomRooms == true){
            MAX_ROOMS = Random.Range(minRooms, maxRooms);
        }
        else{
            MAX_ROOMS = maxRooms;
        }

        renderedRooms = new List<GameObject>();
        center = MAX_ROOMS/2;

        GenerateMapMatriz();
        RenderMap();
    }


    void GenerateMapMatriz()
    {
        int xPos = center;
        int yPos = center;

        map = new int[MAX_ROOMS, MAX_ROOMS];

        map[xPos, yPos] = 1;

        while (createdRooms < MAX_ROOMS)
        {
            int[] newRoomPos = AddPosToMap(xPos, yPos);

            xPos = newRoomPos[0];
            yPos = newRoomPos[1];
        }
    }

    int[] AddPosToMap(int xPos, int yPos)
    {
        var newRoomPos = NewMatrizPosition(xPos, yPos);

        if(map[newRoomPos[0], newRoomPos[1]] == 0){
            createdRooms += 1;
            map[newRoomPos[0], newRoomPos[1]] = 1;
        }

        return newRoomPos;
    }

    int[] NewMatrizPosition(int xPos, int yPos)
    {
        string[] options = {"x", "y"};
        int rand = Random.Range(0, options.Length);

        int newX = xPos;
        int newY = yPos;

        int[] possibleIncrement = {-1, 1};
        if(options[rand] == "x"){
            int xRand = Random.Range(0, possibleIncrement.Length);
            newX += possibleIncrement[xRand];
        }

        if(options[rand] == "y"){
            int yRand = Random.Range(0, possibleIncrement.Length);
            newY += possibleIncrement[yRand];
        }

        if(newX < 0 || newY < 0 || newX >= MAX_ROOMS || newY >= MAX_ROOMS){
            return NewMatrizPosition(xPos, yPos);
        }

        return new int[2] {newX, newY};
    }

    void RenderMap()
    {
        for (int i = 0; i < map.GetLength(0); i++) 
        {
            for (int j = 0; j < map.GetLength(1); j++) 
            {
                float xPos = (j-center)*roomsSize;
                float yPos = -(i-center)*roomsSize;
                Vector2 position = new Vector2(xPos, yPos);

                if(map[i, j] != 0)
                {
                    Sides sides = VerifySides(j, i);

                    GameObject room = GetRoomBySides(sides);

                    GameObject createdRoom = Instantiate(room, position, Quaternion.identity);

                    renderedRooms.Add(createdRoom);
                }

                // if(map[i, j] == 0)
                // {
                //     Instantiate(templates.closedRoom, position, Quaternion.identity);
                // }
            }
        }
    }

    Sides VerifySides(int x, int y)
    {
        Sides sides = new Sides();

        if(x < MAX_ROOMS-1 && map[y, x+1] == 1){
            // tem na direita
            sides.rightDor = true;
        }

        if(x > 0 && map[y, x-1] == 1){
            // tem na esquerda
            sides.leftDor = true;
        }

        if(y < MAX_ROOMS-1 && map[y+1, x] == 1){
            // tem em baixo
            sides.bottomDor = true;
        }

        if(y > 0 && map[y-1, x] == 1){
            // tem em cima
            sides.topDor = true;
        }

        return sides;
    }

    GameObject GetRoomBySides(Sides sides)
    {
        GameObject selectedRoom;

        try
        {
            var roomFind = templates.rooms.Find(room => 
                room.topDor == sides.topDor && room.bottomDor == sides.bottomDor && room.leftDor == sides.leftDor && room.rightDor == sides.rightDor
            );
            selectedRoom = roomFind.roomPrefab;
        }
        catch
        {
            return templates.closedRoom;
        }

        return selectedRoom;
    }
}
