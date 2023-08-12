// BasicMovement.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class BasicMovement : MonoBehaviour
{
  public float speed;

  Rigidbody2D rb;
  PhotonView photonView;

  [SerializeField] private GameObject cmvCam;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    photonView = GetComponent<PhotonView>();

    cmvCam = FindObjectOfType<CinemachineVirtualCamera>().gameObject;
    cmvCam.GetComponent<CinemachineVirtualCamera>().Follow = this.gameObject.transform;
    cmvCam.GetComponent<CinemachineVirtualCamera>().LookAt = this.gameObject.transform;

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (photonView.IsMine)
    {
      Move();
    }
  }

  void Move()
  {
    float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

    Vector2 newVector = new Vector2(horizontal, vertical);
    rb.position += newVector;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("Collission!");
      rb.velocity = Vector2.zero;
      rb.position = this.gameObject.transform.position;
  }
}