using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
namespace LTAUnityBase.Base.UI.Effect
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class EffectBtnColor : BehaviourController,IEffect
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

        void UpdateColorImage(Color color)
        {
			img.color = color;
        }

        public void ShowEffect(Action endShowEffect)
        {
            UpdateColor(originColor, ToColor, UpdateColorImage,endShowEffect);
        }

        public void HideEffect(Action endHideEffect)
        {
            UpdateColor(ToColor, originColor, UpdateColorImage,endHideEffect);
        }

        public void Hide()
        {
            img.color = originColor;
        }
    }
}

