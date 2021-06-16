using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
using UnityEngine.UI;
using System;
using LTAUnityBase.Base.UI;
public class PopUpInput : BasePopUp
{
    [SerializeField]
    InputField input;
    [SerializeField]
    ButtonController BtnSubmit;

    [SerializeField]
    protected Text txtTitle;

    // Start is called before the first frame update
    public void SetPopUp(string Mes, Action<string> CallBackSubmit = null)
    {
        Mes = Utils.CutString(Mes, 100);
        txtTitle.text = Mes;
        BtnSubmit.OnClick((btn) =>
        {
            CallBackSubmit(input.text);
            ClosePopUp();
        });
    }
}
