using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System;
using LTAUnityBase.Base.UI.Effect;

namespace LTAUnityBase.Base.UI
{
	[DisallowMultipleComponent]
	public class ButtonController : EffectController, IPointerClickHandler, IPointerUpHandler,IPointerDownHandler
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

        public virtual void OnPointerUp(PointerEventData eventData)
        {
			HidEffect();
		}

        public virtual void OnPointerDown(PointerEventData eventData)
        {
			ShowEffect();
        }
    }
}
