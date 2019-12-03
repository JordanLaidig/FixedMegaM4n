using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<Transform> targets;
    public float smoothTime = .5f;
    public Vector3 offset;
    public bool movable = true;
    private Vector3 velocity;
    float minZoom = 170f;
    float maxZoom = 160f;
    float Zoomlimiter = 50f;
    public Camera cam;
    
    
    //Parallax stuff
    public delegate void ParallaxEvent(float xfloat);
    public static event ParallaxEvent ParallaxUpdate;

    public delegate void StartParallax(float initX);
    public static event StartParallax ParallaxInitiate;
   
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        Vector3 tempCenterPoint = GetCenterPoint();
        if(ParallaxInitiate != null)
            ParallaxInitiate(tempCenterPoint.x);
       
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        if (movable)
        {
            Move();
            Zoom();
        }
       
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, getGreatestDistance() / Zoomlimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        if(ParallaxUpdate != null)                                                                     //Check if there are subscribers to ev ent
            ParallaxUpdate(centerPoint.x);//Call event and pass x value of new position 
        Vector3 newPosition = centerPoint + offset;
        
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
                                                                

    }

    float getGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        foreach (Transform t in targets)
        {
            bounds.Encapsulate(t.position);
        }

        return bounds.size.x;
    }

    public Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        foreach(Transform t in targets)
        {
            bounds.Encapsulate(t.position);
        }

        return bounds.center;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

}
