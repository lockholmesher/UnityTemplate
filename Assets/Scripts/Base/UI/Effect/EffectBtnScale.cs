using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using LTAUnityBase.Base.Controller;
using System;
namespace LTAUnityBase.Base.UI.Effect
{
	[DisallowMultipleComponent]
	public class EffectBtnScale : BehaviourController,IEffect
	{
		public float toScale = 1.08f;

		Vector3 originScale;

        private void Awake()
        {
			originScale = transform.localScale;
        }

        public void ShowEffect(Action endShowEffect)
        {
			ScaleUpdate(Vector3.one * toScale);
		}

        public void HideEffect(Action endHideEffect)
		{
			ScaleUpdate(originScale);
		}

        public void Hide()
        {
            transform.localScale = originScale;
        }
    }
}
