using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarkokeilu : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider healtBar;

	// Use this for initialization
	void Start ()
    {
        MaxHealth = 20f;
        CurrentHealth = MaxHealth;
        healtBar.value = CalculateHealth();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(6);
        }
	}

    void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healtBar.value = CalculateHealth();
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
}
