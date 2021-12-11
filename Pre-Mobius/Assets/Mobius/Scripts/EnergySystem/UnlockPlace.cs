using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPlace : MonoBehaviour, IInteractable
{

    [SerializeField] float energyRequired;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject forceField;
    [SerializeField] Mesh myMesh;

    PlayerEnergy playerE;

    private void Start()
    {
        playerE = FindObjectOfType<PlayerEnergy>();

    }

    public void Interact()
    {
        
        if (playerE.energy >= energyRequired)
        {
            UnlockWay();
            playerE.EnergyLoose(energyRequired);
        }
        else
        {

        }      
    }

    void UnlockWay()
    {
        GameObject particulas = Instantiate(particles, transform.position, transform.rotation);
        var sh = particulas.GetComponent<ParticleSystem>().shape;
        sh.shapeType = ParticleSystemShapeType.Mesh;
        sh.mesh = myMesh;
        particulas.SetActive(true);
        particulas.GetComponent<ParticleSystem>().Play();
        Destroy(particulas, 2f);
        Destroy(forceField);
        Destroy(this.gameObject);
    }

}
