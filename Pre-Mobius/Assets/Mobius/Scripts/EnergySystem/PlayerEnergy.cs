using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    public float energy { get; private set; }
    [SerializeField] float maxEnergy;
    [SerializeField] float energyDelay;
    [SerializeField] float energyPerSecond;
    public TextMeshProUGUI energyText;
    
    
    bool active;

    private void Start()
    {
        StartCoroutine(RegenerateEnergy());
        energyText = GameObject.Find("EnergyAmount").GetComponent<TextMeshProUGUI>();
    }




    IEnumerator RegenerateEnergy()
    { 
        while(true)
        {
            yield return new WaitForSeconds(energyDelay);
            energy=energy+energyPerSecond;
            energyText.text = "" + Mathf.Round(energy);
            if (energy >= maxEnergy)
            {
                energy = maxEnergy;
            }
            else if (energy < 0)
            {
                energy = 0;
            }
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

    public void GainEnergy(float energyGained)
    {
        energy += energyGained;
        if (energy >= maxEnergy)
        {
            energy = maxEnergy;
            energyText.text = "" + Mathf.Round(energy);
        }
    }

}
