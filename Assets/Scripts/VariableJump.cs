using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum JumpState
{
  Grounded,
  DesiredJump,
  JumpingUp,
  Falling
}

public class VariableJump : MonoBehaviour
{
  public Rigidbody2D rb;
  public CharacterGround ground;
  public float buttonTime = 0.5f;
  public float jumpHeight = 5;
  public float cancelRate = 100;
  float jumpTime;

  public JumpState state = JumpState.Grounded;

  bool pressingJump = true;

  public void OnJump(InputAction.CallbackContext ctx)
  {
    if (ctx.started)
    {
      state = JumpState.DesiredJump;
      pressingJump = true;
    }

    if (ctx.canceled)
    {
      state = JumpState.Falling;
      pressingJump = false;
    }
  }

  private void Update()
  {
    var grounded = ground.GetOnGround();

    if (state == JumpState.DesiredJump && grounded)
    {
      float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
      rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
      state = JumpState.JumpingUp;
      jumpTime = 0;
    }
    else if (state == JumpState.Falling && grounded)
    {
      state = JumpState.Grounded;
    }
    else if (state == JumpState.JumpingUp)
    {
      jumpTime += Time.deltaTime;
      if (!pressingJump || jumpTime > buttonTime)
      {
        state = JumpState.Falling;
      }
    }
  }

  private void FixedUpdate()
  {
    if (state == JumpState.Falling)
    {
      rb.AddForce(Vector2.down * cancelRate);
    }
  }
}