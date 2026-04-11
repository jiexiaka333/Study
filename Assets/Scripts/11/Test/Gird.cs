using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gird : MonoBehaviour
{
    public GridLayoutGroup gird;
    public GameObject slots;
    void Start()
    {
        for(int i = 0;i<9;i++)
        {
            GameObject slot = Instantiate(slots, gird.transform);
        }
    }

}
