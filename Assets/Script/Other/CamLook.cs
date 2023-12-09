using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamLook : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _3rdPersonCam;
    [SerializeField]
    private GameObject _player;
 
    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxisRaw("Mouse X");
        var mouseY = Input.GetAxisRaw("Mouse Y");
        transform.localEulerAngles += new Vector3(mouseY, _player.transform.rotation.y, 0);
    }
}
