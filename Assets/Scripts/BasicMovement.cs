// BasicMovement.cs
using UnityEngine;
using Photon.Pun;

public class BasicMovement : MonoBehaviour
{
  public float speed;

  Rigidbody rb;
  PhotonView photonView;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    photonView = GetComponent<PhotonView>();
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

    Vector3 newVector = new Vector3(horizontal, 0, vertical);

    rb.position += newVector;
  }
}