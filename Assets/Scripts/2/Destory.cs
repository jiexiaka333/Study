using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Destroy()
    {
        Destroy(obj);
    }
}
