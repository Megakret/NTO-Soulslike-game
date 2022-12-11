using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Bar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image Fill;
    public void ChangeSlider(double value)// �������� ������� �� ������������ �������� ���� ���������
    {
        StartCoroutine(ChangingSlider(value));
    }
    private IEnumerator ChangingSlider(double EndValue)
    {
        double _EndValue = Math.Round(EndValue,2);
        double value = Math.Round(slider.value, 2);
        float Increase;
        if (value < EndValue)
        {
            Increase = 0.01f;
        }
        else
        {
            Increase = -0.01f;
        }
        while (value != _EndValue)
        {
            //Debug.Log(value);
            //Debug.Log(_EndValue);
            yield return null;
            
            value += Increase;
            value = Math.Round(value, 2);
            slider.value = (float)value;
            Fill.color = gradient.Evaluate((float)value);

        }
        yield break;
    }
}
