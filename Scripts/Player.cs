using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    //creates healthbar
    public int MaxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;
    // Start is called before the first frame update
    // Puts health in healthbar to be the max health (100)
    void Start()
    {
        currentHealth = MaxHealth;
        healthbar.setMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //arbitrary take damage command when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }
}