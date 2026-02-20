using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class DebugVRDisplay : MonoBehaviour
{
    public TextMeshProUGUI headText;
    public TextMeshProUGUI leftControllerText;
    public TextMeshProUGUI rightControllerText;

    private InputDevice headDevice;
    private InputDevice leftHand;
    private InputDevice rightHand;

    void Update()
    {
        // Re-détection si non connecté
        if (!headDevice.isValid)
            headDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        if (!leftHand.isValid)
            leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (!rightHand.isValid)
            rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Tête
        if (headDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 headPos) &&
            headDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion headRot))
        {
            headText.text = $"Head Pos: {headPos:F2} ¦ Head Rot: {headRot.eulerAngles:F1}";
        }

        // Manette gauche
        if (leftHand.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 lPos) &&
            leftHand.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion lRot))
        {
            leftControllerText.text = $"Left Pos: {lPos:F2} ¦ Left Rot: {lRot.eulerAngles:F1}";
        }

        // Manette droite
        if (rightHand.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 rPos) &&
            rightHand.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rRot))
        {
            rightControllerText.text = $"Right Pos: {rPos:F2} ¦ Right Rot: {rRot.eulerAngles:F1}";
        }
    }
}