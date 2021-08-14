using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unfogTrigger : MonoBehaviour
{

    bool triggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") & !triggered)
        {
            //lol i hardcoded the boss intros delay
            RenderSettings.fog = false;
            AudioManager.instance.PlaySound("BossIntro", null, 0);
            AudioManager.instance.PlaySound("BossLoop", null, 6);
            triggered = true;
        }
    }
}