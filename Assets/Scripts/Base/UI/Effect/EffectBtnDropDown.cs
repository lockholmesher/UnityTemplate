using LTAUnityBase.Base.Controller;
using UnityEngine;
using System;
namespace LTAUnityBase.Base.UI.Effect
{
    public class EffectBtnDropDown : BehaviourController,IEffect
    {
        float openSize = 798f;
        float closeSize = 235f;

        [SerializeField]
        GameObject blurImage;

        RectTransform currentRect;

        //public CreateRoomType roomType = CreateRoomType.PLO;
        private void Awake()
        {
            _LeanTweenType = LeanTweenType.linear;
            timePerforme = 0.5f;
            currentRect = GetComponent<RectTransform>();
            //currentRect.sizeDelta = new Vector2(currentRect.rect.width, closeSize);
        }

        public void HideEffect(Action endHideEffect)
        {
            blurImage.SetActive(true);
            UpdateValue(currentRect.rect.height, closeSize, OnUpdate,endHideEffect);
        }

        private void OnUpdate(float value)
        {
            currentRect.sizeDelta = new Vector3(currentRect.rect.width, value);
        }

        public void ShowEffect(Action endShowEffect)
        {
            blurImage.SetActive(false);
            UpdateValue(currentRect.rect.height, openSize, OnUpdate,endShowEffect);
        }

        public void Hide()
        {
            currentRect.sizeDelta = new Vector3(currentRect.rect.width, closeSize);
        }
    }
}
