using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GigaSlots : MonoBehaviour
{
    public float Price;
    public int Number;

    public GameObject MyPc;

    void Start()
    {
        transform.Find("PcPrice").GetComponent<Text>().text = Price + "$";
    }

}
