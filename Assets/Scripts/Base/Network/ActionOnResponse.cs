
using UnityEngine;
using System;
using UnityEngine.Networking;
using SimpleJSON;
using LTAUnityBase.Base.BaseLoading;
namespace LTAUnityBase.Base.Network
{
    public class ActionOnResponse
    {
        private Action<string> onSuccess;
        private Action<byte[]> onSuccessBytes;
        private Action<string> onError;
        private bool isShowPopUp;

        public ActionOnResponse(Action<string> onSuccess, Action<string> onError = null,bool isShowPopUp = true)
        {
            this.onSuccess = onSuccess;
            this.onError = onError;
            this.isShowPopUp = isShowPopUp;
        }

        public ActionOnResponse(Action<byte[]> onSuccess, Action<string> onError = null)
        {
            this.onSuccessBytes = onSuccess;
            this.onError = onError;
        }

        public void onResponse(UnityWebRequest request)
        {
            Loading.Instance.ExitLoading();
            Debug.Log("onResponse " + request.responseCode + " " + request.downloadHandler.text);
            if (request.isNetworkError)
            {
                //DefautOnError(request.error);
                DefautOnError("Timeout occurred . Please try again");
                return;
            }
            string data = request.downloadHandler.text;
            if (request.isHttpError)
            {
                if (request.responseCode == 401)
                {
                    //DownloadController.Instance.RemoveAllVideos();
                    PlayerPrefs.DeleteAll();
                    ErrorController.Instance.DoError(ErrorIndex.ErrorAuthentication,()=>
                    {
                        SceneController.OpenScene(AllSceneName.Login);
                    });
                    return;
                }
                JSONNode json = JSON.Parse(data);
                if (json["errors"] != null)
                {
                    JSONNode errors = json["errors"];
                    if (errors["message"] != null)
                    {
                        DefautOnError(errors["message"]);
                        return;
                    }
                }
                DefautOnError(request.error);
                return;
            }
            
            if (request.responseCode < 300)
            {
                if (onSuccess != null)
                    onSuccess(data);
                if (onSuccessBytes != null)
                    onSuccessBytes(request.downloadHandler.data);
                return;
            }
            DefautOnError(data);
        }

        private void DefautOnError(string error)
        {
            
            if (isShowPopUp)
            {
                PopUpText popup = PopUp.Instance.ShowPopUp<PopUpText>(PopUpName.PopUpText);
                popup.SetMes(error);
            }
            if (onError != null)
            {
                onError(error);
                return;
            }
            
            Debug.LogError("onError " + error);
        }
    }
}