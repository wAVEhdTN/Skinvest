using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsOpacity : MonoBehaviour
{
    public Image[] Images;

    public void ChangeOpacity(int I)
    {
        for (int i = 0; i < Images.Length; i++)
        {
            if(Images[i] != Images[I])
            {
                Images[i].color = new Color(Images[i].color.r, Images[i].color.g, Images[i].color.b, 157);
            }
        }
    }
}
