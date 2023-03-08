using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Explosion))]
public class Asteroid : MonoBehaviour
{
    [SerializeField] float minScale = 0.8f;
    [SerializeField] float maxScale = 1.2f;
    [SerializeField] float rotationOffset = 100f;

    public static float destructionDelay = 1.0f;

    Transform myTransform;
    Vector3 randomRotation;
    // Start is called before the first frame update
    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        //Random Size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);

        myTransform.localScale = scale;
        //Random Rotation
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);

    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Rotate(randomRotation * Time.deltaTime); //"Time.deltaTime" allows to smothen the rotation across different frame rates
    }

    public void SelfDestruct()
    {
        float timer = Random.Range(0,destructionDelay);

        Invoke("GoBoom", timer);
    }

    public void GoBoom()
    {
        GetComponent<Explosion>().BlowUp();
    }

   
}
