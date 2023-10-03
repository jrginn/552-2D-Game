using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinSpawn : MonoBehaviour
{
    public GameObject pumpkin;
    private Dictionary<Vector2, bool> coords = new Dictionary<Vector2, bool>();

    // Start is called before the first frame update
    void Start()
    {
        // populates possible coordinates for pumpkins as all possible to start
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Vector2 pos = new Vector2(i, j);
                coords.Add(pos, true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
