
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
public class AllSceneName
{
    public const string Login = "Login";
    public const string LoadingScene = "Loading";
    public const string Menu = "Main";
    public const string TaiXiu = "TaiXiu";
    public const string GiftCode = "GiftCode";
}

public class SceneController  {
	public static string CurrentScene = AllSceneName.LoadingScene;
    public static string CurrentSubScene = AllSceneName.Login;
    public static string LastScene = "";
    private static List<string> ListCurrentSubScene = new List<string>();

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void OnBeforeSceneLoadRuntimeMethod()
	{
		// DataController.LoadData();
	}
		

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	static void OnAfterSceneLoadRuntimeMethod()
	{
		// if(Application.internetReachability == NetworkReachability.NotReachable)
		// {
		// 	ErrorController.Instance.DoError (ErrorIndex.ErrorNetwork,OnAfterSceneLoadRuntimeMethod);
		// 	return;
		// }
	}

    public static bool ContrainSubScene(string subSceneName)
    {
        return ListCurrentSubScene.Contains(subSceneName);
    }

	public static void OpenScene(string _SceneName)
	{
            SceneManager.LoadScene(_SceneName, LoadSceneMode.Single);
            PopUp.Instance.CloseAllPopUp();
            LastScene = CurrentScene;
            CurrentScene = _SceneName;
            ListCurrentSubScene.Clear ();
			

	}
	static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		
	}

	public static void OpenSubScene(string _SceneName)
	{
		if (!ListCurrentSubScene.Contains(_SceneName)) {
			ListCurrentSubScene.Add (_SceneName);
			SceneManager.LoadScene (_SceneName, LoadSceneMode.Additive);
		}
	}

    public static void Back()
    {
       OpenScene(LastScene);
    }

    public static void OpenSingleSubScene(string _SceneName)
    {
            PopUp.Instance.CloseAllPopUp();
            CurrentSubScene = _SceneName;
            while(ListCurrentSubScene.Count>0)
            {
                CloseSubScene(ListCurrentSubScene[0]);
            }
            ListCurrentSubScene.Add(_SceneName);
            SceneManager.LoadScene(_SceneName, LoadSceneMode.Additive);
    }

    public static void CloseAllSubScenes()
    {
        foreach (string sceneName in ListCurrentSubScene)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        ListCurrentSubScene.Clear();
    }

    public static void CloseSubScene(string _SceneName)
	{
		if (ListCurrentSubScene.Contains(_SceneName)) {
            
			SceneManager.UnloadSceneAsync(_SceneName);
            ListCurrentSubScene.RemoveAt(ListCurrentSubScene.IndexOf(_SceneName));
        }
	}

}
