using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    Transform MyParent;
    void Start()
    {
        MyParent = transform.parent;
        transform.SetParent(null);

    }
    void Update()
    {
        transform.Rotate(0, 0, -500 * Time.deltaTime);
        if(MyParent == null)
        {
            Destroy(gameObject);
        }
    }
}
