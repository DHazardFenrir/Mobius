using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] GameObject texto = default;

    private void Awake()
    {
        texto = GameObject.FindGameObjectWithTag("InteractiveText");
        texto.SetActive(false);
         rb = GetComponent<Rigidbody>();

    }

    Rigidbody rb;

    private void Start()
    {
        _camera = Camera.main;
       
    }

    

    void Update()
    {
        var nearestGameObject = GetNearestGameObject();
        
        if (nearestGameObject == null) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {          
            var interactable = nearestGameObject.GetComponent<IInteractable>();
            interactable?.Interact();
        }
        rb.AddForce(new Vector3(0f, 1 * Time.deltaTime, 0f), ForceMode.Acceleration);


    }

    private GameObject GetNearestGameObject()
    {
        GameObject result = null;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hit, 5f))
        {
            result = hit.transform.gameObject;
            if(result.CompareTag("Interactable"))
            {
                texto.SetActive(true);
            }
            else
            {
                texto.SetActive(false);
            }
        }
        else
        {
            texto.SetActive(false);
        }
       
        
        return result;
    }

    void GameOver()
    {
        Debug.Log("si jala");
        GameManager gm = FindObjectOfType<GameManager>();
        gm.StartCoroutine(gm.GameOverScreen());
        Animator anim = GetComponent<Animator>();
        anim.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameOver"))
        {
            
            GameOver();
        }

        if(other.CompareTag("Interactable"))
        {
            texto.SetActive(true);
            Debug.Log("Se entro en un Interactable");
        }

    }



    private void OnTriggerStay(Collider other)
    {
            if (Input.GetKeyDown(KeyCode.E))
            {              
                other.GetComponent<IInteractable>().Interact();               
            }
    }

    private void OnTriggerExit(Collider other)
    {
        //texto = GameObject.FindGameObjectWithTag("InteractiveText");
        if (other.CompareTag("Interactable"))
        {
            texto.SetActive(false);
        }
    }

}
