using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace LTAUnityBase.Base.UI.Effect
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class EffectBtnColor : BehaviourController,IPointerUpHandler, IPointerDownHandler,IEffect
	{
		[SerializeField]
		Color ToColor;

		Color originColor;

		Image img;

        void Start()
        {
			img = GetComponent<Image>();
			originColor = img.color;
        }

		public void OnPointerUp(PointerEventData eventData)
		{
			UpdateColor(ToColor,originColor, UpdateColorImage);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			UpdateColor(originColor, ToColor, UpdateColorImage);
		}

        void UpdateColorImage(Color color)
        {
			img.color = color;
        }

        public void ShowEffect()
        {
            throw new System.NotImplementedException();
        }

        public void HideEffect()
        {
            throw new System.NotImplementedException();
        }
    }
}

