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

        [SerializeField]
        protected bool isClicked = false;


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

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (isClicked) return;
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (isClicked) return;
            base.OnPointerUp(eventData);
        }
    }
}

