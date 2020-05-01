using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellQuantity : MonoBehaviour
{
    public float MaxQuantity;
    public float SliderQuantity;
    public float PricePerOne, TotalPrice;

    public Slider QuantitySlider;
    public InputField QunatityText;
    public Text MaxText, TotalPriceText;

   
    void Update()
    {
        if (MaxText.text != MaxQuantity.ToString("0"))
        {
            MaxText.text = MaxQuantity.ToString("0");

        }

    }
    public void UpdateQuantity()
    {
        float val;
        val = float.Parse(QunatityText.text);
        SliderQuantity = val;
        SliderQuantity = Mathf.Clamp(SliderQuantity, 0, MaxQuantity);

        QuantitySlider.value = SliderQuantity / MaxQuantity;
        QunatityText.text = SliderQuantity.ToString("0");
        TotalPrice = SliderQuantity * PricePerOne;
        TotalPriceText.text = TotalPrice.ToString("F2") + "$";
    }

    public void ChangeQuantity()
    {

        SliderQuantity = QuantitySlider.value * MaxQuantity;
        string val2;
        val2 = SliderQuantity.ToString("0");
        SliderQuantity = float.Parse(val2);
        QunatityText.text = SliderQuantity.ToString("0");

        TotalPrice = SliderQuantity * PricePerOne;
        TotalPriceText.text = TotalPrice.ToString("F2") + "$";

    }

    public void ExitPannel()
    {
        MaxQuantity = 0;
        SliderQuantity = 0;
        PricePerOne = 0;
        TotalPrice = 0;
        QuantitySlider.value = 0;
        gameObject.SetActive(false);

    }
}
