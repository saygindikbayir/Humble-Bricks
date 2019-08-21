using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScripts : MonoBehaviour
{
    public Slider Slider;
    void Start()
    {
        Slider.onValueChanged.AddListener(ValueChanged);
    }

    public void ValueChanged(float value)
    {
        GameSettings.MoveSpeed = value;
    }
    void Update()
    {

    }
}
