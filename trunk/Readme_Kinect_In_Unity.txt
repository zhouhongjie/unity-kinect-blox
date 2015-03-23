- We will using the Kinect Point Man from the Proof of concept.

How to import:
1.) Download Unity Kinect Wrapper under: http://wiki.etc.cmu.edu/unity3d/index.php/Microsoft_Kinect_-_Microsoft_SDK#Integrating_with_Unity
2.) As recommended also download the driver from 1.8 and the kinect sdk 1.8
3.) Import UnityPackage of wrapper in unity
4.) to use emulator: Select: KinectPrefab and check CheckBox

- I have added the Mask two Hands (which consists of both wrist and hand, i did this for swipe recognation).
- I have made the wrists invisible on play (but we'll need them for swipe recognation)
- at the moment both hands are configured as trigger (to force a event when the hit a block)
- I also created a playback file for the emulator to use, so that we didn't the kinect all the time (just select emulator as
	described above)
