using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float xSensitivity = 15;
    public float ySensitivity = 15;
    public float minimumX = -360;
    public float maximumX = 360;
    public float minimumY = -90;
    public float maximumY = 90;
    float rotationX = 0;
    float rotationY = 0;

    private List<float> rotArrayX = new List<float>();  //holds a certain number of target rotation points
    private List<float> rotArrayY = new List<float>();
    float rotAverageX;
    float rotAverageY;

    public float frameCounter = 20;

    Quaternion originalRotation; //stores the original rotation of the camera before updating rotation
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
        originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        GetCameraInput();
    }

    void GetCameraInput()
    {
        rotationX += Input.GetAxis("Mouse X") * xSensitivity;
        rotationY += Input.GetAxis("Mouse Y") * ySensitivity;

        rotArrayX.Add(rotationX);
        rotArrayY.Add(rotationY);

        if (rotArrayY.Count >= frameCounter)
        {
            rotArrayY.RemoveAt(0); //removes oldest frame
        }
        if (rotArrayX.Count >= frameCounter)
        {
            rotArrayX.RemoveAt(0);
        }

        for (int i = 0; i < rotArrayY.Count; i++)
        {
            rotAverageY += rotArrayY[i];
        }
        for (int j = 0; j < rotArrayX.Count; j++)
        {
            rotAverageX += rotArrayX[j];
        }

        //takes the average of the last 'n' frames worth of X/Y values
        rotAverageY /= rotArrayY.Count;
        rotAverageX /= rotArrayX.Count;

        //keeps the camera from going out of bounds
        rotAverageY = ClampAngle(rotAverageY, minimumY, maximumY);
        //rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);

        //Angle Axis: "Creates a rotation which rotates angle degrees around axis."
        Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.up);

        GetComponent<Camera>().transform.localRotation = originalRotation * xQuaternion * yQuaternion;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360.0f; //makes sure angle never goes beyond 360; 'n' % 'm' results in the remainder of n/m; ex:10%6 = 4
        if ((angle >= -360.0f) && (angle <= 360.0f))
        {
            if (angle < -360.0f)
            {
                Debug.Log("WHY");
                angle += 360.0f;
            }
            if (angle > 360.0f)
            {
                Debug.Log("WHY");
                angle -= 360.0f;
            }
        }

        return Mathf.Clamp(angle, min, max);
    }
}
