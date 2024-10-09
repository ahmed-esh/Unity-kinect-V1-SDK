# Unity-kinect-V1-SDK
I took this Plugin in the Unity Asset store [MS Kinct SDK](https://api.unity.com/v1/oauth2/authorize?client_id=asset_store_v2&locale=en_US&redirect_uri=https%3A%2F%2Fassetstore.unity.com%2Fauth%2Fcallback%3Fredirect_to%3D%252Fpackages%252Ftools%252Fkinect-with-ms-sdk-7747%253Fsrsltid%253DAfmBOopA1aaeez98IPuPzgxZvRT6qKVBcIIulHjI4n2Xcqr0dIFwExm9&response_type=code&state=6cdc5f92-bb68-44d0-a2ef-3bd15385ee8f) and fixed to work on newer unity versions

There is a working Kinect V2 unity SDK that's made by Microsoft [here](https://learn.microsoft.com/en-us/windows/apps/design/devices/kinect-for-windows)
but to my knowledge, there isn't (I couldn't find) an SDK for the Kinect V1 for Unity that works for the newer versions of Unity (newer than Unity 5.0 V 2018.3 )

Thanks to the original maker Rumen F, for keeping clear documentation in the code, I was able to create this version. 
Read more about the original SDK here: [MS Kinect SDK](https://rfilkov.com/2013/12/16/kinect-with-ms-sdk/)


This README provides an overview of the key scripts and functionalities within the SDK.

## Getting Started

### Prerequisites

Before using this project, make sure you have the following:

- Kinect for Windows SDK v1.8
- Unity (version 2018.3 or higher)
- Kinect hardware (Kinect V1 sensor)
- The Orginal asset from unity store [MS Kinct SDK](https://api.unity.com/v1/oauth2/authorize?client_id=asset_store_v2&locale=en_US&redirect_uri=https%3A%2F%2Fassetstore.unity.com%2Fauth%2Fcallback%3Fredirect_to%3D%252Fpackages%252Ftools%252Fkinect-with-ms-sdk-7747%253Fsrsltid%253DAfmBOopA1aaeez98IPuPzgxZvRT6qKVBcIIulHjI4n2Xcqr0dIFwExm9&response_type=code&state=6cdc5f92-bb68-44d0-a2ef-3bd15385ee8f) not required but if you want to look at the example scenes 

### Installation

1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/ahmed-esh/Unity-kinect-V1-SDK.git
   ```
2. Open the project in Unity.
3. Set up your Kinect sensor according to the Kinect for Windows SDK v1.8 documentation.
4. Test the sample scene provided in the assets to ensure everything is working correctly. Make sure you swap the original scripts folder, with this repo's scripts folder.

## Features

- **Depth and Color Streams**: The SDK supports both depth and color data streams from the Kinect sensor.
- **Skeleton Tracking**: Captures user skeletons, allowing for full-body movement tracking.
- **Interaction Mechanism**: Provides basic interaction handling such as hand tracking and gesture recognition.
- **Compatibility Fixes**: Updates for Unity’s modern rendering pipelines and physics systems.

## Script Breakdown

Here’s an overview of the key scripts provided in this SDK and what they do:

### KinectManager.cs

This is the core script that manages Kinect’s interaction with Unity. It initializes the Kinect sensor, retrieves data from its streams (depth, color, skeleton), and handles Kinect-related events. It also controls the activation and deactivation of the sensor. This script is vital to ensuring all other Kinect functionality works smoothly.

Key functions include:
- **InitKinect()**: Initializes the Kinect sensor and sets up data streams.
- **UpdateKinectStreams()**: Captures data from the Kinect sensor every frame and processes it for Unity.
- **OnApplicationQuit()**: Safely shuts down the Kinect sensor when the application is closed.

### KinectBody.cs

This script is responsible for representing the Kinect-tracked body within Unity. It translates skeleton data into Unity’s coordinate system, allowing for visual representation of the player’s body movements.

Key components:
- **SkeletonToUnity()**: Converts Kinect skeleton joints to Unity’s 3D space.
- **ApplyBoneTransforms()**: Updates Unity’s humanoid rig based on the player's real-time movement.

### HandTracking.cs

This script tracks hand positions and gestures, allowing for interaction with the virtual environment. It can detect basic gestures such as hand raises, waves, or grips.

Key functions:
- **DetectHandGesture()**: Analyzes hand movement data to recognize specific gestures.
- **HandleInteraction()**: Allows interaction with game objects based on gesture recognition.

### DepthView.cs

This script processes the depth data from the Kinect and creates a depth map visualization in Unity. It converts raw depth data into grayscale textures that can be displayed on a UI or used for game logic.

Key features:
- **ProcessDepthData()**: Converts depth data into a texture format suitable for Unity.
- **RenderDepthMap()**: Displays the processed depth data in the game world.

### ColorView.cs

This script handles the color stream from the Kinect, applying the color data as textures to 3D models or UI components. It is especially useful for augmenting environments or overlaying real-world video feeds into the game world.

Key features:
- **ProcessColorData()**: Converts the raw Kinect color stream into a Unity-friendly format.
- **ApplyTexture()**: Maps the color data to appropriate objects in Unity.

### GestureController.cs

This script allows the developer to define custom gestures for controlling game actions. Using the skeleton and hand tracking data, it detects predefined movements and triggers in-game events.

Key functions:
- **RecognizeGesture()**: Identifies specific gesture patterns from skeleton data.
- **ExecuteAction()**: Triggers Unity actions based on recognized gestures.

## Example Scene

The SDK includes a sample Unity scene that demonstrates basic Kinect functionality. This scene shows how to initialize the Kinect sensor, display the color and depth streams, and track a user's skeleton for interaction.

## Troubleshooting

- **Sensor not detected**: Ensure that the Kinect sensor is properly connected and that the correct drivers are installed.
- **Laggy performance**: If the performance is slow, consider reducing the resolution of the color and depth streams in the KinectManager script.
- **Skeleton tracking issues**: Make sure the player is within the Kinect’s field of view and that there’s sufficient lighting in the room.

## Credits

- Original project by [Rumen Filkov](https://github.com/rfilkov).
