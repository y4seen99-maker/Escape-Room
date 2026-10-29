using UnityEngine;

public class Level3_Switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Level3SwitchManager.totalSwitches = Level3SwitchManager.totalSwitches + 1;
        }
    }
}
