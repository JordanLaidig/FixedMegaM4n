using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraController : MonoBehaviour
{
    public List<Transform> targets;
    public float smoothTime = .5f;
    public Vector3 offset;
    public bool movable = true;
    private Vector3 velocity;
    
    //Parallax stuff
    public delegate void ParallaxEvent(float xfloat);
    public static event ParallaxEvent ParallaxUpdate;

    public delegate void StartParallax(float initX);
    public static event StartParallax ParallaxInitiate;
   
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tempCenterPoint = GetCenterPoint();
        if(ParallaxInitiate != null)
            ParallaxInitiate(tempCenterPoint.x);
       
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (targets.Count == 0) {
            Debug.Log("GameOver");
           return;
    }
        if(movable)
            Move();

       
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        if(ParallaxUpdate != null)                                                                     //Check if there are subscribers to ev ent
            ParallaxUpdate(centerPoint.x);//Call event and pass x value of new position 
        Vector3 newPosition = centerPoint + offset;
        
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
                                                                

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
