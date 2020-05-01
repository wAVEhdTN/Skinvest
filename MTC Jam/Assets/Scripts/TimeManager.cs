using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public DaysManager DM;

    int Clicks;

    public Animator Anim;
    public GameObject HomeButton;

   public void ResumeTime()
    {
        DM.CanGo = false;

    }
    public void FreezeTime()
    {
        DM.CanGo = true;

    }
    public void Speed()
    {
        Clicks += 1;
        if(Clicks == 1)
        {
            DM.DayTime = DM.DayTime / 2;
            Time.timeScale = 2f;
            Anim.SetBool("Pressed", true);
        }
        if (Clicks == 2)
        {
            DM.DayTime = DM.DayTime * 2;

            Time.timeScale = 1f;
            Anim.SetBool("Pressed", false);
            Clicks = 0;
        }
    }
}
