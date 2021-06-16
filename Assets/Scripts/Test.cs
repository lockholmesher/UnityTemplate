using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IeStartTest());
    }

    IEnumerator IeStartTest()
    {
        yield return new WaitForSeconds(1f);
        PopUp.Instance.ShowPopUp<PopUpText>(PopUpName.PopUpText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
