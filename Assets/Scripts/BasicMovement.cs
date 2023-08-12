// BasicMovement.cs
using UnityEngine;
using Photon.Pun;

public class BasicMovement : MonoBehaviour
{
  public float speed;

  Rigidbody2D rb;
  PhotonView photonView;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
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

    Vector2 newVector = new Vector2(horizontal, vertical);
    rb.position += newVector;
  }
}