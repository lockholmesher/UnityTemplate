using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
using System;
namespace LTAUnityBase.Base.UI.Effect
{
    public class EffectLayer : BehaviourController,IEffect
    {
        public void Hide()
        {
            
        }

        public void HideEffect(Action endHideEffect)
        {
            if (endHideEffect != null)
            {
                endHideEffect();
            }
        }

        public void ShowEffect(Action endShowEffect)
        {
            transform.SetAsLastSibling();
            if (endShowEffect != null)
            {
                endShowEffect();
            }
        }
    }
}
