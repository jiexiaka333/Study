using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(1.5f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
