using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public enum PlayerType
    {
        WASD,
        Arrow
    }

    public static Action<string, string, PlayerType> OnMoveInput;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            OnMoveInput?.Invoke("HorizontalWSAD", "VerticalWSAD", PlayerType.WASD);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            OnMoveInput?.Invoke("HorizontalArrow", "VerticalArrow", PlayerType.Arrow);
    }
}