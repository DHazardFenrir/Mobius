using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCristal : MonoBehaviour, IInteractable
{
    [SerializeField] float energy;
    [SerializeField] GameObject particles;
    [SerializeField] Mesh myMesh;
    [SerializeField] AudioSource pickUpSound;


    public void Interact()
    {
        var playerEnergy = FindObjectOfType<PlayerEnergy>();
        playerEnergy.GainEnergy(energy);
        pickUpSound.Play();
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
