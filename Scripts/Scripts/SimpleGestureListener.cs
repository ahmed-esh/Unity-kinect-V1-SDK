using UnityEngine;
using UnityEngine.UI;
using System;

public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
    // Text to display the gesture messages.
    public Text GestureInfo;

    // private bool to track if progress message has been displayed
    private bool progressDisplayed;

    public void UserDetected(uint userId, int userIndex)
    {
        // as an example - detect these user specific gestures
        KinectManager manager = KinectManager.Instance;

        manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
        manager.DetectGesture(userId, KinectGestures.Gestures.Squat);

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
        // Removed all text overlay usage
        progressDisplayed = true;
    }

    public bool GestureCompleted(uint userId, int userIndex, KinectGestures.Gestures gesture,
                                  KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
    {
        // Removed all text overlay usage
        progressDisplayed = false;
        return true;
    }

    public bool GestureCancelled(uint userId, int userIndex, KinectGestures.Gestures gesture,
                                  KinectWrapper.NuiSkeletonPositionIndex joint)
    {
        if (progressDisplayed)
        {
            progressDisplayed = false;
        }

        return true;
    }
}
