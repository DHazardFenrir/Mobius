using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    public GameObject player { get; private set;}
   
    //Variables
    const int DayInMinutes=10;
    [SerializeField, Range(0, DayInMinutes*60)] float TimeOfDay;
    public float timeToGet { get; private set;}

    [SerializeField]Transform playerSpawn;

    [SerializeField] CanvasGroup loopLight;

    [SerializeField]PlayerEnergy playerE;

    private void Awake()
    {
        this.enabled = true;
        if (player == null)
        {
            player = GameObject.Find("Player");
            loopLight = GameObject.Find("Destello").GetComponent<CanvasGroup>();
            playerE = FindObjectOfType<PlayerEnergy>();
        }
    }

    private void Start()
    {
        this.enabled = true;

        player.transform.position = playerSpawn.position;
        loopLight.DOFade(0f, 2f);
        Debug.Log("doing fade");
        
    }


    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= (60*DayInMinutes); //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / (60*DayInMinutes));
        }
        else
        {
            UpdateLighting(TimeOfDay / (60 * DayInMinutes));
        }

        if(TimeOfDay>=((60*DayInMinutes))-1)
        {
            StartCoroutine(LoopFade());
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            playerE.LoseEnergyByLoop();
            StartCoroutine(LoopFade());
        }

        timeToGet = TimeOfDay;
    }

    
    public void StartLoopFadeForOthers()
    {
        StartCoroutine(LoopFade());

    }

    public void Loop()
    {
        loopLight.DOFade(1f, 2f);
        playerE.LoseEnergyByLoop();
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(loopLight);
        SceneManager.LoadScene(1);
        player.transform.position = playerSpawn.position;
    }

    IEnumerator LoopFade()
    {
        loopLight.DOFade(1f, 2f);
        yield return new WaitForSeconds(2f);
        Loop();
    }

    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }



    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

}
