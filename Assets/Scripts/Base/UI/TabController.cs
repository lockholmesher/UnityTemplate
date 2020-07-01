using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.UI.Effect;
using UnityEngine.EventSystems;

namespace LTAUnityBase.Base.UI
{
    [DisallowMultipleComponent]
    public class TabController : ButtonController
    {
        
        private IEffect[] effects;

        [SerializeField]
        protected bool isClicked = false;

        protected virtual void Awake()
        {
            effects = (IEffect[])GetComponents(typeof(IEffect));
        }

        void ShowEffect()
        {
            foreach (IEffect effect in effects)
            {
                effect.ShowEffect();
            }
        }

        void HidEffect()
        {
            foreach (IEffect effect in effects)
            {
                effect.HideEffect();
            }
        }


        void EnableEffect(bool enable)
        {
            foreach (IEffect effect in effects)
            {
                ((Behaviour)effect).enabled = enable;
            }
        }

        public virtual bool IsClicked
        {
            set
            {
                isClicked = value;
                if (isClicked)
                {
                    ShowEffect();
                }
                else
                {
                    HidEffect();
                }
                EnableEffect(!isClicked);
            }
        }


        public override void OnPointerClick(PointerEventData eventData)
        {
            if (isClicked) return;
            base.OnPointerClick(eventData);
        }
    }
}

