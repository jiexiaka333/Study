using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make : MonoBehaviour
{
    public GameObject obstaclePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = new Vector3(Random.Range(-5f, 5f), 2f, Random.Range(-5f, 5f));
            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
