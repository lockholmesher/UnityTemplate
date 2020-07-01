using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using System;
using SimpleJSON;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using LTAUnityBase.Base.BaseLoading;
[DisallowMultipleComponent]
public abstract class PhotonController : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks, IOnEventCallback
{
    public void SendMessage(byte evCode, object data)
    {
        Debug.Log("Send Data " + evCode);
        lbc.OpRaiseEvent(evCode, data, null, new SendOptions() { Encrypt = true, Reliability = true });
    }

    public LoadBalancingClient lbc;
    private ConnectionHandler ch;

    bool isForceDisconnect = false;

    bool isConnected = false;
    protected virtual void Awake()
    {
        this.lbc = new LoadBalancingClient();
        this.lbc.AddCallbackTarget(this);
        this.lbc.LoadBalancingPeer.TransportProtocol = ExitGames.Client.Photon.ConnectionProtocol.Tcp;
        this.ch = this.gameObject.GetComponent<ConnectionHandler>();
        this.lbc.StateChanged += ChangeState;
    }

    void ChangeState(ClientState clientState, ClientState state)
    {
        if (state == ClientState.Disconnecting)
        {
            if (clientState == ClientState.ConnectingToMasterServer)
            {
                ErrorController.Instance.DoError(ErrorIndex.ErrorNetwork);
                return;
            }
            if (clientState == ClientState.Authenticating)
            {
                ErrorController.Instance.DoError(ErrorIndex.ErrorAuthentication);
                return;
            }
            if (!isConnected) return;
            isConnected = false;
            if (isForceDisconnect)
            {
                isForceDisconnect = false;
                return;
            }
            
            ErrorController.Instance.DoError(ErrorIndex.ErrorNetwork,() =>
            {
                if (SceneController.CurrentScene == AllSceneName.Login) return;
                Loading.Instance.ShowLoadingProcess(1f, () =>
                {
                    SceneController.OpenScene(AllSceneName.Login);
                });
            });
            
        }
    }

    public void Update()
    {
        LoadBalancingClient client = this.lbc;
        if (client != null)
        {
            client.Service();
        }
        
    }

    public void Disconnect()
    {
        isForceDisconnect = true;
        SceneController.OpenScene(AllSceneName.Login);
        lbc.State = ClientState.Disconnecting;
        lbc.Disconnect();
    }

    protected void ConnectServer(AuthenticationValues authValues)
    {
        Loading.Instance.ShowLoadingProcess(0.25f,()=>
        {
            SceneController.OpenScene(AllSceneName.Menu);
        });
        lbc.AuthValues = authValues;
        lbc.IsUsingNameServer = false;
        lbc.MasterServerAddress = PhotonConfig.ServerIP + ":" + PhotonConfig.Port;

        lbc.Connect();
        if (this.ch != null)
        {
            this.ch.Client = this.lbc;
            this.ch.StartFallbackSendAckThread();
        }
    }

    public void OnConnectedToMaster()
    {
        Loading.Instance.ShowLoadingProcess(0.75f);
        EnterRoomParams enterRoomParams = new EnterRoomParams();
        enterRoomParams.RoomName = "GameBai";
        this.lbc.OpJoinOrCreateRoom(enterRoomParams);
    }

    public void OnConnected()
    {
        Loading.Instance.ShowLoadingProcess(0.5f);
    }

    public void OnDisconnected(DisconnectCause cause)
    {
       
    }

    public void OnRegionListReceived(RegionHandler regionHandler)
    {
        throw new NotImplementedException();
    }

    public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
        //Debug.Log("OnCustomAuthenticationResponse");
    }

    public void OnCustomAuthenticationFailed(string debugMessage)
    {
        ErrorController.Instance.DoError(ErrorIndex.ErrorLoginFail, debugMessage);
    }

    public void OnCreatedRoom()
    {
        Loading.Instance.ShowLoadingProcess(0.9f);
    }

    public void OnCreateRoomFailed(short returnCode, string message)
    {
        ErrorController.Instance.DoError(ErrorIndex.ErrorLoginFail, message);
    }

    public void OnJoinedRoom()
    {
        isConnected = true;
        Loading.Instance.ShowLoadingProcess(1f);
    }

    public void OnJoinRoomFailed(short returnCode, string message)
    {
        ErrorController.Instance.DoError(ErrorIndex.ErrorLoginFail, message);
    }

    public void OnJoinRandomFailed(short returnCode, string message)
    {

    }

    public void OnLeftRoom()
    {
        Loading.Instance.ExitLoading();
    }

    public abstract void OnEvent(EventData photonEvent);

    public void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        throw new NotImplementedException();
    }
    
}
