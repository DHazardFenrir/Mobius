using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPlace : MonoBehaviour, IInteractable
{

    [SerializeField] float energyRequired;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject forceField;
    [SerializeField] Mesh myMesh;

    [SerializeField] bool beach;
    [SerializeField] GameObject[] beachFF;

    PlayerEnergy playerE;

    private void Start()
    {
        playerE = FindObjectOfType<PlayerEnergy>();

    }

    public void Interact()
    {
        if(!beach)
        {
            if (playerE.energy >= energyRequired)
            {
                UnlockWay();
                playerE.EnergyLoose(energyRequired);
            }
        }
        else
        {
            UnlockBeach();
        }
          
    }

    void UnlockBeach()
    {
        
        for(int i=0;i<beachFF.Length;i++)
        {
            GameObject particulas = Instantiate(particles, beachFF[i].transform.position, beachFF[i].transform.rotation);
            var sh = particulas.GetComponent<ParticleSystem>().shape;
            sh.shapeType = ParticleSystemShapeType.Mesh;
            sh.mesh = myMesh;
            particulas.SetActive(true);
            particulas.GetComponent<ParticleSystem>().Play();
            Destroy(particulas, 2f);
        }
        Destroy(this.gameObject);
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
        Destroy(this.gameObject);
    }

}