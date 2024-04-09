using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool submit;
		public bool shoot;
		public bool hide;
		public bool pickUp;
		public bool drop;
		public bool up;
		public bool down;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if (cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnSubmit(InputValue value)
		{
			SubmitInput(value.isPressed);
		}

		public void OnShoot(InputValue value)
		{
			ShootInput(value.isPressed);
		}

		public void OnHide(InputValue value)
		{
			HideInput(value.isPressed);
		}

		public void OnPickUp(InputValue value)
		{
			pUpInput(value.isPressed);
		}

		public void OnDrop(InputValue value)
		{
			DropInput(value.isPressed);
		}

		public void OnUp(InputValue value)
		{
			UpInput(value.isPressed);
		}

		public void OnDown(InputValue value)
		{
			DownInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void SubmitInput(bool newSubmitState)
		{
			submit = newSubmitState;
		}

		public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}

		public void HideInput(bool newHideState)
		{
			hide = newHideState;
		}

		public void pUpInput(bool newPickUpState)
		{
			pickUp = newPickUpState;
		}

		public void DropInput(bool newdDownState)
		{
			drop = newdDownState;
		}

		public void UpInput(bool newPickUpState)
		{
			up = newPickUpState;
		}

		public void DownInput(bool newDownState)
		{
			down = newDownState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}

}