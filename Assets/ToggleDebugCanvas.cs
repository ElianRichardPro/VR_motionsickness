using UnityEngine;
using UnityEngine.XR;

public class ToggleDebugCanvas : MonoBehaviour
{
    public GameObject debugCanvas;
    private InputDevice leftHand;
    private bool canvasVisible = false;
    private bool buttonPreviouslyPressed = false;

    void Update()
    {
        if (!leftHand.isValid)
            leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        // Détecte l'appui sur le bouton Menu (bouton hamburger manette gauche)
        if (leftHand.TryGetFeatureValue(CommonUsages.menuButton, out bool isPressed))
        {
            // Toggle uniquement au moment où on appuie (pas en maintenant)
            if (isPressed && !buttonPreviouslyPressed)
            {
                canvasVisible = !canvasVisible;
                debugCanvas.SetActive(canvasVisible);
            }
            buttonPreviouslyPressed = isPressed;
        }
    }
}