using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Input Reader")]
public class InputReader : ScriptableObject, GameControls.IPlayActions
{
    public UnityAction PressEventA;
    public UnityAction PressEventD;
    public UnityAction PressEventS;
    public UnityAction PressEventW;

    private GameControls gameControls;

    private void OnEnable()
    {
        if (gameControls == null)
        {
            gameControls = new();
            gameControls.Play.SetCallbacks(this);
        }

        gameControls.Play.Enable();
    }

    private void OnDisable()
    {
        gameControls.Play.Disable();
    }

    public void OnA(InputAction.CallbackContext context)
    {
        if (PressEventA != null && context.performed)
        {
            Debug.Log("Pressed A!");
            PressEventA.Invoke();
        }
    }

    public void OnD(InputAction.CallbackContext context)
    {
        if (PressEventD != null && context.performed)
        {
            Debug.Log("Pressed D!");
            PressEventD.Invoke();
        }
    }

    public void OnS(InputAction.CallbackContext context)
    {
        if (PressEventS != null && context.performed)
        {
            Debug.Log("Pressed S!");
            PressEventS.Invoke();
        }
    }

    public void OnW(InputAction.CallbackContext context)
    {
        if (PressEventW != null && context.performed)
        {
            Debug.Log("Pressed W!");
            PressEventW.Invoke();
        }
    }
}
