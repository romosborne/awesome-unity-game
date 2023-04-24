using UnityEngine;
using UnityEngine.Playables;

public enum PowerUpType
{
  Jump,
  WallJump,
  Finish
}

class PowerUp : MonoBehaviour
{
  [SerializeField]
  public PowerUpType Type;

  [SerializeField]
  public GameObject CutScene;

  void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.gameObject.name != "Player") return;

        var limiter = collider.gameObject.GetComponent<MovementLimiter>();

    switch (this.Type)
    {
      case PowerUpType.Jump:
        limiter.CanJump = true;
        if (CutScene != null)
        {
          limiter.CanMove = false;
          CutScene.GetComponent<PlayableDirector>().Play();
        }
        Destroy(this.gameObject);
        break;
      case PowerUpType.WallJump:
        limiter.CanWallJump = true;
        if (CutScene != null)
        {
          CutScene.GetComponent<PlayableDirector>().Play();
        }
        Destroy(this.gameObject);

        break;
      case PowerUpType.Finish:
        break;
      default:
        break;
    }
  }
}