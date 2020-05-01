using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSkin : MonoBehaviour
{
    public Image SkinPreview;
    Image LastPreview;

    public Text Price, Rarity,Name;

    public GameObject SkinsPage, TradePage;

    private Inventory inventory;
    private MoneyManager MoneyM;

    public GameObject PayedMoney,QuantityPannel,SellPannel,SoldMoney;
    public Transform Canvas;

    float SkinPrice;
    Image SlotToSell;

    public GameObject SkinInfo, SlotsManager;

    public BelBala BB;

    public SkinsManager SM;

    public Quantity QuantityScript;
    public SellQuantity SellQuantityScript;

    float LatestPrice;

    public AudioPlayer AP;

    public int Fulls;

    public Animator NotificationsAnim;

    public GameObject NotifiSquare, NotifiSquare2;

    public Button Giga, BelBala;

    int FirstTime;

    void OnEnable()
    {
        if(FirstTime == 0)
        {
            NotificationsAnim.SetTrigger("Pop");
            NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "Buy a cheap skin to start investing!";
            AP.PlaySound("Notifcation");
            NotifiSquare.SetActive(false);
            Giga.interactable = true;
            BelBala.interactable = true;
            FirstTime = 1;
        } 
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(7f);
        NotificationsAnim.SetTrigger("Pop");
        NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "Click on the yellow square to come back to the home page!";
        AP.PlaySound("Notifcation");
        NotifiSquare2.SetActive(true);
    }
    void Start()
    {
        inventory = GameObject.Find("UIManager").GetComponent<Inventory>();
        MoneyM = GameObject.Find("UIManager").GetComponent<MoneyManager>();

    }
    public void SetSkin(Image Preview)
    {
        TradePage.SetActive(false);
        SkinsPage.SetActive(true);
        Price.text = "Price: " + Preview.transform.parent.GetComponent<SkinSettings>().Price.ToString() + "$";
        Rarity.text = "Exterior: " + Preview.transform.parent.GetComponent<SkinSettings>().Exterior.ToString();
        Name.text = Preview.transform.parent.GetComponent<SkinSettings>().Name.ToString();
        SkinPreview.sprite = Preview.sprite;
        LastPreview = Preview;

    }
    public void OpenPannel()
    {
        QuantityPannel.SetActive(true);
        QuantityPannel.transform.Find("Skin").Find("Preview").GetComponent<Image>().sprite = LastPreview.sprite;
        QuantityScript.MaxQuantity = LastPreview.transform.parent.GetComponent<SkinSettings>().Quanity;
        QuantityScript.PricePerOne = LastPreview.transform.parent.GetComponent<SkinSettings>().Price;
        

    }
    public void Buy()
    {
        
        if(MoneyM.MoneyAmount >= QuantityScript.TotalPrice && QuantityScript.SliderQuantity >= 1)
        {
            Fulls = 0;
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == true)
                {
                    Fulls += 1;
                }
                if (Fulls >= inventory.slots.Length && inventory.slots[i].GetComponent<Image>().sprite != LastPreview.sprite)
                {
                    NotificationsAnim.SetTrigger("Pop");
                    NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "Inventory is full! sell items!";
                }

                if (inventory.isFull[i] == true && inventory.slots[i].GetComponent<Image>().sprite == LastPreview.sprite)
                {




                    LastPreview.transform.parent.GetComponent<SkinSettings>().Quanity -= Mathf.RoundToInt(QuantityScript.SliderQuantity);
                    GameObject GO = Instantiate(PayedMoney, PayedMoney.transform.position, PayedMoney.transform.rotation);
                    GO.transform.SetParent(Canvas);
                    Destroy(GO, 1f);
                    GO.GetComponent<Text>().text = "-" + QuantityScript.TotalPrice.ToString() + "$";

                    string val;
                    val = QuantityScript.TotalPrice.ToString("F2");

                    MoneyM.MoneyAmount -= float.Parse(val);

                    MoneyM.UpdateMoney();
                    BB.UpdateTransactions(LastPreview.transform.parent.GetComponent<SkinSettings>().Price, LastPreview.transform.parent.GetComponent<SkinSettings>().Name, "Bought");
                    inventory.slots[i].GetComponent<Image>().transform.parent.GetComponent<SkinSettings>().Quanity += Mathf.RoundToInt(QuantityScript.SliderQuantity);
                    QuantityScript.ExitPannel();
                    AP.PlaySound("Cash");
                    break;
                }

                if (Fulls < inventory.slots.Length && inventory.isFull[i] == false && inventory.slots[i].GetComponent<Image>() != LastPreview)
                {
                    LastPreview.transform.parent.GetComponent<SkinSettings>().Quanity -= Mathf.RoundToInt(QuantityScript.SliderQuantity);
                    inventory.slots[i].GetComponent<Image>().sprite = LastPreview.sprite;
                    inventory.isFull[i] = true;
                    inventory.slots[i].GetComponent<Image>().enabled = true;
                    GameObject GO = Instantiate(PayedMoney, PayedMoney.transform.position, PayedMoney.transform.rotation);
                    GO.transform.SetParent(Canvas);
                    Destroy(GO, 1f);
                    GO.GetComponent<Text>().text = "-" + QuantityScript.TotalPrice.ToString() + "$";

                    string val;
                    val = QuantityScript.TotalPrice.ToString("F2");

                    MoneyM.MoneyAmount -= float.Parse(val);

                    MoneyM.UpdateMoney();
                    BB.UpdateTransactions(QuantityScript.TotalPrice, LastPreview.transform.parent.GetComponent<SkinSettings>().Name,"Bought");
                    inventory.slots[i].GetComponent<Image>().transform.parent.GetComponent<SkinSettings>().Quanity += Mathf.RoundToInt(QuantityScript.SliderQuantity);
                    QuantityScript.ExitPannel();
                    if(FirstTime == 1)
                    {
                        NotificationsAnim.SetTrigger("Pop");
                        NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "You can sell this item in your inventory!";
                        AP.PlaySound("Notifcation");
                        StartCoroutine("Next");
                        FirstTime += 1;
                    }
                    AP.PlaySound("Cash");
                    break;
                }
            
               
                
            }
            
        }
        else
        {
            if(QuantityScript.SliderQuantity == 0)
            {
                NotificationsAnim.SetTrigger("Pop");
                NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "Insert a quantity!";
            }
            if (MoneyM.MoneyAmount < QuantityScript.TotalPrice)
            {
                NotificationsAnim.SetTrigger("Pop");
                NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "Not enough money!";
            }

            AP.PlaySound("Cant");

        }

    } 

    public void OnSlotClick(Image CurrentSlot)
    {
        if(CurrentSlot.sprite != null)
        {
            SlotToSell = CurrentSlot;
            SlotsManager.SetActive(false);
            SkinInfo.SetActive(true);
            SkinInfo.transform.Find("Pannel").Find("Quantity").GetComponent<Text>().text = "Quantity:" + CurrentSlot.transform.parent.GetComponent<SkinSettings>().Quanity.ToString();
            for (int i = 0; i < SM.Skins.Length; i++)
            {
                if(SM.Skins[i].Preview == CurrentSlot.sprite)
                {
                    SkinInfo.transform.Find("Pannel").Find("Price").GetComponent<Text>().text = "Price: " + SM.Skins[i].Price.ToString() + "$";
                    LatestPrice = SM.Skins[i].Price;
                    SkinInfo.transform.Find("Skin").Find("Preview").GetComponent<Image>().sprite = CurrentSlot.sprite;
                    SkinInfo.transform.Find("Pannel").Find("Name").GetComponent<Text>().text = SM.Skins[i].Name.ToString();
                    SkinInfo.transform.Find("Pannel").Find("Exterior").GetComponent<Text>().text = SM.Skins[i].Exterior.ToString();




                }

            }


        }
    }

    public void OnSellPannelClick()
    {
        SellPannel.SetActive(true);
        SellPannel.transform.Find("Skin").Find("Preview").GetComponent<Image>().sprite = SlotToSell.sprite;
        SellQuantityScript.MaxQuantity = SlotToSell.transform.parent.GetComponent<SkinSettings>().Quanity;
        SellQuantityScript.PricePerOne = LatestPrice;

    }
    public void Sell()
    {
       
   if(SellQuantityScript.SliderQuantity >= 1)
        {
            GameObject GO = Instantiate(SoldMoney, SoldMoney.transform.position, SoldMoney.transform.rotation);
            GO.transform.SetParent(Canvas);
            Destroy(GO, 1f);
            GO.GetComponent<Text>().text = "+" + SellQuantityScript.TotalPrice.ToString() + "$";
            inventory.slots[SlotToSell.transform.parent.GetComponent<Slot>().Index].GetComponent<Image>().enabled = false;
            SlotToSell.transform.parent.GetComponent<SkinSettings>().Quanity -= Mathf.RoundToInt(SellQuantityScript.SliderQuantity);
            string val;
            val = SellQuantityScript.TotalPrice.ToString("F2");

            MoneyM.MoneyAmount += float.Parse(val);

            MoneyM.UpdateMoney();
            BB.UpdateTransactions(SellQuantityScript.TotalPrice, LastPreview.transform.parent.GetComponent<SkinSettings>().Name, "Sold");

            if (SlotToSell.transform.parent.GetComponent<SkinSettings>().Quanity <= 0)
            {
                SkinInfo.SetActive(false);
                SlotToSell.sprite = null;
                inventory.isFull[SlotToSell.transform.parent.GetComponent<Slot>().Index] = false;
                SlotsManager.SetActive(true);
            }
            AP.PlaySound("Cash");
            SellQuantityScript.ExitPannel();
        }
   else
        {
            NotificationsAnim.SetTrigger("Pop");
            NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "Insert a quantity!";
            AP.PlaySound("Cant");

        }


    }
}
