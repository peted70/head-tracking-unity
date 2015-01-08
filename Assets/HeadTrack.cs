using UnityEngine;
using System.Collections;

public class HeadTrack : MonoBehaviour
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
