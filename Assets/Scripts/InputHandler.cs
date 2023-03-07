using UnityEngine;
using UnityEngine.InputSystem;
    public class InputHandler : MonoBehaviour
    {
        public Vector2 move,look;
        public bool jump,sprint,pickUp,mining,eqSlot1, eqSlot2, eqSlot3;
        public float zoom;
        private bool cursorLocked = true;
        private bool cursorInputForLook = true;
        public Float eqSlot;
        public PlayerController eqTool;
        public float eq;
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}
		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
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
        public void OnZoom(InputValue value)
        {
            zoom = value.Get<float>();
        }
        public void OnPickUp(InputValue value)
        {
            PickUpInput(value.isPressed);
        }
    	public void OnMining(InputValue value)
		{
            MiningInput(value.isPressed);
		}
        public void OnEqSlot1(InputValue value)
        {
            EqSlot1(value.isPressed);
        }
    public void OnEqSlot2(InputValue value)
    {
        EqSlot2(value.isPressed);
    }
    public void OnEqSlot3(InputValue value)
    {
        EqSlot3(value.isPressed);
    }
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
         public void MiningInput(bool newSprintState)
         {
            mining = newSprintState;
         }
        public void ZoomInput(float newZoomValue)
        {
            zoom = newZoomValue;
        }
        public void PickUpInput(bool newPickUpState)
        {
            pickUp = newPickUpState;
        }
        public void EqSlot1(bool newEqSlot)
        {
        eqSlot1=newEqSlot;
        }
    public void EqSlot2(bool newEqSlot)
    {
        eqSlot2 = newEqSlot;
    }
    public void EqSlot3(bool newEqSlot)
    {
        eqSlot3 = newEqSlot;
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