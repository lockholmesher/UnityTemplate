using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.Controller;
using LTAUnityBase.Base.DesignPattern;
public class PopUpName
{
	public const string PopUpText = "PopUpText";
	public const string PopUpYesNo = "PopUpYesNo";
    public const string PopUpInput = "PopUpInput";
}
[DisallowMultipleComponent]
public class PopUpController : MonoBehaviour {

	[SerializeField]
	private Transform canvas;

	void Awake()
	{
        DontDestroyOnLoad(this.gameObject);
        if (canvas == null)
            canvas = GetComponent<Transform>();
    }

	public List<BasePopUp> listCurrentPopUp = new List<BasePopUp>();
	public T ShowPopUp<T>(string _PopUpName) where T : BasePopUp
	{
        canvas.gameObject.SetActive(true);
        T PopUp = GameObject.Instantiate(Resources.Load<GameObject>("PopUp/" + _PopUpName), canvas).GetComponentInChildren<T>();
        PopUp.name = _PopUpName;
        PopUp.transform.localPosition = Vector3.zero;
        PopUp.transform.localScale = Vector3.one;
        listCurrentPopUp.Add(PopUp);
        return PopUp;
    }

	public void ClosePopUp(BasePopUp _PopUp)
	{
		if (listCurrentPopUp.Contains(_PopUp)) {
            GameObject.Destroy(_PopUp.transform.parent.gameObject);
            //GameObject.Destroy (_PopUp.gameObject);
			listCurrentPopUp.Remove (_PopUp);
		}
        if (listCurrentPopUp.Count == 0) canvas.gameObject.SetActive(false);
    }

    public void CloseAllPopUp()
    {
        foreach (BasePopUp popUp in listCurrentPopUp)
        {
            GameObject.Destroy(popUp.transform.parent.gameObject);
            //GameObject.Destroy(popUp.gameObject);
        }
        listCurrentPopUp.Clear();
        canvas.gameObject.SetActive(false);
    }
}
public class PopUp : SingletonMonoBehaviour<PopUpController>
{

}