using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.Controller;
using System;
namespace LTAUnityBase.Base.UI.Effect
{
    public class EffectAlphaShow : BehaviourController,IEffect
    {
        Graphic graphic;

        [SerializeField]
        float firstAlpha,lastAlpha;

        Color originColor;

        private void Awake()
        {
            graphic = GetComponent<Graphic>();
            originColor = graphic.color;
        }

        public void HideEffect(Action endEffect = null)
        {
            UpdateValue(lastAlpha, firstAlpha, UpdateAlpha,()=>
            {
                gameObject.SetActive(false);
                if (endEffect != null)
                {
                    endEffect();
                }
            });
        }

        public void ShowEffect(Action endEffect = null)
        {
            gameObject.SetActive(true);
            UpdateValue(firstAlpha, lastAlpha, UpdateAlpha,endEffect);

        }

        public void ImHideEffect()
        {
            graphic.color = new Color(originColor.r, originColor.g, originColor.b, firstAlpha);
            gameObject.SetActive(false);
        }

        void UpdateAlpha(float value)
        {
            graphic.color = new Color(originColor.r, originColor.g, originColor.b, value);
        }

        public void Hide()
        {
            graphic.color = new Color(originColor.r, originColor.g, originColor.b, firstAlpha);
        }
    }

}
