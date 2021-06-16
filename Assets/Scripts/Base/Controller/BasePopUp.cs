using UnityEngine;
using UnityEngine.EventSystems;
using System;
using LTAUnityBase.Base.UI;
using LTAUnityBase.Base.UI.Effect;
using System.Collections.Generic;
using System.Collections;

namespace  LTAUnityBase.Base.Controller
{
	public abstract class BasePopUp : MonoBehaviour,IPointerClickHandler {

    [SerializeField]
	ButtonController BtnExit;

	IEffect[] effects;

    void Start()
	{
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
		effects = GetComponents<IEffect>();
		if (effects != null)
		{
             StartCoroutine(IeShowEffects(() =>
				{
					 currentTypeClosePopUp = typeClosePopUp;
				}));
		}
	}

	IEnumerator IeShowEffects(Action endShowEffect)
    {
		int countShow = 0;
		foreach (IEffect effect in effects)
        {
			effect.Hide();
			effect.ShowEffect(()=>
			{
				countShow++;
			});
        }
		yield return new WaitUntil(()=> countShow >= effects.Length);
		if (endShowEffect != null)
            {
				endShowEffect();
            }
	}

	IEnumerator IeHideEffects(Action endHideEffect)
	{
		int countShow = 0;
		foreach (IEffect effect in effects)
		{
				effect.HideEffect(() =>
				{
					countShow++;
				});
		}
		yield return new WaitUntil(() => countShow >= effects.Length);
		if (endHideEffect != null)
		{
			endHideEffect();
		}
	}

	public void OnPointerClick (PointerEventData eventData)
	{
	    Debug.Log(currentTypeClosePopUp);
		if (currentTypeClosePopUp == TypeClosePopUp.ClickUpToClose) {
			ClosePopUp ();
		}
	}

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
			if (effects != null)
			{
				StartCoroutine(IeHideEffects(() =>
				{
					if (_callbackClosePopUp != null)
						_callbackClosePopUp();
					PopUp.Instance.ClosePopUp(this);
				}));
			}
	}
	}
}

