using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jh : MonoBehaviour
{
    public Image image;
    void Start()
    {
        Color colorNew = image.color;
        StartCoroutine(djh(colorNew));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator jh()
    {
        while (true)
        {
            image.color = Color.red;
            yield return new WaitForSecondsRealtime(0.2f);
            image.color = Color.white;
            yield return new WaitForSecondsRealtime(0.2f);
        }
        
    }
    IEnumerator djh(Color colorNew)
    {
        Coroutine bb= StartCoroutine(jh());

        yield return new WaitForSecondsRealtime(2f);
        if(bb != null)
        {
            StopCoroutine(bb);
            image.color = colorNew;
        }
       
    }
   
}
