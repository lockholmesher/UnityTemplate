using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System;
namespace LTAUnityBase.Base.UI
{
	[DisallowMultipleComponent]
	public class ButtonController : MonoBehaviour, IPointerClickHandler
	{

		protected Action<ButtonController> callBackClick;

		public void OnClick(Action<ButtonController> _callBackClick)
		{
			if (_callBackClick != null)
				callBackClick = _callBackClick;
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (callBackClick != null)
				callBackClick(this);
		}
	}
}
