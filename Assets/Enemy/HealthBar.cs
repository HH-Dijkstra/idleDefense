using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Gradient gradient;
    public Slider slider;
    public Image Fill;
    // Start is called before the first frame update
    void Start()
    {
        Fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealth(float Health)
    {
        slider.value = Health;
        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
}
