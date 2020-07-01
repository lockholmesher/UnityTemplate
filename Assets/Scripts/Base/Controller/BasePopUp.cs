using UnityEngine;
using UnityEngine.EventSystems;
using System;
using LTAUnityBase.Base.UI;
namespace  LTAUnityBase.Base.Controller
{
	public abstract class BasePopUp : BehaviourController,IPointerClickHandler {
		#region IPointerClickHandler implementation

    [SerializeField]
	ButtonController BtnExit;
	void Start()
	{
		this.transform.localScale = Vector3.zero;
		if (BtnExit != null)
            {
				typeClosePopUp = TypeClosePopUp.ClickButtonToClose;
				BtnExit.OnClick((ButtonController Btn)=>
				{
					ClosePopUp();
				});
            }
            else
            {
				typeClosePopUp = TypeClosePopUp.ClickUpToClose;
            }
		ScaleTo(Vector3.one,()=>{
            
			currentTypeClosePopUp = typeClosePopUp;
		});
	}

	public void OnPointerClick (PointerEventData eventData)
	{
	    Debug.Log(currentTypeClosePopUp);
		if (currentTypeClosePopUp == TypeClosePopUp.ClickUpToClose) {
			ClosePopUp ();
		}
	}

	#endregion

	public enum TypeClosePopUp
	{
		ClickUpToClose,
		ClickButtonToClose,
		None

	}

	protected Action _callbackClosePopUp;


	[SerializeField]
	protected TypeClosePopUp typeClosePopUp = TypeClosePopUp.ClickUpToClose;
	protected TypeClosePopUp currentTypeClosePopUp = TypeClosePopUp.None;
	public void ClosePopUp()
	{
        ScaleTo(Vector3.zero,()=>{
			if (_callbackClosePopUp != null)
			    _callbackClosePopUp ();
			PopUp.Instance.ClosePopUp (this);
		});
	}
}
}

