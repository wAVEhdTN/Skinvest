using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip ClickSound,CashSound,CantBuySound, NotifcationSound;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlaySound("Click");
        }
    }
    public void PlaySound(string ClipName)
    {
        switch(ClipName)
        {
            case "Click":
                AS.PlayOneShot(ClickSound);
              break;
            case "Cash":
                AS.PlayOneShot(CashSound);
                break;
            case "Cant":
                AS.PlayOneShot(CantBuySound);
                break;
            case "Notifcation":
                AS.PlayOneShot(NotifcationSound);
                break;
        }
    }

}
