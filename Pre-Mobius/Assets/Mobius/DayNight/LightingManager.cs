using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            
        }
    }

    private void Start()
    {
        player.transform.position = playerSpawn.position;
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
            Loop();
        }

        
        if(Input.GetKeyDown(KeyCode.R))
        {
            DontDestroyOnLoad(player);
            
            SceneManager.LoadScene(1);
        }

        timeToGet = TimeOfDay;


    }

    public void Loop()
    {
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(0);
        player.transform.position = playerSpawn.position;
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
