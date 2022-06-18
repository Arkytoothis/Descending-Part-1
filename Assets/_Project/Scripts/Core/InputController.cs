using System;
using Descending.Encounters;
using Descending.Party;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Descending.Core
{
	public class InputController : MonoBehaviour
	{
		[Header("Character Input Values")]
		[SerializeField]private Vector2 _move;
		[SerializeField]private Vector2 _look;
		[SerializeField]private bool _jump;
		[SerializeField] private bool _sprint;

		[Header("Movement Settings")]
		[SerializeField] private bool _analogMovement;

		[Header("Mouse Cursor Settings")]
		[SerializeField] private bool _cursorLocked = true;
		[SerializeField] private bool _cursorInputForLook = true;

		[Header("Custom Settings")]
		[SerializeField] private LookModes _lookMode = LookModes.Look;
		[SerializeField] private WorldRaycaster _worldRaycaster = null;

		[SerializeField] private BoolEvent onToggleMenuWindow = null;
		[SerializeField] private BoolEvent onTogglePartyWindow = null;

		private bool _moveEnabled = true;
		private bool _lookEnabled = true;
		
		public Vector2 Move => _move;
		public Vector2 Look => _look;
		public bool Jump { get => _jump; set => _jump = value; }
		public bool Sprint => _sprint;
		public bool AnalogMovement => _analogMovement;
		public bool CursorLocked => _cursorLocked;
		public bool CursorInputForLook => _cursorInputForLook;
		public LookModes LookMode => _lookMode;
		public bool MoveEnabled => _moveEnabled;
		public bool LookEnabled => _lookEnabled;

		private void Start()
		{
			SetModeLook();
		}

		public void OnMove(InputAction.CallbackContext value)
		{
			MoveInput(value.ReadValue<Vector2>());
		}

		public void OnLook(InputAction.CallbackContext value)
		{
			if(_cursorInputForLook)
			{
				LookInput(value.ReadValue<Vector2>());
			}
		}

		public void OnJump(InputAction.CallbackContext value)
		{
			if (_lookMode == LookModes.Look && _moveEnabled == true && value.performed)
			{
				JumpInput(value.action.triggered);
			}
		}

		public void OnSprint(InputAction.CallbackContext value)
		{
			SprintInput(Math.Abs(value.action.ReadValue<float>() - 1) < 0.0001f);
		}

		public void OnLookMode(InputAction.CallbackContext value)
		{
			if (value.performed)
			{
				if (_lookMode == LookModes.Cursor)
				{
					SetModeLook();
				}
				else if (_lookMode == LookModes.Look)
				{
					SetModeCursor();
				}
			}
		}
		
		public void OnTogglePartyWindow(InputAction.CallbackContext value)
		{
			if (value.performed)
			{
				//Debug.Log("Toggling Party Window");
				onTogglePartyWindow.Invoke(true);
				if (_lookMode == LookModes.Cursor)
				{
				    SetModeLook();
				}
				else if (_lookMode == LookModes.Look)
				{
				    SetModeCursor();
				}
			}
		}

		public void OnTogglePauseWindow(InputAction.CallbackContext value)
		{
			if (value.performed)
			{
				//Debug.Log("Toggling Pause Window");
				onToggleMenuWindow.Invoke(true);
				if (_lookMode == LookModes.Cursor)
				{
				    SetModeLook();
				}
				else if (_lookMode == LookModes.Look)
				{
				    SetModeCursor();
				}
			}
		}

		private void SetModeCursor()
		{
			_lookMode = LookModes.Cursor;
			SetCursorState(false);
			Cursor.visible = true;
			_worldRaycaster.SetCrosshairActive(false);
		}

		private void SetModeLook()
		{
			_lookMode = LookModes.Look;
			SetCursorState(true);
			Cursor.visible = false;
			_worldRaycaster.SetCrosshairActive(true);
		}

		public void MoveInput(Vector2 newMoveDirection)
		{
			_move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			_look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			_jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			_sprint = newSprintState;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(_cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		public void OnSetLookMode(LookModes lookMode)
		{
			_lookMode = lookMode;
			if(_lookMode == LookModes.Cursor) SetModeCursor();
			else if(_lookMode == LookModes.Look) SetModeLook();
		}

		public void EnableMovement(bool moveEnabled)
		{
			_moveEnabled = moveEnabled;
		}

		public void EnableLook(bool lookEnabled)
		{
			_lookEnabled = lookEnabled;
		}

		public void OnCombatStarted(Encounter encounter)
		{
			SetModeCursor();
		}

		public void OnCombatEnded(bool b)
		{
			SetModeLook();
		}
	}
}