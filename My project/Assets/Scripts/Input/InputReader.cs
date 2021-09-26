using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, GameControl.IInGameActions
{
    // --------------EVENTS --------------
    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction PauseEvent = delegate { };

    // --------------INPUTS --------------

    private GameControl _gameControl;
    private InputActionMap _previouInputMap;
    private InputActionMap _currentInputMap;

    private void OnEnable()
    {
        if (_gameControl == null)
        {
            _gameControl = new GameControl();

            _gameControl.InGame.SetCallbacks(this);
        }

        DisableAllInput();
        SetCurrentMap(_gameControl.InGame);
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void SetCurrentMap(InputActionMap inputMap)
    {
        SetPreviousMap(_currentInputMap);
        _currentInputMap = inputMap;
        _currentInputMap.Enable();
    }

    private void SetPreviousMap(InputActionMap inputMap)
    {
        _previouInputMap = inputMap;
        _previouInputMap.Disable();
    }

    public void EnableLastInput() => SetCurrentMap(_previouInputMap);

    public void DisableAllInput()
    {
        _gameControl.InGame.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                PauseEvent.Invoke();
                break;
        }
    }
}
