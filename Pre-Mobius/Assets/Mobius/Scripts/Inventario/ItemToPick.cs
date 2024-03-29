﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ItemToPick : MonoBehaviour, IInteractable
{
    public Items item;
    [SerializeField] Inventario inventario;
    [SerializeField] GameObject particles;

    [SerializeField] float minD;
    
    [SerializeField] LayerMask itemMask;
    RaycastHit hit;

    [SerializeField]Mesh myMesh;
    [SerializeField] private AudioSource audio;

    private void Awake()
    {
        audio = FindObjectOfType<RigidbodyFirstPersonController>().GetComponent<AudioSource>();
    }

    private void Start()
    {
     

        inventario = FindObjectOfType<Inventario>().GetComponent<Inventario>();
        check();
        //thisMesh = GetComponentInChildren<MeshFilter>();
    }

    

    public void check()
    {
        if (inventario.inventory.Contains(item))
        {
            Destroy(this.gameObject);
        }
    }
    

    public void Interact()
    {
        Save();
    }

    public void Save()
    {
        var camera = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
      

        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, minD, itemMask))
            {
            Debug.Log("Did Hit");
            audio.Play();
            inventario.inventory.Add(item);
            ActivarParticulas();
            }       
     }
    
    void ActivarParticulas()
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
