
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SlowMotionTime : MonoBehaviour
{

   

    public void DoSlowMotion()
    {
        if (Input.GetKeyDown((KeyCode.E)))
        {
            Time.timeScale /= 4;
            Time.fixedDeltaTime = Time.unscaledDeltaTime;

            if (Time.timeScale < 0.25)
            {
                Time.timeScale = 1;
               
            }
               
        }

          
    }

}
