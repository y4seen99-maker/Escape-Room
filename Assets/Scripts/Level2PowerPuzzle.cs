
using UnityEngine;

public class Level2PowerPuzzle : MonoBehaviour
{
    [Header("Level 2 Objects")]
    public Transform player;
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject exitDoor;
    public GameObject warningLight;

    [Header("Settings")]
    public float interactionDistance = 2.5f;

    private int[] correctOrder = { 2, 1, 3 };
    private int currentStep = 0;
    private bool puzzleSolved = false;

    private bool[] activated = new bool[3];
    private Renderer[] switchRenderers = new Renderer[3];

    private string message = "Activate the switches in the correct order.";

    void Start()
    {
        GameObject[] switches = { switch1, switch2, switch3 };

        for (int i = 0; i < 3; i++)
        {
            if (switches[i] != null)
            {
                switchRenderers[i] = switches[i].GetComponent<Renderer>();
            }
        }

        Debug.Log("Level 2 Power Puzzle Ready!");
    }

    void Update()
    {
        if (puzzleSolved || player == null)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject[] switches = { switch1, switch2, switch3 };

            int closestSwitch = -1;
            float closestDistance = interactionDistance;

            for (int i = 0; i < 3; i++)
            {
                if (switches[i] == null)
                    continue;

                float distance = Vector3.Distance(
                    player.position,
                    switches[i].transform.position
                );

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestSwitch = i;
                }
            }

            if (closestSwitch >= 0)
            {
                ActivateSwitch(closestSwitch + 1);
            }
        }
    }

    public void ActivateSwitch(int switchNumber)
    {
        if (puzzleSolved)
            return;

        int index = switchNumber - 1;

        if (index < 0 || index >= 3)
            return;

        if (activated[index])
        {
            message = "This switch is already activated!";
            return;
        }

        if (switchNumber == correctOrder[currentStep])
        {
            activated[index] = true;
            currentStep++;

            if (switchRenderers[index] != null)
            {
                switchRenderers[index].material.color = Color.green;
            }

            message = "Correct! Switch " + switchNumber + " activated.";

            if (currentStep == correctOrder.Length)
            {
                puzzleSolved = true;
                message = "POWER RESTORED! Exit unlocked!";

                if (exitDoor != null)
                {
                    exitDoor.SetActive(false);
                }

                if (warningLight != null)
                {
                    Renderer lightRenderer = warningLight.GetComponent<Renderer>();

                    if (lightRenderer != null)
                    {
                        lightRenderer.material.color = Color.green;
                    }
                }

                Debug.Log("Level 2 completed!");
            }
        }
        else
        {
            message = "Wrong switch order! Try again.";
            ResetSwitches();
        }
    }

    void ResetSwitches()
    {
        currentStep = 0;

        for (int i = 0; i < 3; i++)
        {
            activated[i] = false;

            if (switchRenderers[i] != null)
            {
                switchRenderers[i].material.color = Color.red;
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(15, 15, 450, 85), "LEVEL 2 - POWER RESTORATION");

        GUI.Label(new Rect(30, 45, 420, 25), message);

        GUI.Label(
            new Rect(30, 70, 420, 25),
            "Press E near a switch to activate it."
        );
    }
}
