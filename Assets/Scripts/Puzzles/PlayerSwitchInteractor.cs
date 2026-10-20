using UnityEngine;

// Look at a switch and press E to use it.
// Input handling must be set to Both or Input Manager (Old).
public class PlayerSwitchInteractor : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactionDistance = 3f;
    [SerializeField] private LayerMask interactableLayers = ~0;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        if (playerCamera == null)
        {
            Debug.LogWarning("Assign the player camera to PlayerSwitchInteractor.", this);
            return;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayers))
        {
            PowerSwitch powerSwitch = hit.collider.GetComponentInParent<PowerSwitch>();
            if (powerSwitch != null)
                powerSwitch.Interact();
        }
    }
}
