using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pumpkin;
    public GameObject leftCrow;
    public GameObject rightCrow;

    private const int pumpkinCount = 12;
    private Vector2[] pumpkinCoords = new Vector2[pumpkinCount];
    private bool[] pumpkinThere = new bool[pumpkinCount];
    // Start is called before the first frame update
    void Start()
    {
        // populate pumpkinCoords
        int index = 0;
        for (int i = -6; i <= 6; i += 4)
        {
            for (int j = -4; j <= 2; j += 3)
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
