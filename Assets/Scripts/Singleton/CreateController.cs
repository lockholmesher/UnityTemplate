using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
[DisallowMultipleComponent]
public class CreateController : MonoBehaviour {

}

public class Creater : SingletonMonoBehaviour<CreateController>
{

}
