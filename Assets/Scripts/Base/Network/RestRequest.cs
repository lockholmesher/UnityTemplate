using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using LTAUnityBase.Base.BaseLoading;
namespace LTAUnityBase.Base.Network
{
    public class RestRequest
    {
        public UnityWebRequest request { get; private set; }

        public RestRequest(string url,string method)
        {
            request = new UnityWebRequest(url, method);
            request.timeout = 10;
        }

        public void AddHeader(string key, string value)
        {
            request.SetRequestHeader(key, value);
        }

        public void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> header in headers)
            {
                AddHeader(header.Key, header.Value);
            }
        }

        public void AddBody(string text, string contentType = "application/json")
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            this.AddBody(bytes, contentType, false);
        }

        public void AddBody(byte[] bytes, string contentType)
        {
            this.AddBody(bytes, contentType, false);
        }

        public void AddBody(byte[] bytes, string contentType, bool isChunked)
        {
            if (request.uploadHandler != null)
            {
                Debug.LogWarning("Request body can only be set once");
                return;
            }
            request.chunkedTransfer = isChunked;
            request.uploadHandler = new UploadHandlerRaw(bytes);
            request.uploadHandler.contentType = contentType;
        }

        public void SetQueryParams(QueryParams queryParams)
        {
           request.url += queryParams.ToString();
        }

        public IEnumerator IeRequest(ActionOnResponse onResponse,bool isShowLoading = true)
        {
            if (isShowLoading)
            {
                Loading.Instance.ShowNormalLoading();
            }
            
            Debug.Log(request.method + " " + request.url);
            if (request.uploadHandler != null)
            {
                Debug.Log(request.uploadHandler.contentType);
                Debug.Log(Encoding.UTF8.GetString(request.uploadHandler.data));
            }
            DownloadHandlerBuffer download = new DownloadHandlerBuffer();
            request.downloadHandler = download;
            yield return request.SendWebRequest();
            onResponse.onResponse(request);
        }
    }
}
