using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserOffTime = 0.5f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float fireDelay = 2f;

    LineRenderer lineRenderer;
    Light laserLight;
    bool canFire;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>(); 
    }

    void Start()
    {
        lineRenderer.enabled = false;
        laserLight.enabled = false;
        canFire = true;
    }

   /* void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.yellow); 
    }*/

    Vector3 CastRay()
    {
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward) * maxDistance;

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            Debug.Log("We Hit: " + hit.transform.name);

            SpawnExplosion(hit.point, hit.transform);

            if (hit.transform.CompareTag("PickUp"))
                hit.transform.GetComponent<PickUp>().PickUpHit();

            return hit.point;
        }
            Debug.Log("We missed...");
        return transform.position + (transform.forward * maxDistance);
    }

    void SpawnExplosion(Vector3 hitPosition, Transform target)
    {
        Explosion temp = target.transform.GetComponent<Explosion>();
        if (temp != null)
            temp.AddForce(hitPosition, transform);
    }
    public void FireLaser()
    {
        Vector3 pos = CastRay();
        FireLaser(pos);
    }

    public void FireLaser(Vector3 targetPosition, Transform target = null)
    {
        if (canFire)
        {
            if(target != null)
            {
                SpawnExplosion(targetPosition, target); //this will be called when the enemy can shoot us 

            }
            
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, targetPosition);
            lineRenderer.enabled = true;
            laserLight.enabled = true;
            canFire = false;
            Invoke("TurnOffLaser", laserOffTime);
            Invoke("CanFire", fireDelay);
        }
    }

    void TurnOffLaser()
    {
        lineRenderer.enabled = false;
        laserLight.enabled = false;
        //canFire = true;
    }

    public float Distance
    {
        get { return maxDistance;}
    }

    void CanFire()
    {
        canFire = true;
    }
}