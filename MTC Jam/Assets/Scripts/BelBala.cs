using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BelBala : MonoBehaviour
{
    public GameObject[] Transactions;
    int NextTransaction;

    public Color32 BuyColor, SellColor;
    public void UpdateTransactions(float Price,string Name,string State)
    {
        if(NextTransaction == 4)
        {
            NextTransaction = 0;
        }
        if(State == "Sold")
        {
            Transactions[NextTransaction].transform.Find("SkinName").GetComponent<Text>().text = Name.ToString();
            Transactions[NextTransaction].transform.Find("PayedAmount").GetComponent<Text>().text = "+" + Price.ToString() + "$";
            Transactions[NextTransaction].transform.Find("PayedAmount").GetComponent<Text>().color = SellColor;

        }
        if (State == "Bought")
        {
            Transactions[NextTransaction].transform.Find("SkinName").GetComponent<Text>().text = Name.ToString();
            Transactions[NextTransaction].transform.Find("PayedAmount").GetComponent<Text>().text = "-" + Price.ToString() + "$";
            Transactions[NextTransaction].transform.Find("PayedAmount").GetComponent<Text>().color = BuyColor;

        }
       NextTransaction += 1;
    }
}
