using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GigaPc : MonoBehaviour
{
    public GameObject[] Buttons;

    public Transform PcPoint;
    public GameObject LastPc, SelectedPc, SelectedSlot, PayedMoney;

    public MoneyManager MoneyM;

    public float price;

    public AudioPlayer AP;

    public BelBala BB;
    public Transform Canvas;

    public Animator NotificationsAnim;


    void OnDisable()
    {
        price = 0;
        foreach (GameObject button in Buttons)
        {
            button.GetComponent<Image>().color = new Color32(255, 255, 255, 96);

        }
        SelectedSlot = null;
        SelectedPc = null;
    }
    public void SelectSlot(GameObject myGo)
    {
        foreach (GameObject button in Buttons)
        {
            button.GetComponent<Image>().color = new Color32(255, 255, 255, 96);

        }
        price = myGo.GetComponent<GigaSlots>().Price;
        SelectedPc = myGo.GetComponent<GigaSlots>().MyPc;
        SelectedSlot = myGo;
        myGo.GetComponent<Image>().color = new Color32(255, 255, 203, 174);

    }

    public void BuyPc()
    {
        if (MoneyM.MoneyAmount >= price && SelectedPc != null && LastPc.GetComponent<PcScript>().PcNumber != SelectedSlot.GetComponent<GigaSlots>().Number)
        {
            AP.PlaySound("Cash");
            Destroy(LastPc);
            LastPc = Instantiate(SelectedPc, PcPoint.position, PcPoint.rotation);
            LastPc.GetComponent<PcScript>().PcNumber = SelectedSlot.GetComponent<GigaSlots>().Number;

            GameObject GO = Instantiate(PayedMoney, PayedMoney.transform.position, PayedMoney.transform.rotation);
            GO.transform.SetParent(Canvas);
            GO.GetComponent<Text>().text = "-" + price.ToString() + "$";
            Destroy(GO, 1f);

            MoneyM.UpdateMoney();
            BB.UpdateTransactions(price, "PC", "Bought");
        }
        else
        {
            NotificationsAnim.SetTrigger("Pop");
            NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "Not enough money!";

            AP.PlaySound("Cant");

        }

    }
}
