using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PowerSwitch : MonoBehaviour
{
    [SerializeField] private PowerSequencePuzzle puzzle;
    [SerializeField] private Renderer indicatorRenderer;
    [SerializeField] private Color offColour = Color.red;
    [SerializeField] private Color onColour = Color.green;

    private bool activated;
    private Material indicatorMaterial;

    private void Awake()
    {
        if (indicatorRenderer != null)
            indicatorMaterial = indicatorRenderer.material;
        SetActivated(false);
    }

    public void Interact()
    {
        if (puzzle == null)
        {
            Debug.LogWarning("Assign the puzzle to this switch.", this);
            return;
        }
        puzzle.TryActivate(this);
    }

    public void SetActivated(bool value)
    {
        activated = value;
        if (indicatorMaterial != null)
            indicatorMaterial.color = activated ? onColour : offColour;
    }
}
