using UnityEngine;
using UnityEngine.Playables;

public enum PowerUpType
{
  Jump,
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

    switch (this.Type)
    {
      case PowerUpType.Jump:
        var limiter = collider.gameObject.GetComponent<MovementLimiter>();
        limiter.CanJump = true;
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