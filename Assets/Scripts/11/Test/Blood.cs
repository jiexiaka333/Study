using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood : MonoBehaviour
{
    public Slider slider;
    private Slider healthBarInstance;
    private int health = 100;
    void Start()
    {
        Canvas worldCanvas = FindObjectOfType<Canvas>();
        healthBarInstance = Instantiate(slider, worldCanvas.transform);
        healthBarInstance.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=Camera.main.WorldToScreenPoint(transform.position);
        healthBarInstance.transform.position = pos;

        if(Input.GetMouseButtonDown(0))
        {
            TakeDamage(10);
        }
    }
    void TakeDamage(int hp)
    {
        health -= hp;
        healthBarInstance.value = health/100f;
        if(health<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
