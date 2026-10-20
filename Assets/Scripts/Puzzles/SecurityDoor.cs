using UnityEngine;

// Beginner-friendly prototype: door rotates open around its hinge.
public class SecurityDoor : MonoBehaviour
{
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openingSpeed = 100f;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool unlocked;

    private void Awake()
    {
        closedRotation = transform.localRotation;
        openRotation = closedRotation * Quaternion.Euler(0f, openAngle, 0f);
    }

    private void Update()
    {
        if (unlocked)
            transform.localRotation = Quaternion.RotateTowards(
                transform.localRotation, openRotation, openingSpeed * Time.deltaTime);
    }

    public void Unlock()
    {
        unlocked = true;
    }
}
