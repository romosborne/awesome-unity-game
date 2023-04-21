using UnityEngine;
public class MovementLimiter : MonoBehaviour
{
  [SerializeField]
  public bool CanMove = true;

  [SerializeField]
  public bool CanJump = true;

  public void AllowMovement()
  {
    CanMove = true;
  }
}