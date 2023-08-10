// NetworkConnector.cs
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkConnector : MonoBehaviourPunCallbacks
{
  public GameObject playerPrefab;

  void Start()
  {
    PhotonNetwork.ConnectUsingSettings();
  }

  #region Pun Callbacks

  public override void OnConnectedToMaster()
  {
    // Try to join a random room
    PhotonNetwork.JoinRandomRoom();
  }

  public override void OnDisconnected(DisconnectCause cause)
  {
    Debug.LogWarning($"Failed to connect: {cause}");
  }

  public override void OnJoinRandomFailed(short returnCode, string message)
  {
    // Failed to connect to random
    Debug.Log(message);

    // Create room
    PhotonNetwork.CreateRoom("My First Room");
  }

  public override void OnJoinedRoom()
  {
    Debug.Log($"{PhotonNetwork.CurrentRoom.Name} joined!");
    PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 3.0f, 0), Quaternion.identity);
  }

  #endregion
}