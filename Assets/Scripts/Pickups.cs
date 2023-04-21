using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.layer != 8) return;

    var type = collision.gameObject.GetComponent<PowerUp>().Type;

    if (type == PowerUpType.Jump)
    {
      Debug.Log("Jump");
    }

  }
}
