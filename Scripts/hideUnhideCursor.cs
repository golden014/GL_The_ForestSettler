using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class hideUnhideCursor : MonoBehaviour
{
    public CinemachineFreeLook cam;
    public KeyCode utkHide;

    private void Update()
    {
        if (Input.GetKeyDown(utkHide)) {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = (Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked);

            if (Cursor.visible)
            {
                cam.m_YAxis.m_InputAxisName = "";
                cam.m_XAxis.m_InputAxisName = "";
            } else
            {
                cam.m_YAxis.m_InputAxisName = "Mouse Y";
                cam.m_XAxis.m_InputAxisName = "Mouse X";
            }
        }
    }
}
