using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.Controller;
namespace LTAUnityBase.Base.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Text))]
    public class TextMoney : BehaviourController
    {
        public Text m_Text;

        long currentValue;

        public long Value
        {
            get
            {
                return currentValue;
            }
        }

        private void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        public void SetMoney(long newValue)
        {
            if (newValue < 0)
                currentValue = 0;
            else
                currentValue = newValue;
            if (m_Text == null) return;
            m_Text.text = currentValue.ToString();
        }

        public void ChangeMoney(long newValue)
        {
            long prevValue = currentValue;
            currentValue = newValue;
            UpdateValue(prevValue, currentValue, UpdateMoney);
        }

        public void UpdateMoney(float value)
        {
            if (m_Text == null) return;
            m_Text.text = value.ToString();
        }
    }
}

