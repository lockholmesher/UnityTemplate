using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
using UnityEngine.UI;
using System;
namespace LTAUnityBase.Base.UI.Effect
{
    public class EffectFlyShow : BehaviourController,IEffect
    {
        [SerializeField]
        float firstY, lastY;

        public void Hide()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, firstY, transform.localPosition.z);
        }

        public void HideEffect(Action endHideEffect)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, lastY, transform.localPosition.z);
            Vector3 newPos = new Vector3(transform.localPosition.x, firstY, transform.localPosition.z);

            MoveUpdateLocal(newPos,endHideEffect);
        }

        public void ShowEffect(Action endShowEffect)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, firstY, transform.localPosition.z);
            Vector3 newPos = new Vector3(transform.localPosition.x,lastY,transform.localPosition.z);
            
            MoveUpdateLocal(newPos,endShowEffect);
        }
    }

}
