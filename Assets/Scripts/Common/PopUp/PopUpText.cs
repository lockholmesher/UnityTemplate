using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;
using LTAUnityBase.Base.Controller;
public class PopUpText : BasePopUp {
	[SerializeField]
	protected Text txtMessage;

	[SerializeField]
	protected RectTransform rectTransform;
	public void SetMes(string errorMessage,Action callbackClosePopUp = null)
	{
		StartCoroutine(ShowNormalMessage(errorMessage));
		_callbackClosePopUp = callbackClosePopUp;
	}

	IEnumerator ShowNormalMessage(string mes)
	{
		mes = Utils.CutString(mes,300);
		txtMessage.text = mes;
		yield return new WaitForEndOfFrame ();
		if (rectTransform != null)
        {
			Vector2 OriSize = rectTransform.sizeDelta;
			rectTransform.sizeDelta = new Vector2(OriSize.x,Mathf.Clamp(txtMessage.preferredHeight,300f,500f) + 20);
		}
		
	}

}
