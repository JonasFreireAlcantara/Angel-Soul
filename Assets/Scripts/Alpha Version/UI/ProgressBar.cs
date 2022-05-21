using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxValue(float value)
	{
		slider.maxValue = value;
		slider.value = value;

		fill.color = gradient.Evaluate(1f);
	}

	public float GetMaxValue(){
		return slider.maxValue;
	}

    public void SetValue(float value)
	{
		slider.value = value;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

	public float GetValue(){
		return slider.value;
	}

}