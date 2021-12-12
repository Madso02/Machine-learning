using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [Header("Handling")]
    [SerializeField] float acceleration;
    [SerializeField] float topSpeed;
    [SerializeField] float turnSpeed;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controlCar(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
    }

    void controlCar(float throttle, float steering)
    {
        throttle = throttle > 0 ? throttle : 2 * throttle;
        speed = Mathf.Clamp(speed += acceleration * throttle, -topSpeed, topSpeed);
        var rotation = -steering * turnSpeed;
        transform.Translate(Vector3.up * speed);
        transform.Rotate(Vector3.forward * rotation);
    }
}
