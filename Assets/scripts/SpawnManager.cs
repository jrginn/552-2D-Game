using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pumpkin;
    public GameObject crow;

    private Vector2[] pumpkinCoords = new Vector2[12];
    private bool[] pumpkinThere = new bool[12];
    // Start is called before the first frame update
    void Start()
    {
        // populate pumpkinCoords
        int index = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector2 pos = new Vector2(i, j);
                pumpkinCoords[index] = pos;
                pumpkinThere[index] = false;
                index++;
            }
        }

        // spawn one pumpkin per column to start
        for (int i = 0; i <= 9; i+= 3)
        {
            index = i + Random.Range(0, 3);
            spawnPumpkin(pumpkinCoords[index]);
            pumpkinThere[index] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPumpkin(Vector2 pos)
    {
        Instantiate(pumpkin, pos, Quaternion.identity);
    }
}
