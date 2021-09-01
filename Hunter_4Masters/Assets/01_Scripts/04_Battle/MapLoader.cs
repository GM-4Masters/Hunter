﻿using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class MapLoader : MonoBehaviour
{
    private Grid grid;

    public Tile ground;
    public GameObject spawner;

    public Tilemap tileMap;

    Dictionary<string, string[]> mapJson = new Dictionary<string, string[]>();

    private int num = 0;
    private string[] stages = {"01_stage", "02_stage", "03_stage"};

    public void LoadMap()
    {
        mapJson = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(Resources.Load<TextAsset>($"Data/mapData").text);
        string[] stage = mapJson[stages[num]];

        string[,] data = new string[stage.Length, stage[0].Length];

        string[] temp= stage[0].Split(',');
        for(int i=0; i<stage.Length; i++)
        {
            temp = stage[i].Split(',');

            for(int j=0; j<temp.Length; j++)
            {
                data[i, j] = temp[j];
            }
        }

        for(int i=0; i<stage.Length; i++)
        {
            for(int j=0; j<temp.Length; j++)
            {
                if(data[i, j].Equals("1"))
                {
                    tileMap.SetTile(new Vector3Int(j, 0-i, 0), ground);
                }
                else if(data[i, j].Equals("0"))
                {
                    tileMap.SetTile(new Vector3Int(j, 0-i, 0), null);
                }
                else if(data[i, j].Equals("S"))
                {
                    tileMap.SetTile(new Vector3Int(j, 0-i, 0), null);
                    Instantiate(spawner, new Vector3Int(j+1, 0-i, 0), Quaternion.identity);
                }
                else if(data[i, j].Equals("P"))
                {
                    tileMap.SetTile(new Vector3Int(j, 0-i, 0), null);
                    
                    GameObject player = GameObject.Find("Player");
                    player.transform.position = new Vector3(j+1, 0-i, 0);
                }
            }
        }
        num += 1;
        if(num >= stages.Length) num = 0;
    }
}