using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    //Read Me
    //To use the parallax script, change the Z coordinate of the object to -Z where Z is the percent slower speed you want the object to move at
    //Ex. If an object is at -0.5 it will move at half the speed of the camera

    //private float lastCentPosX = -1000;
    private float centerInitX;
    private bool started = false;
    private float lastCentPosX = -1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void OnEnable()
    {
        //Add the UpdateParallax method to the list of functions listening to for the ParallaxUpdate event within Camera Controller
        //Called automatically
        CameraController.ParallaxUpdate += UpdateParallax;
        CameraController.ParallaxUpdate += InitializeParallax;
    }

    void OnDisable()
    {
        //Remove the UpdateParallax method to the list of functions listening to for the ParallaxUpdate event within Camera Controller
        CameraController.ParallaxUpdate -= UpdateParallax;
        CameraController.ParallaxUpdate -= InitializeParallax;
    }

    void InitializeParallax(float initX)
    {
        //Debug.Log("Init");
        if(!started){
            centerInitX = initX;
            started = true;
        }
    }

    void UpdateParallax(float newCentPosX)
    {
        //Debug message to remind you to change z coord
        if(transform.position.z == 0)
            Debug.Log("Error: You haven't changed the z coord of this object. Remedy or read ParallaxScript.cs");
        
        //Center Point relative
        Vector3 tempVector = transform.position;  
        if(lastCentPosX != -1000)
            tempVector.x -= (newCentPosX - lastCentPosX)*(transform.position.z);
        transform.position = tempVector;//Change x position of object based on z position of object
        lastCentPosX = newCentPosX;
        //Center Point Absolute
         /*Vector3 tempVector = transform.position;  //Absolute attempt
        tempVector.x = (centerInitX - newCentPosX)*(transform.position.z);
        transform.position = tempVector;//Change x position of object based on z position of object
        
        //Zero center
        /*Vector3 tempVector = transform.position;
        tempVector.x = newCentPosX*(-transform.position.z);
        transform.position = tempVector;//Change x position of object based on z position of object
*/
       // Debug.Log(transform.position);

        //lastCentPosX = newCentPosX;
    }
}