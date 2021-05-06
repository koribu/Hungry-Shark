using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float _Mass = 15;
    public float _MaxVelocity = 3;
    public float _MaxForce = 15;

    private Vector3 velocity;
    private Vector3 m_destination;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Plane plane = new Plane(Vector3.forward, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && plane.Raycast(ray, out distance))
        {
            m_destination = ray.GetPoint(distance);
            //   Debug.Log(m_destination);
            Debug.Log("aaa");


        }

        var desiredVelocity = m_destination - transform.position;
        desiredVelocity = desiredVelocity.normalized * _MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, _MaxForce);
        steering /= _Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, _MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = -velocity.normalized;
        //  transform.rotation = Quaternion.Euler(-90,transform.rotation.y,transform.rotation.z);

        Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
        Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.magenta);
    }
}
