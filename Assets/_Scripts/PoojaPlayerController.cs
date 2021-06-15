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

    private Rigidbody characterBody;
    public Material[] material;
    public int x;
    Renderer rend;

    void Start()
    {
        characterBody = gameObject.GetComponent<Rigidbody>();
        // Material changes based on accerlation/deceleration
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

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


        //transform.position += Time.deltaTime * _moveSpeed * Vector3.down;
        //transform.position += Time.deltaTime * _moveSpeed * Vector3.forward;
        //characterBody.AddForce(new Vector3(0, -_moveSpeed * Time.deltaTime , 0)); // Using Gravity


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && transform.position.x < 13)
            /*transform.position += Time.deltaTime * _moveSpeed * Vector3.right;*/
            /*characterBody.MovePosition(transform.position + Time.deltaTime * _moveSpeed * Vector3.right);*/
            characterBody.AddForce(new Vector3(_moveSpeed * Time.deltaTime, 0, 0));

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && transform.position.x > -3)
            /*transform.position += Time.deltaTime * _moveSpeed * Vector3.left;*/
            /*characterBody.MovePosition(transform.position + Time.deltaTime * _moveSpeed * Vector3.left);*/
            characterBody.AddForce(new Vector3(-_moveSpeed * Time.deltaTime, 0, 0));

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && transform.position.z < 2)
            /*transform.position += Time.deltaTime * _moveSpeed * Vector3.forward;*/
            /*characterBody.MovePosition(transform.position + Time.deltaTime * _moveSpeed * Vector3.forward);*/
            characterBody.AddForce(new Vector3(0, 0 ,_moveSpeed * Time.deltaTime));

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && transform.position.z > -10)
            /*transform.position += Time.deltaTime * _moveSpeed * Vector3.back;*/
            /*characterBody.MovePosition(transform.position + Time.deltaTime * _moveSpeed * Vector3.back);*/
            characterBody.AddForce(new Vector3(0, 0 ,-_moveSpeed * Time.deltaTime));

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
        _AccSpeed = 2.0f;
    }

    public void setSpeedForDeAccelerate()
    {
        startTime = Time.time;
        _AccSpeed = -2.0f;
    }


}
