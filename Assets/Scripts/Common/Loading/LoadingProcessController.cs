using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.Controller;
using System;
namespace LTAUnityBase.Base.BaseLoading
{
    [DisallowMultipleComponent]
    public class LoadingProcessController : ProcessController
    {
        [SerializeField]
        RectTransform rect;

        [SerializeField]
        Text txtProcessing;

        [SerializeField]
        float timeDelayEndLoad;

        public Action EndLoading = null;

        protected override void OnUpdate(float value)
        {
            txtProcessing.text = "Ðang tải: " + (int)(((float)value/maxValue)*100) + "%";
            rect.sizeDelta = new Vector2(value, rect.sizeDelta.y);
            if (value == maxValue)
            {
                if (EndLoading != null)
                {
                    EndLoading();
                    EndLoading = null;
                }
                StartCoroutine(DelayEndLoad());
            }
        }

        IEnumerator DelayEndLoad()
        {
            yield return new WaitForSeconds(timeDelayEndLoad);
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            maxValue = rect.sizeDelta.x;
            SetValue(0);
        }

        public void SetPercent(float percent)
        {
            Debug.Log(percent + " " + maxValue);
            EditValue(percent * maxValue);
        }

        private void OnDisable()
        {
            SetValue(0);
        }
    }
}
