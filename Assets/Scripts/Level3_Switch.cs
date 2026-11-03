using UnityEngine;

public class Level3_Switch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject SManager;

    void Start()
    {
        SManager = GameObject.Find("SwitchManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            SManager.totalSwitches += 1;
            
        }
    }
}
