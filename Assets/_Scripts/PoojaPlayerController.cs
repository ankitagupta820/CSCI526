using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoojaPlayerController : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 10f; //current speed

    [SerializeField] public float _MaxVelocity = 18.0f;   // Maxima Velocity
    [SerializeField] public float _MinVelocity = 5.0f;   // Maxima Velocity
    [SerializeField] public float _NormVelocity = 10.0f;   // Normal Velocity
    [SerializeField] public float _AccSpeed = 0.0f;      // Speed increase delta
  


    [SerializeField] private float startTime; //To Keep track of time for which acceleration keeps

    public Material[] material;
    public int x;
    Renderer rend;



    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];

    }

    // Update is called once per frame
    void Update()
    {
      
        if (_AccSpeed != 0.0 && _moveSpeed <= _MaxVelocity && _moveSpeed >= _MinVelocity)
            _moveSpeed = _moveSpeed + _AccSpeed * Time.deltaTime;
        else
        {
            _AccSpeed = 0.0f;
            if (_moveSpeed != _NormVelocity && Time.time - startTime > 20)
                _moveSpeed = _NormVelocity;
        }


        transform.position += Time.deltaTime * _moveSpeed * Vector3.down;
        //transform.position += Time.deltaTime * _moveSpeed * Vector3.forward;


        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 10)
            transform.position += Time.deltaTime * _moveSpeed * Vector3.right;

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -10)
            transform.position += Time.deltaTime * _moveSpeed * Vector3.left;

        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < 10)
            transform.position += Time.deltaTime * _moveSpeed * Vector3.forward;

        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -5)
            transform.position += Time.deltaTime * _moveSpeed * Vector3.back;


        if (_moveSpeed > _NormVelocity)
            x = 2;
        else if (_moveSpeed < _NormVelocity)
            x = 1;
        else
            x = 0;

        rend.sharedMaterial = material[x];



        //if (Input.GetKey(KeyCode.Space))
        //    transform.position = new Vector3(0, 0.5f, 0);

    }

    public void setSpeedForAccelerate() {
        startTime = Time.time;
        _AccSpeed = 1.0f;
    }

    public void setSpeedForDeAccelerate()
    {
        startTime = Time.time;
        _AccSpeed = -1.0f;
    }


}
