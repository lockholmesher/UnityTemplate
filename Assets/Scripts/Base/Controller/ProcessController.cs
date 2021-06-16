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
        [SerializeField]
        protected float currentValue;

        protected void EditValue(float value,Action OnCompleteProcessing = null){
            float previousValue = currentValue;
            currentValue = value;
            if (currentValue <= 0) {
                currentValue = 0;
            };
            if (currentValue > maxValue) currentValue = maxValue;
            UpdateValue(previousValue,currentValue,OnUpdate,OnCompleteProcessing);
        }

        protected void SetValue(float value)
        {
            currentValue = value;
            if (currentValue <= 0) {
                currentValue = 0;
            };
            if (currentValue > maxValue) currentValue = maxValue;
            OnUpdate(currentValue);
        }

        protected abstract void OnUpdate(float value);
   
    }
}
