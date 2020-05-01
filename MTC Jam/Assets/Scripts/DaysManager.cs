using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaysManager : MonoBehaviour
{
    public int Days;

    public float DayTime;

    public Text DaysText;

    public string[] Months;
    public int[] MaxDays;
    public int Year;

    int MonthIndex;
    public int totalDays;

    int SaleEnd;

    public Animator NotificationsAnim;

    public SkinSettings[] SS;

    public SkinsManager SM;

    public bool CanGo;

    public AudioPlayer AP;
    void Start()
    {
        Days = 1;
        StartCoroutine("CountDays");
    }

    IEnumerator CountDays()
    {
       
        yield return new WaitForSeconds(DayTime);
        if (CanGo == false)
        {


            totalDays += 1;
            Days += 1;
            DaysText.text = Days.ToString() + " " + Months[MonthIndex].ToString() + " " + Year.ToString();
            foreach (Skins s in SM.Skins)
            {
                string val;

                switch (Random.Range(0, 2))
                {
                    case 0:
                        s.Price += Random.Range(s.OldPrice - (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100)), (s.OldPrice + (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100))));
                        break;
                    case 1:
                        s.Price -= Random.Range(s.OldPrice - (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100)), (s.OldPrice + (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100))));
                        break;
                }
                val = s.Price.ToString("F2");

                s.Price = float.Parse(val);

                s.Price = Mathf.Clamp(s.Price, 0.05f, s.Price);

                foreach (SkinSettings sK in SS)
                {
                    if (sK.Name == s.Name)
                    {
                        sK.Price = s.Price;

                    }
                }
            }
            foreach (SkinSettings s in SS)
            {
                s.CallDay();
            }
            if (totalDays == 136)
            {
                AP.PlaySound("Notifcation");
                NotificationsAnim.SetTrigger("Pop");
                NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "It's spring sale!";
                SaleEnd = 143; //Spring sale
            }

            if (totalDays >= 136 && totalDays < 143)
            {
                foreach (Skins s in SM.Skins)
                {
                    string val;


                    s.Price = s.OldPrice;
                    s.Price -= Random.Range(s.OldPrice - (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100)), (s.OldPrice + (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100))));

                    val = s.Price.ToString("F2");

                    s.Price = float.Parse(val);

                    s.Price = Mathf.Clamp(s.Price, 0.05f, s.Price);

                    foreach (SkinSettings sK in SS)
                    {
                        if (sK.Name == s.Name)
                        {
                            sK.Price = s.Price;

                        }
                    }
                }
                foreach (SkinSettings s in SS)
                {
                    s.CallDay();
                }


            }
            if (totalDays == 172)
            {
                AP.PlaySound("Notifcation");
                NotificationsAnim.SetTrigger("Pop");
                NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "It's summer sale!";
                SaleEnd = 186; //Summer sale
            }
            if (totalDays >= 172 && totalDays < 186)
            {

                foreach (Skins s in SM.Skins)
                {
                    string val;


                    s.Price = s.OldPrice;
                    s.Price -= Random.Range(s.OldPrice - (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100)), (s.OldPrice + (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100))));

                    val = s.Price.ToString("F2");

                    s.Price = float.Parse(val);

                    s.Price = Mathf.Clamp(s.Price, 0.05f, s.Price);

                    foreach (SkinSettings sK in SS)
                    {
                        if (sK.Name == s.Name)
                        {
                            sK.Price = s.Price;

                        }
                    }
                }
                foreach (SkinSettings s in SS)
                {
                    s.CallDay();
                }


            }
            if (totalDays == 298)
            {
                AP.PlaySound("Notifcation");
                NotificationsAnim.SetTrigger("Pop");
                NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "It's halloween sale!";
                SaleEnd = 305; //Halloween sale
            }
            if (totalDays >= 298 && totalDays < 305)
            {
                foreach (Skins s in SM.Skins)
                {
                    string val;


                    s.Price = s.OldPrice;
                    s.Price -= Random.Range(s.OldPrice - (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100)), (s.OldPrice + (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100))));

                    val = s.Price.ToString("F2");

                    s.Price = float.Parse(val);

                    s.Price = Mathf.Clamp(s.Price, 0.05f, s.Price);

                    foreach (SkinSettings sK in SS)
                    {
                        if (sK.Name == s.Name)
                        {
                            sK.Price = s.Price;

                        }
                    }
                }
                foreach (SkinSettings s in SS)
                {
                    s.CallDay();
                }


            }
            if (totalDays == 332)
            {
                AP.PlaySound("Notifcation");
                NotificationsAnim.SetTrigger("Pop");
                NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "It's black friday!";

                SaleEnd = 335; //Black friday
            }
            if (totalDays >= 332 && totalDays < 335)
            {
                foreach (Skins s in SM.Skins)
                {
                    string val;


                    s.Price = s.OldPrice;
                    s.Price -= Random.Range(s.OldPrice - (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100)), (s.OldPrice + (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100))));

                    val = s.Price.ToString("F2");

                    s.Price = float.Parse(val);

                    s.Price = Mathf.Clamp(s.Price, 0.05f, s.Price);

                    foreach (SkinSettings sK in SS)
                    {
                        if (sK.Name == s.Name)
                        {
                            sK.Price = s.Price;

                        }
                    }
                }
                foreach (SkinSettings s in SS)
                {
                    s.CallDay();
                }

            }
            if (totalDays == 353)
            {
                AP.PlaySound("Notifcation");
                NotificationsAnim.SetTrigger("Pop");
                NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "It's winter sale!";
                SaleEnd = 365; //Winter sale
            }
            if (totalDays >= 353 && totalDays < 365)
            {
                foreach (Skins s in SM.Skins)
                {
                    string val;


                    s.Price = s.OldPrice;
                    s.Price -= Random.Range(s.OldPrice - (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100)), (s.OldPrice + (Mathf.Clamp(s.OldPrice, s.OldPrice, s.OldPrice / 50 * 100))));

                    val = s.Price.ToString("F2");

                    s.Price = float.Parse(val);

                    s.Price = Mathf.Clamp(s.Price, 0.05f, s.Price);

                    foreach (SkinSettings sK in SS)
                    {
                        if (sK.Name == s.Name)
                        {
                            sK.Price = s.Price;

                        }
                    }
                }
                foreach (SkinSettings s in SS)
                {
                    s.CallDay();
                }


            }

            if (Days == MaxDays[MonthIndex])
            {

                if (Months[MonthIndex] == "December")
                {
                    Year += 1;
                    MonthIndex = 0;
                    Days = 0;
                    totalDays = 0;
                }
                else
                {
                    MonthIndex += 1;
                    Days = 0;
                }
            }
        }
            StartCoroutine("CountDays");

    }
}
