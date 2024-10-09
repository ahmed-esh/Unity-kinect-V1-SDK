using UnityEngine;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;

public class MouseControl
{
    [DllImport("User32.dll")]
    private static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, System.UIntPtr dwExtraInfo);

    [Flags]
    private enum MouseFlags
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        Absolute = 0x8000,
    }

    // Method that accepts a single Vector3 argument
    public static void MouseMove(Vector3 screenCoordinates)
    {
        int mouseX = (int)(screenCoordinates.x * 65535);
        int mouseY = (int)((1f - screenCoordinates.y) * 65535);
        mouse_event(MouseFlags.Absolute | MouseFlags.Move, mouseX, mouseY, 0, System.UIntPtr.Zero);
    }

    // Overloaded method that accepts two arguments
    public static void MouseMove(Vector3 screenCoordinates, Text debugText)
    {
        // The method signature stays the same, but we'll ignore the second argument (debugText)
        MouseMove(screenCoordinates);
    }

    public static void MouseClick()
    {
        mouse_event(MouseFlags.LeftDown, 0, 0, 0, System.UIntPtr.Zero);
        mouse_event(MouseFlags.LeftUp, 0, 0, 0, System.UIntPtr.Zero);
    }

    public static void MouseDrag()
    {
        mouse_event(MouseFlags.LeftDown, 0, 0, 0, System.UIntPtr.Zero);
    }

    public static void MouseRelease()
    {
        mouse_event(MouseFlags.LeftUp, 0, 0, 0, System.UIntPtr.Zero);
    }
}
