using UnityEngine;

public class SecurityRobot : MonoBehaviour
{

    bool lookAtPlayer = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerDetection.found)
        {
            lookAtPlayer = true;
        }

        if (lookAtPlayer) 
        {
            transform.LookAt(player.transform);
        }

    }
}
