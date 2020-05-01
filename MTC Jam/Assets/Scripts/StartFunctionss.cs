using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartFunctionss : MonoBehaviour
{
    public Fan FanScript;

    public GameObject[] Activators;
    public GameObject[] FirstActivators;

    public GameObject StartPannel;

    public Animator NotificationsAnim;

    public AudioPlayer AP;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && StartPannel.activeSelf == true)
        {
            FanScript.enabled = true;
            foreach (GameObject a in FirstActivators)
            {
                a.SetActive(true);
            }
            StartCoroutine("Startup");
            StartPannel.SetActive(false);
        }
    }
    
    IEnumerator Startup()
    {
        yield return new WaitForSeconds(4f);
        foreach (GameObject a in Activators)
        {
            a.SetActive(true);
        }
        foreach (GameObject a in FirstActivators)
        {
            a.SetActive(false);
        }
        NotificationsAnim.SetTrigger("Pop");
        NotificationsAnim.transform.Find("NotificationText").GetComponent<Text>().text = "Enter Top deal to unlock other websites!";
        AP.PlaySound("Notifcation");


    }
}
