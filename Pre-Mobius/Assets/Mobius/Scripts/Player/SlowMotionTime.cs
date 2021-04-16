
using UnityEngine;

public class SlowMotionTime : MonoBehaviour
{
    [SerializeField] float slowDownFactor=0.05f;
    [SerializeField] float slowdownLength = 2f;


    private void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        Debug.Log("EEEEEE");

    }

   
}
