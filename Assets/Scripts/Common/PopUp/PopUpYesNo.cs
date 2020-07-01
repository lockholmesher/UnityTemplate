
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.Controller;
using System;
using LTAUnityBase.Base.UI;
public class PopUpYesNo : BasePopUp {

	[SerializeField]
	protected Text txtMessage;

	[SerializeField]
	private ButtonController BtnYes;

    [SerializeField]
    private ButtonController BtnNo;

    public void SetPopUp(string Mes, Action CallBackYes =  null)
    {
        Mes = Utils.CutString(Mes, 200);
        txtMessage.text = Mes;
        BtnYes.OnClick((btn) =>
        {
            CallBackYes();
            ClosePopUp();
        });
        BtnNo.OnClick((btn) =>
        {
            ClosePopUp();
        });
    }

    //public void SetPopUp(string Mes,string YesText,string NoText, Action CallBackYes = null)
    //{
    //    BtnYes.GetComponentInChildren<Text>().text = YesText;
    //    BtnNo.GetComponentInChildren<Text>().text = NoText;
    //    Mes = Utils.CutString(Mes, 100);
    //    txtMessage.text = Mes;
    //    BtnYes.OnClick((btn) =>
    //    {
    //        CallBackYes();
    //        ClosePopUp();
    //    });
    //    BtnNo.OnClick((btn) =>
    //    {
    //        ClosePopUp();
    //    });
    //}

}
