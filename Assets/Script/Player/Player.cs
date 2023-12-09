using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Player : MonoBehaviour
{
    [SerializeField]
    private CinemachineRecomposer _3rdPersonCamRecomposer;

    [SerializeField]
    private CharacterController _controller;

    
   
    private Vector3 _direction, _velocity;
    [SerializeField]
    private float _yVelocity, _jumpHeight = 10f, _gravity, _speed = 3;
    
    [SerializeField]
    private int _lookSensitivityX , _lookSensitivityY;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Debug.DrawRay(transform.position, Vector2.down, Color.red);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
       
        var mouseX = Input.GetAxisRaw("Mouse X") * _lookSensitivityX;
        transform.localEulerAngles += new Vector3(transform.localEulerAngles.x, mouseX ,  transform.localEulerAngles.z);
        var mouseY = Input.GetAxisRaw("Mouse Y") * _lookSensitivityY;
        _3rdPersonCamRecomposer.m_Tilt -= mouseY;
        
        if(_3rdPersonCamRecomposer.m_Tilt < -41)
        {
            _3rdPersonCamRecomposer.m_Tilt = -41;
        }
        if(_3rdPersonCamRecomposer.m_Tilt > -10)
        {
            _3rdPersonCamRecomposer.m_Tilt = -10;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Movement()
    {
        
        if (_controller.isGrounded == true)
        {

            float horizontalXInput = Input.GetAxisRaw("Horizontal");
            float horizontalZInput = Input.GetAxisRaw("Vertical");
            _direction = new Vector3(horizontalXInput, 0, horizontalZInput);
            _velocity = _direction * _speed;
            _velocity = transform.TransformDirection(_velocity);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }
           
        }
        else
        {
            _yVelocity -= _gravity * Time.deltaTime;
        }
        
       
       

        _velocity.y = _yVelocity;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
