using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToPick : MonoBehaviour, IInteractable
{
    public Items item;
    [SerializeField] Inventario inventario;
    [SerializeField] GameObject particles;
    [SerializeField] private AudioSource audioPlay;

    [SerializeField] float minD;
    
    [SerializeField] LayerMask itemMask;
    RaycastHit hit;

    [SerializeField]Mesh myMesh;

    private void Awake()
    {
        audioPlay = GetComponent<AudioSource>();
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
            if (audioPlay != null)
            { 
                audioPlay.Play();
                Debug.Log("Play");

            }
           
            inventario.inventory.Add(item);
            StartCoroutine(ActivarParticulas());
        }  
        
        audioPlay.Stop();
     }
    
    IEnumerator ActivarParticulas()
    {
        GameObject particulas = Instantiate(particles, transform.position, transform.rotation);
        var sh = particulas.GetComponent<ParticleSystem>().shape;
        sh.shapeType = ParticleSystemShapeType.Mesh;
        sh.mesh = myMesh;
        yield return new WaitForSeconds(1f);
        particulas.SetActive(true);
        particulas.GetComponent<ParticleSystem>().Play();
        Destroy(particulas, 2f);
        Destroy(this.gameObject);
    }
  
}
