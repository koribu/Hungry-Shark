using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float _Mass = 15;
    public float _MaxVelocity = 3;
    public float _MaxForce = 15;

    private Vector3 _velocity;
    private Vector3 _destination;

    private int _jellyNum;

    [SerializeField]
    private Text _jellyNumText;
    [SerializeField]
    private Text _ColorText;
    private GameObject _jellyParent;
    // Start is called before the first frame update
    void Start()
    {
        _velocity = Vector3.zero;
        _jellyNum = 0;
        _jellyParent = GameObject.Find("JellyParent");

    }

    // Update is called once per frame
    void Update()
    {
        Plane plane = new Plane(Vector3.forward, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && plane.Raycast(ray, out distance))
        {
            _destination = ray.GetPoint(distance);


        }

        var desiredVelocity = _destination - transform.position;
        desiredVelocity = desiredVelocity.normalized * _MaxVelocity;

        var steering = desiredVelocity - _velocity;
        steering = Vector3.ClampMagnitude(steering, _MaxForce);
        steering /= _Mass;

        _velocity = Vector3.ClampMagnitude(_velocity + steering, _MaxVelocity);
        if(Vector3.Distance(transform.position,_destination) >1)
            transform.position += _velocity * Time.deltaTime;
        transform.forward = -_velocity.normalized;
        //  transform.rotation = Quaternion.Euler(-90,transform.rotation.y,transform.rotation.z);

        Debug.DrawRay(transform.position, _velocity.normalized * 2, Color.green);
        Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.magenta);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "jelly")
        {
            _jellyNum++;
            _jellyNumText.text = _jellyNum + " Jelly!";
            Destroy(other.gameObject);
          
        }
        else if (other.tag == "greenfish")
        {
            _ColorText.text ="GREEN Fish!";
            Destroy(other.gameObject);
        }
        else if (other.tag == "yellowfish")
        {
            _ColorText.text = "YELLOW Fish!";
            Destroy(other.gameObject);
        }
        else if (other.tag == "redfish")
        {
            _ColorText.text = "RED Fish!";
            Destroy(other.gameObject);
        }
    }
}
