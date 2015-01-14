/************************************************************************
	ALPSGyro is an interface for head tracking using Android native sensors

    Copyright (C) 2014  ALPS VR.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

************************************************************************/

using UnityEngine;
using System;
using System.Runtime.InteropServices;


public class ALPSGyro : MonoBehaviour
{
    private bool gyroBool;
    private Gyroscope gyro;
    private Quaternion rotFix;
    private Vector3 initial = new Vector3(90, 180, 0);
        
    // Use this for initialization
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
 
        gyroBool = SystemInfo.supportsGyroscope;
 
        Debug.Log("gyro bool = " + gyroBool.ToString());
 
        if (gyroBool)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
 
            rotFix = new Quaternion(0, 0, 0.7071f, 0.7071f);
        }
        else
        {
            Debug.Log("No Gyro Support");
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        if (gyroBool)
        {
            var camRot = gyro.attitude * rotFix;
            transform.eulerAngles = initial;
            transform.localRotation *= camRot;
        }
    }
}


//public class ALPSGyro : MonoBehaviour 
//{
//	//=====================================================================================================
//	// Attributes
//	//=====================================================================================================

//	/**Private**/
//	private Quaternion landscapeLeft = Quaternion.Euler(90, 0, 0);
//    private Quaternion quatMult = new Quaternion(0, 0, 1, 0);

//    private Quaternion orientation = Quaternion.identity;
//	private float q0,q1,q2,q3;

//    private Gyroscope _gyro;
//    private Quaternion rotFix;

//    //=====================================================================================================
//    // Functions
//    //=====================================================================================================
//    [DllImport ("alps_native_sensor")] private static extern void get_q(ref float q0,ref float q1,ref float q2,ref float q3);
//	[DllImport ("alps_native_sensor")] private static extern void init();

//	/// <summary>
//	/// Initializes ALPS native plugin.
//	/// </summary>
//	public void Start()
//    {
//        var gyroBool = SystemInfo.supportsGyroscope;

//        if (gyroBool)
//        {
//            var prevScreenOrientation = Screen.orientation;
//            _gyro = Input.gyro;
//            _gyro.enabled = true;

//            var originalParent = transform.parent; // check if this transform has a parent
//            var camParent = new GameObject("camParent"); // make a new parent
//            camParent.transform.position = transform.position; // move the new parent to this transform position
//            transform.parent = camParent.transform; // make this transform a child of the new parent
//            camParent.transform.parent = originalParent; // make the new parent a child of the original parent

//            camParent.transform.eulerAngles = new Vector3(90, 180, 0);
//            rotFix = new Quaternion(0, 0, 0.7071f, 0.7071f);
             
//            //if (setZeroToNorth)
//            //{
//            //    compass = Input.compass;
//            //    compass.enabled = true;
//            //}

//            //fixScreenOrientation();

//        }

//#if UNITY_ANDROID
//			init();
//#endif
//    }

//    /// <summary>
//    /// Updates head orientation after all Update functions have been called.
//    /// </summary>
//    public void LateUpdate () {
//#if UNITY_ANDROID
//		getOrientation();
//		transform.localRotation = landscapeLeft * orientation;
//#elif UNITY_WP8 || UNITY_WINRT
//        var camRot = _gyro.attitude * rotFix;
//        transform.localRotation = camRot;
//#endif
//    }

//    private Quaternion GetRotFix()
//    {
//        if (Screen.orientation == ScreenOrientation.Portrait)
//            return Quaternion.identity;
//        if (Screen.orientation == ScreenOrientation.LandscapeLeft
//        || Screen.orientation == ScreenOrientation.Landscape)
//            return Quaternion.Euler(0, 0, -90);
//        if (Screen.orientation == ScreenOrientation.LandscapeRight)
//            return Quaternion.Euler(0, 0, 90);
//        if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
//            return Quaternion.Euler(0, 0, 180);
//        return Quaternion.identity;
//    }
//    /// <summary>
//    /// Gets orientation from ALPS native plugin.
//    /// </summary>
//    public void getOrientation(){
//		get_q (ref q0,ref q1,ref q2,ref q3);
//		orientation.x = q1;
//		orientation.y = -q0;
//		orientation.z = q2;
//		orientation.w = q3;
//	}
	
//}
