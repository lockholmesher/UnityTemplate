using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace  LTAUnityBase.Base.Controller
{
    public abstract class ProcessController : BehaviourController
    {
        [SerializeField]
        protected float maxValue;
        protected float currentsValue;

        //[SerializeField]
        //protected Image img;

        protected void EditValue(float value,Action OnCompleteProcessing = null){
            float previousValue = currentsValue;
            currentsValue = value;
            if (currentsValue <= 0) {
                currentsValue = 0;
            };
            if (currentsValue > maxValue) currentsValue = maxValue;
            UpdateValue(previousValue,currentsValue,OnUpdate,OnCompleteProcessing);
        }

        protected void SetValue(float value)
        {
            currentsValue = value;
            if (currentsValue <= 0) {
                currentsValue = 0;
            };
            if (currentsValue > maxValue) currentsValue = maxValue;
            OnUpdate(currentsValue);
        }

        protected abstract void OnUpdate(float value);
        //{
        //    if (img != null)
        //        img.fillAmount = (float) value/maxValue;
        //}

    
}
}
