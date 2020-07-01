using UnityEngine;
using System;
using LTAUnityBase.Base.DesignPattern;
using LTAUnityBase.Base.BaseLoading;
public enum ErrorIndex
{
    ErrorLoginFail,
    ErrorAuthentication,
    ErrorNetwork,
    ErrorCantBeBlank,
    ErrorInvalidEmail,
    PasswordsNotMatch

}

public class ErrorController : Singleton<ErrorController> {

	public void DoError(ErrorIndex errorIndex,Action callbackClosePopUpError)
	{
		DoError (errorIndex, "", callbackClosePopUpError);
	}

	public void DoError(ErrorIndex errorIndex,string Message = "",Action callbackClosePopUpError = null)
	{
        Debug.LogError(errorIndex);
        Loading.Instance.ExitLoading();
        PopUpText _PopUpError = PopUp.Instance.ShowPopUp<PopUpText>(PopUpName.PopUpText);
        if (Message != "" && Message != null)
        {
            _PopUpError.SetMes(Message,()=>
            {
                if (callbackClosePopUpError != null)
                    callbackClosePopUpError();
            });
            return;
        }
        switch (errorIndex) {
		case ErrorIndex.ErrorLoginFail:
				Message = "Have error while login , please check again your username and password";
			    break;
		case ErrorIndex.ErrorNetwork:
                Message = "Error. Check internet connection!";
                break;
        case ErrorIndex.ErrorAuthentication:
                Message = "An authentication error has occurred";
			break;
        case ErrorIndex.ErrorCantBeBlank:
                Message = "Error.Can't Be Blank!";
                break;
        case ErrorIndex.ErrorInvalidEmail:
                Message = "Error.Invalid email!";
                break;
        case ErrorIndex.PasswordsNotMatch:
                Message = "Error.Password do not match!";
                break;
                
        }
        Debug.LogError(Message);
        _PopUpError.SetMes(Message, () =>
        {
            if (callbackClosePopUpError != null)
                callbackClosePopUpError();
        });

    }


    

}
