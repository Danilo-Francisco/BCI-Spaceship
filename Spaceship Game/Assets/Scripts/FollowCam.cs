using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDampening = 10f;
    //[SerializeField] float rotationalDampening = 2.5f;

    Transform myTransform;

    public Vector3 velocity = Vector3.one;
    void Awake()
    {
        myTransform = transform;
    }

    void LateUpdate()
    {
        if(!FindTarget())
            return;

        SmoothFollow();
        /*Vector3 toPosition = target.position + (target.rotation * defaultDistance);
        Vector3 currentPosition = Vector3.Lerp(myTransform.position, toPosition, distanceDampening * Time.deltaTime);
        myTransform.position = currentPosition;

        Quaternion toRotation = Quaternion.LookRotation(target.position - myTransform.position, target.up);
        Quaternion currentRotation = Quaternion.Slerp(myTransform.rotation, toRotation, rotationalDampening * Time.deltaTime);
        myTransform.rotation = currentRotation;*/
    }

    void SmoothFollow()
    {
        Vector3 toPosition = target.position + (target.rotation * defaultDistance);
        Vector3 currentPosition = Vector3.SmoothDamp(myTransform.position, toPosition, ref velocity, distanceDampening );
        myTransform.position = currentPosition;

        myTransform.LookAt(target, target.up);
    }

    bool FindTarget()
    {
        if(target == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");

            if (temp != null)
                target = temp.transform;
        }

        if (target == null)
            return false;

        return true;
    }
}
