using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMutilVO
{
    Dictionary<string, BaseVO> dic_Data = new Dictionary<string, BaseVO>();

    protected void LoadData<T>(string dataName) where T : BaseVO,new()
    {
        TextAsset[] texts = Resources.LoadAll<TextAsset>("Data/"+dataName);

        foreach (TextAsset text in texts)
        {
            T data = new T();
            data.LoadData(text);
            dic_Data.Add(text.name,data);
        }
    }

    public T GetData<T>(string type, int level)
    {
        return dic_Data[type].GetData<T>(level);
    }
}
