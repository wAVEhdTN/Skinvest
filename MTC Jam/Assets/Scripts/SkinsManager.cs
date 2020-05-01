using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsManager : MonoBehaviour
{ 

    public Skins[] Skins;

    public int SalePercentage;

    public Image[] Slots;

    public List<int> TakeList = new List<int>();
    public List<int> RandomSkin = new List<int>();


    string val;

    void Start()
    {
        SetupPrices();
        SetupQuantites();
        for (int i = 0; i < Slots.Length; i++)
        {
            int randomNumber = Random.Range(0, (Slots.Length) + 1);

            while(TakeList.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, (Slots.Length) + 1);
            }

            TakeList[i] = randomNumber;
            Slots[i].sprite = Skins[TakeList[i]].Preview;
            Slots[i].transform.parent.gameObject.GetComponent<SkinSettings>().Price = Skins[TakeList[i]].Price;
            Slots[i].transform.parent.gameObject.GetComponent<SkinSettings>().Quanity = Skins[TakeList[i]].Quanity;
            Slots[i].transform.parent.gameObject.GetComponent<SkinSettings>().Name = Skins[TakeList[i]].Name;
            Slots[i].transform.parent.gameObject.GetComponent<SkinSettings>().Rarity = Skins[TakeList[i]].Rarity;
            Slots[i].transform.parent.gameObject.GetComponent<SkinSettings>().Exterior = Skins[TakeList[i]].Exterior;
            Slots[i].transform.parent.gameObject.GetComponent<SkinSettings>().SlotNumber = i;

        }
        foreach(Skins s in Skins)
        {
            s.OldPrice = s.Price;
        }
    }
    public void ChangeSkin(int mySlot,int mYRandomNumber)
    {
     
        int randomNumber;
        randomNumber = (Random.Range(TakeList.Count, Skins.Length));
        while (!RandomSkin.Contains(randomNumber))
        {
            RandomSkin.Add(randomNumber);
            Slots[mySlot].sprite = Skins[randomNumber].Preview;
            Slots[mySlot].transform.parent.gameObject.GetComponent<SkinSettings>().Price = Skins[randomNumber].Price;
            Slots[mySlot].transform.parent.gameObject.GetComponent<SkinSettings>().Quanity = Skins[randomNumber].Quanity;
            Slots[mySlot].transform.parent.gameObject.GetComponent<SkinSettings>().Name = Skins[randomNumber].Name;
            Slots[mySlot].transform.parent.gameObject.GetComponent<SkinSettings>().Rarity = Skins[randomNumber].Rarity;
            Slots[mySlot].transform.parent.gameObject.GetComponent<SkinSettings>().Exterior = Skins[randomNumber].Exterior;
            Slots[mySlot].transform.parent.gameObject.GetComponent<SkinSettings>().RandomNumber = randomNumber;
            RandomSkin.Remove(mYRandomNumber);


        }





    }
    void SetupPrices()
    {
        foreach (Skins s in Skins)
        {
            s.Quanity += Random.Range(s.Quanity - (Mathf.Clamp(s.Quanity, s.Quanity, s.Quanity / 35 * 100)), (s.Quanity + (Mathf.Clamp(s.Quanity, s.Quanity, s.Quanity / 35 * 100))));

           s.Quanity = Mathf.Clamp(s.Quanity, 0, s.Quanity);

        }

    }
    void SetupQuantites()
    {
        foreach (Skins s in Skins)
        {

                s.Price += Random.Range(s.Price - (Mathf.Clamp(s.Price, s.Price, s.Price / 35 * 10000)), (s.Price + (Mathf.Clamp(s.Price, s.Price, s.Price / 35 * 10000))));

                s.Price = Mathf.Clamp(s.Price, 0.01f, s.Price);

            val = s.Price.ToString("F2");

            s.Price = float.Parse(val);


            s.Price = Mathf.Clamp(s.Price, 0.01f, s.Price);

        }
    }
    public void SaleChange()
    {
        foreach(Skins s in Skins)
        {
            s.Price -= Random.Range(SalePercentage - 3, SalePercentage + 3);
            s.Price = Mathf.Clamp(s.Price, 0, s.Price);
        }
    }
   
}
