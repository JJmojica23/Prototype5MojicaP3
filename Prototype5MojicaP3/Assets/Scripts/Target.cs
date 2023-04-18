using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Declare a private Rigidbody named "targetRb"
    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    // Start is called before the first frame update
    void Start()
    {
        /* Get the component Rigidbody from whatever this script is assigned to.
        This also makes it so that anytime targetRb is referenced it gets the Rigidbody */
        targetRb = GetComponent<Rigidbody>();

        /* This adds force to whatever object is attached to by a random amount of force between
        12 and 16. The last part just makes it so it happens instantly. */
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        /* This makes the object rotate by a randomized amount of force between -10 and 10 in axis X, Y, and Z. 
        Last part makes the force to be applied instantly. */
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        /* This makes it so that the position of the object starts at a randomized X axis value between -4 and 4, 
        and also makes it so that it starts at the position of -2 in the Y axis. */
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
