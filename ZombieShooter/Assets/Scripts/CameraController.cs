using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera  followCamera;
    [SerializeField] private float mouseLookSensitivity = 1f;
    [SerializeField] private CinemachineFreeLook freelookCamera;
    private CinemachineComposer aim;


    private void Awake()
    {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            freelookCamera.Priority = 100;
            freelookCamera.m_RecenterToTargetHeading.m_enabled = false;
        } else if (Input.GetMouseButtonUp(1)) {
            freelookCamera.Priority = 0;
            freelookCamera.m_RecenterToTargetHeading.m_enabled = true;
        }
        if (Input.GetMouseButton(1) == false) {
            var vertical = Input.GetAxis("Mouse Y") * mouseLookSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -10f, 10f);
        }
    }
}
