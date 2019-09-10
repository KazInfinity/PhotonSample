using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonSample : MonoBehaviour, IConnectionCallbacks, ILobbyCallbacks, IMatchmakingCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    #region IConnectionCallbacks
    void IConnectionCallbacks.OnConnected(){}
    // 接続完了通知
    void IConnectionCallbacks.OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(Photon.Realtime.TypedLobby.Default);
    }
    void IConnectionCallbacks.OnCustomAuthenticationFailed(string debugMessage){}
    void IConnectionCallbacks.OnCustomAuthenticationResponse(Dictionary<string, object> data){}
    void IConnectionCallbacks.OnDisconnected(DisconnectCause cause)
    {
    }
    void IConnectionCallbacks.OnRegionListReceived(RegionHandler regionHandler){}
    #endregion

    #region ILobbyCallbacks
    // ロビー入室完了通知
    void ILobbyCallbacks.OnJoinedLobby()
    {
        PhotonNetwork.CreateRoom("松の間");
    }

    void ILobbyCallbacks.OnLeftLobby()
    {
        Debug.Log("ロビー退室");
    }

    void ILobbyCallbacks.OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics){}
    void ILobbyCallbacks.OnRoomListUpdate(List<RoomInfo> roomList){}

    void IMatchmakingCallbacks.OnCreatedRoom(){}
    void IMatchmakingCallbacks.OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("部屋作成失敗");
    }

    void IMatchmakingCallbacks.OnFriendListUpdate(List<FriendInfo> friendList){}

    void IMatchmakingCallbacks.OnJoinedRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message){}
    void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("部屋入室失敗");
    }

    void IMatchmakingCallbacks.OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
    }
    #endregion
}
