using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAttacher : MonoBehaviour
{

    [SerializeField] private List<Camera> cameras;
    private Camera lastEnabled;
    // Start is called before the first frame update
    void Start()
    {
        lastEnabled = Camera.main;
        for (int i = 1; i < cameras.Count; i++)
            cameras[i].enabled = false;
    }
    // Update is called once per frame
    void Update()
    { 
        for (int i = 0; i < cameras.Count; i++)
        {
            if (Input.GetKeyDown((KeyCode)(49 + i)) &! cameras[i].enabled)
            {                                    
                lastEnabled.enabled = false;
                cameras[i].enabled = true;
                lastEnabled = cameras[i];
                Debug.Log($"Camera {i} was enabled.");
            }
            else if(Input.GetKeyDown((KeyCode)(49 + i)) && cameras[i].enabled)
            {
                Debug.Log($"Camera {i} is already enabled.");
            }
        }
    }
}
