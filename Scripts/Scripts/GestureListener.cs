using UnityEngine;
using UnityEngine.UI;
using System;

public class GestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
    // Text to display the gesture messages.
    public Text GestureInfo;

    private bool swipeLeft;
    private bool swipeRight;

    public bool IsSwipeLeft()
    {
        if (swipeLeft)
        {
            swipeLeft = false;
            return true;
        }

        return false;
    }

    public bool IsSwipeRight()
    {
        if (swipeRight)
        {
            swipeRight = false;
            return true;
        }

        return false;
    }

    public void UserDetected(uint userId, int userIndex)
    {
        KinectManager manager = KinectManager.Instance;

        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);

        if (GestureInfo != null)
        {
            GestureInfo.text = "";
        }
    }

    public void UserLost(uint userId, int userIndex)
    {
        if (GestureInfo != null)
        {
            GestureInfo.text = string.Empty;
        }
    }

    public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture,
                                  float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
    {
        // No overlay text here, nothing to modify
    }

    public bool GestureCompleted(uint userId, int userIndex, KinectGestures.Gestures gesture,
                                  KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
    {
        swipeLeft = gesture == KinectGestures.Gestures.SwipeLeft;
        swipeRight = gesture == KinectGestures.Gestures.SwipeRight;
        return true;
    }

    public bool GestureCancelled(uint userId, int userIndex, KinectGestures.Gestures gesture,
                                  KinectWrapper.NuiSkeletonPositionIndex joint)
    {
        return true;
    }
}
