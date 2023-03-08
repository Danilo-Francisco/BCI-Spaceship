using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    [SerializeField] GameObject blowUp;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Shield shield;
    [SerializeField] float laserHitModifier = 50f;

    //When this method is called, it intatiates some particles onto the game object
    void IveBeenHit(Vector3 position)
    {
        GameObject gO = Instantiate(explosion, position, Quaternion.identity, transform) as GameObject;
        Destroy(gO, 6f);

        if (shield == null)
            return;

        shield.TakeDamage();
    }

    //when colision occors, this functions iterates through the contact poits of the colision and invokes "IveBeenHit" method
    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
            IveBeenHit(contact.point);
    }

    //when game object is hit, it adds a force into it
    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        Debug.LogWarning("AddForce: " + gameObject.name + " -> " + hitSource.name);

        if (rigidBody == null)
            return;

        Vector3 forceVector = (hitSource.position - hitPosition).normalized;
        Debug.Log(forceVector * laserHitModifier);
        IveBeenHit(hitPosition);
        rigidBody.AddForceAtPosition(forceVector * laserHitModifier, hitPosition, ForceMode.Impulse);
    }

    public void BlowUp()
    {
        //summon particle effect
        GameObject temp = Instantiate(blowUp, transform.position, Quaternion.identity) as GameObject;

        //Destroy Particle System
        Destroy(temp, 4f);

        //destroy it self
        Destroy(gameObject);
    }

}
