using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAutoDestroy
{
    bool IsAutoDestroy
    {
        get;
    }

    float TimeCountDestroy
    {
        get;
    }
}
