using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public float MoneyAmount;

    public Text Money,Balance;

   public void UpdateMoney()
    {
        Money.text = MoneyAmount.ToString("F2") + "$";
        Balance.text = MoneyAmount.ToString("F2") + "$";

    }
}
