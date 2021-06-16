using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LTAUnityBase.Base.DesignPattern;
using LTAUnityBase.Base.Controller;
namespace LTAUnityBase.Base.BaseLoading
{
    [DisallowMultipleComponent]
    public class LoadingController : MonoBehaviour
    {
        [SerializeField]
        LoadingProcessController loadingProcessController;

        [SerializeField]
        GameObject normalLoading;


        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            ExitLoading();
        }

        private void Start()
        {
            ShowLoadingProcess(1f, () =>
            {
                SceneController.OpenScene(AllSceneName.Login);
            });
        }

        public void ShowLoadingProcess(float percent,Action EndLoading = null)
        {
            
            if (EndLoading != null)
            {
                loadingProcessController.EndLoading = EndLoading;
                loadingProcessController.gameObject.SetActive(true);
            }
            loadingProcessController.SetPercent(percent);
        }

        public void ExitLoading()
        {
            Debug.Log("ExitLoading");
            loadingProcessController.EndLoading = null;
            loadingProcessController.gameObject.SetActive(false);
            normalLoading.SetActive(false);
        }

        public void ShowNormalLoading()
        {
            normalLoading.SetActive(true);
        }
    }
    public class Loading : SingletonMonoBehaviour<LoadingController>
    {

    }
}

