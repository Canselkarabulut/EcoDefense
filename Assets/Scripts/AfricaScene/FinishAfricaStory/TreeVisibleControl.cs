using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeVisibleControl : MonoBehaviour
{
    private void Start()
    {
        TreeVisible(false, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cylinder")
        {
            TreeVisible(true, false);
        }
    }

    public void TreeVisible(bool zero, bool one)
    {
        transform.GetChild(0).gameObject.SetActive(zero);
        transform.GetChild(1).gameObject.SetActive(one);
    }
}