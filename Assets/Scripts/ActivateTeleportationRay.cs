using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject rightTeleportation;
    public GameObject leftTeleportation;

    public InputActionProperty rightActivate;
    public InputActionProperty leftActivate;

    public InputActionProperty rightCancel;
    public InputActionProperty leftCancel;

    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rightRay;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor leftRay;

    void Update()
    {
        bool isrightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool righttValid);

        rightTeleportation.SetActive(!isrightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);

        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);

        leftTeleportation.SetActive(!isLeftRayHovering && leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f);        
    }
}
