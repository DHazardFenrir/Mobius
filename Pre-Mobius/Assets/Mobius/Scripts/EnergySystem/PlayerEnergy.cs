using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public float energy { get; private set; }
    [SerializeField] float maxEnergy;
    [SerializeField] float energyDelay;
    [SerializeField] float energyPerSecond;
    bool active;

    private void Start()
    {
        StartCoroutine(RegenerateEnergy());
    }




    IEnumerator RegenerateEnergy()
    { 
        while(true)
        {
            yield return new WaitForSeconds(energyDelay);
            energy=energy+energyPerSecond;
            if (energy >= maxEnergy)
            {
                energy = maxEnergy;
            }
            else if (energy < 0)
            {
                energy = 0;
            }
            Debug.Log(energy);
        }
    }

    public void LoseEnergyByLoop()
    {
        energy = energy / 2;
        if (energy < 0)
        {
            energy = 0;
        }
    }

    public void EnergyLoose(float energyLose)
    {
        energy = energy - energyLose;
        if(energy<0)
        {
            energy = 0;
        }
    }

}
