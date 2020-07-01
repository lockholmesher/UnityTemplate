using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;
[DisallowMultipleComponent]
public class CreateController : MonoBehaviour {

}

public class Creater : SingletonMonoBehaviour<CreateController>
{

}
