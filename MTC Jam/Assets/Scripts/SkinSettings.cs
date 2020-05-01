using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSettings : MonoBehaviour
{
    public float Price;

    public string Rarity;
    public string Name;
    public string Exterior;

    public int Quanity;

    public int LifeTime;

    public bool State;

    public DaysManager DM;
    public SkinsManager SM;

    bool Done,AfterLifeTime;

    public static int DaysCounter;
    public int myDayCounter;
    public static bool NewDay;

    public int SlotNumber,RandomNumber;
    void Start()
    {
       switch(Random.Range(0,2))
        {
            case 0:
                State = true;
                break;
             case 1:
                State = false;
                break;
        }
        LifeTime = Random.Range(3, 11);
    }
   
    public void CallDay()
    {
        myDayCounter += 1;

       
        if (myDayCounter >= LifeTime && Done == false)
        {
            for (int i = 0; i < SM.Skins.Length; i++)
            {
                if (SM.Skins[i].Name == Name)
                {
                    if (State == true)
                    {


                        string val;
                        SM.Skins[i].Price += Random.Range(SM.Skins[i].OldPrice - (Mathf.Clamp(SM.Skins[i].OldPrice, SM.Skins[i].Price, SM.Skins[i].OldPrice / 50 * 100)), (SM.Skins[i].Price + (Mathf.Clamp(SM.Skins[i].OldPrice, SM.Skins[i].OldPrice, SM.Skins[i].OldPrice / 50 * 100))));
                        val = SM.Skins[i].Price.ToString("F2");

                        SM.Skins[i].Price = float.Parse(val);

                        SM.Skins[i].Price = Mathf.Clamp(SM.Skins[i].Price, 0.05f, SM.Skins[i].Price);
                        Price = SM.Skins[i].Price;
                        switch (Random.Range(0, 2))
                        {
                            case 0:
                                State = true;
                                break;
                            case 1:
                                State = false;
                                break;
                        }
                        LifeTime = Random.Range(3, 11);
                        myDayCounter = 0;
                        Done = true;
                        return;

                    }
                    if (State == false)
                    {

                        string val;
                        SM.Skins[i].Price -= Random.Range(SM.Skins[i].Price - (Mathf.Clamp(SM.Skins[i].OldPrice, SM.Skins[i].OldPrice, SM.Skins[i].OldPrice / 50 *  10)), (SM.Skins[i].OldPrice + (Mathf.Clamp(SM.Skins[i].OldPrice, SM.Skins[i].OldPrice, SM.Skins[i].OldPrice / 50 * 100))));
                        val = SM.Skins[i].Price.ToString("F2");

                        SM.Skins[i].Price = float.Parse(val);

                        SM.Skins[i].Price = Mathf.Clamp(SM.Skins[i].Price, 0.05f, SM.Skins[i].Price);
                        Price = SM.Skins[i].Price;


                        LifeTime = Random.Range(1, 4);
                        myDayCounter = 0;
                        Done = true;
                        return;




                    }

                }

            }
        }
        if (myDayCounter >= LifeTime && Done == true && AfterLifeTime == false)
        {
            for (int i = 0; i < SM.Skins.Length; i++)
            {
                if (SM.Skins[i].Name == Name)
                {

                    if (State == true)
                    {
                        string val;
                        SM.Skins[i].Price += Random.Range(SM.Skins[i].Price - (Mathf.Clamp(SM.Skins[i].OldPrice, SM.Skins[i].OldPrice, SM.Skins[i].OldPrice / 50 * 100)), (SM.Skins[i].OldPrice + (Mathf.Clamp(SM.Skins[i].OldPrice, SM.Skins[i].OldPrice, SM.Skins[i].OldPrice / 50 * 100))));
                        val = SM.Skins[i].Price.ToString("F2");

                        SM.Skins[i].Price = float.Parse(val);

                        SM.Skins[i].Price = Mathf.Clamp(SM.Skins[i].Price, 0.05f, SM.Skins[i].Price);
                        Price = SM.Skins[i].Price;

                        switch (Random.Range(0, 2))
                        {
                            case 0:
                                State = true;
                                break;
                            case 1:
                                State = false;
                                break;
                        }
                        LifeTime = Random.Range(3, 11);
                        myDayCounter = 0;
                        AfterLifeTime = true;
                        return;

                    }
                    if (State == false)
                    {

                        string val;
                        SM.Skins[i].Price -= Random.Range(SM.Skins[i].Price - (Mathf.Clamp(SM.Skins[i].OldPrice, SM.Skins[i].OldPrice, SM.Skins[i].OldPrice / 50 * 100)), (SM.Skins[i].OldPrice + (Mathf.Clamp(SM.Skins[i].OldPrice, SM.Skins[i].OldPrice, SM.Skins[i].OldPrice / 50 * 100))));
                        val = SM.Skins[i].Price.ToString("F2");

                        Price = float.Parse(val);

                        SM.Skins[i].Price = Mathf.Clamp(SM.Skins[i].Price, 0.05f, SM.Skins[i].Price);
                        Price = SM.Skins[i].Price;

                        SM.ChangeSkin(SlotNumber,RandomNumber);

                        LifeTime = Random.Range(1, 4);
                        myDayCounter = 0;
                        AfterLifeTime = true;
                        return;




                    }

                }

            }
        }
        if (myDayCounter >= LifeTime && Done == true && AfterLifeTime == true)
        {
            for (int i = 0; i < SM.Skins.Length; i++)
            {
                if (SM.Skins[i].Name == Name)
                {

                   
                        SM.ChangeSkin(SlotNumber, RandomNumber);


                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            State = true;
                            break;
                        case 1:
                            State = false;
                            break;
                    }
                    LifeTime = Random.Range(3, 11);
                    myDayCounter = 0;
                        AfterLifeTime = true;
                        return;




                    

                }

            }
        }


    }
}




