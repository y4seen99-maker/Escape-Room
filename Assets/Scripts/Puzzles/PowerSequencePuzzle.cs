using UnityEngine;
using UnityEngine.Events;

// Assign the switches order in the Inspector (0, 1, 2).
public class PowerSequencePuzzle : MonoBehaviour
{
    [SerializeField] private PowerSwitch[] switches = new PowerSwitch[3];
    [SerializeField] private SecurityDoor securityDoor;
    [SerializeField] private UnityEvent onPuzzleSolved;

    private int nextSwitchIndex;
    private bool solved;

    public bool IsSolved { get { return solved; } }
    public int Progress { get { return nextSwitchIndex; } }

    private void Start()
    {
        ResetPuzzle();
    }

    public void TryActivate(PowerSwitch selectedSwitch)
    {
        if (solved || selectedSwitch == null)
            return;

        if (switches == null || switches.Length != 3)
        {
            Debug.LogWarning("Power puzzle requires exactly three switches.", this);
            return;
        }

        if (selectedSwitch != switches[nextSwitchIndex])
        {
            Debug.Log("Wrong switch! Power sequence reset.");
            ResetPuzzle();
            return;
        }

        selectedSwitch.SetActivated(true);
        nextSwitchIndex++;
        Debug.Log("Power restored: " + nextSwitchIndex + " / 3");

        if (nextSwitchIndex == switches.Length)
        {
            solved = true;
            Debug.Log("Power restored! Security door unlocked.");
            if (securityDoor != null)
                securityDoor.Unlock();
            onPuzzleSolved.Invoke();
        }
    }

    public void ResetPuzzle()
    {
        solved = false;
        nextSwitchIndex = 0;
        if (switches == null)
            return;
        foreach (PowerSwitch powerSwitch in switches)
        {
            if (powerSwitch != null)
                powerSwitch.SetActivated(false);
        }
    }
}
