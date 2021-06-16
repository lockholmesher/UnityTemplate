using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
using System;
namespace LTAUnityBase.Base.UI.Effect
{
    public enum TypeEffect
    {
        FromLeft,
        FromRight,
        FromBottom,
        FromTop
    }

    public class EffectSlide : BehaviourController,IEffect
    {
        [SerializeField]
        TypeEffect typeEffect;
        [SerializeField]
        Vector3 originPos;
        [SerializeField]
        Vector3 hidePos;

        protected virtual void Awake()
        {
            originPos = transform.localPosition;
            switch(typeEffect)
            {
                case TypeEffect.FromBottom:
                    hidePos = originPos + Vector3.down  * Screen.height*2;
                    break;
                case TypeEffect.FromLeft:
                    hidePos = originPos + Vector3.left  * Screen.width*2;
                    break;
                case TypeEffect.FromRight:
                    hidePos = originPos + Vector3.right * Screen.width*2;
                    break;
                case TypeEffect.FromTop:
                    hidePos = originPos + Vector3.up    * Screen.height*2;
                    break;
            }
        }

        public void HideEffect(Action endHideEffect)
        {
            
            MoveUpdateLocal(hidePos,()=>
            {
                if (endHideEffect != null)
                    endHideEffect();
                gameObject.SetActive(false);
            });
        }

        public void ShowEffect(Action endShowEffect)
        {
            gameObject.SetActive(true);
            MoveUpdateLocal(originPos,endShowEffect);
        }

        public void Hide()
        {
            transform.localPosition = hidePos;
        }
    }
}

