using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using System;
public class BaseVO
{

    protected JSONNode data;
    static Dictionary<string, JSONNode> datas = new Dictionary<string, JSONNode>();

    public static void PreloadDatas<T>() where T : TextAsset
    {
        string assetName = typeof(T).Name;
        JSONNode json;
        if (datas.TryGetValue(assetName, out json) == true)
        {
            return;
        }

        json = JSON.Parse(Resources.Load<TextAsset>("Data/" + assetName).text)["data"];
        if (json == null)
        {
            Debug.LogError("cannot load " + assetName);
            return;
        }

        datas[assetName] = json;
    }

    public static JSONNode LoadData(string dataName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Data/" + dataName);

        return JSON.Parse(textAsset.text);
    }

    protected void LoadDataLocal(string dataName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Data/" + dataName);
        data = JSON.Parse(textAsset.text)["data"];
    }

    public void LoadData(TextAsset textAsset)
    {
        data = JSON.Parse(textAsset.text)["data"];
    }

    public static T GetData<T>(string data_name) where T : struct
    {
        JSONNode json;
        if (datas.TryGetValue(data_name, out json) == false)
        {
            json = LoadData(data_name);
            if (json == null)
            {
                Debug.Log("cannot get data " + data_name);
                return new T();
            }
        }
        return JsonUtility.FromJson<T>(json.ToString());
    }

    public T GetData<T>(int level)
    {
        JSONArray array = data.AsArray;
        if (level > array.Count)
            return JsonUtility.FromJson<T>(array[array.Count - 1].ToString());
        return JsonUtility.FromJson<T>(array[level - 1].ToString());
    }

    public object GetData(string key,Type type)
    {
        JSONObject json = data.AsObject;
        if (json[key].IsNull) return null;

        return JsonUtility.FromJson(json[key].ToString(),type);
    }
}
