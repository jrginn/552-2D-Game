using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pumpkin_0;
    public GameObject pumpkin_1;
    public GameObject pumpkin_2;
    public GameObject leftCrow;
    public GameObject rightCrow;
    public GameObject addPowerup;
    public GameObject clearPowerup;
    public float crowSpawnRate;
    public float powerupSpawnRate;

    private const int pumpkinCount = 12;
    private Vector2[] pumpkinCoords = new Vector2[pumpkinCount];
    private bool[] pumpkinThere = new bool[pumpkinCount];
    private float crowTimer = 0;
    private bool spawnLeft = true;
    private float powerupTimer;
    private float crowCounter;

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
            SpawnPumpkin(pumpkinCoords[index]);
            pumpkinThere[index] = true;
        }

        spawnLeft = Random.Range(0, 2) == 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(crowTimer < crowSpawnRate)
        {
            crowTimer += Time.deltaTime;
        }
        else
        {
            crowCounter++;
            int index = Random.Range(0, pumpkinCount);
            // There should always be at least one pumpkin while game is not lost
            while (PumpkinAlive() && !pumpkinThere[index])
            {
                index++;
                if(index == pumpkinCount)
                {
                    index = 0;
                }
            }
            if(spawnLeft) 
            { 
                Instantiate(leftCrow, new Vector2(-11, pumpkinCoords[index].y), Quaternion.Euler(new Vector3(0, 0, 90)));
                spawnLeft = Random.Range(0, 2) == 1;
            }
            else
            {
                Instantiate(rightCrow, new Vector2(11, pumpkinCoords[index].y), Quaternion.Euler(new Vector3(0, 0, -90)));
                spawnLeft = Random.Range(0, 2) == 1;
            }
            if(crowCounter % 3 == 0 && crowSpawnRate >= 2f)
            {
                crowSpawnRate -= .5f;
            }
            crowTimer = 0;
        }

        if(powerupTimer < powerupSpawnRate)
        {
            powerupTimer += Time.deltaTime;
        }
        else
        {
            // 3/4 chance to spawn powerup
            if(Random.Range(0, 4) <= 2)
            {
                float powerupY = Random.Range(-4, 3);
                // 1/2 chance to spawn new pumpkin, equal to spawn screen clear
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(addPowerup, new Vector2(-11, powerupY), Quaternion.identity);
                }
                else
                {
                    Instantiate(clearPowerup, new Vector2(11, powerupY), Quaternion.identity);
                }

            }
            powerupTimer = 0;
        }
    }

    void SpawnPumpkin(Vector2 pos)
    {
        Instantiate(pumpkin_1, pos, Quaternion.identity);
    }

    public void UpdatePumpkinStatus(Vector2 pos, bool alive)
    {
        // finds correpsonding index
        int index = 0;
        while (!pumpkinCoords[index].Equals(pos))
        {
            index++;
        }
        pumpkinThere[index] = alive;
    }

    public bool PumpkinAlive()
    {
        for(int i = 0; i < pumpkinThere.Length; i++)
        {
            if (pumpkinThere[i])
            {
                return true;
            }
        }
        return false;
    }

}
