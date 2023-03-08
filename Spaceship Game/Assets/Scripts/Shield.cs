using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int currentHealth;
    [SerializeField] int regenerateAmount = 1;
    [SerializeField] float regenerationRate = 2f;


     void Start()
    {
        //this assignment makes it so that in the inspector only on variable needs to be changed instead of both
        currentHealth = maxHealth;    

        InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    }

    void Regenerate()
    {
        Debug.Log("REGENERATING");

        if (currentHealth < maxHealth)
            currentHealth += regenerateAmount;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;

        EventManager.TakeDamage(currentHealth / (float)maxHealth);

    }

    public void TakeDamage(int damage = 1)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        EventManager.TakeDamage(currentHealth / (float) maxHealth);

        if (currentHealth < 1)
        {
            EventManager.PlayerDeath(); // call the onPlayerDeath event
            GetComponent<Explosion>().BlowUp();
            //remove life from life counter
        }
            Debug.Log("I'm Dead");

    }
}
