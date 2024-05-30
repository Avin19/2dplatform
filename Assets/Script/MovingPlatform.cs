using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> movingPlatform;
    [SerializeField] int platformNum = 0;
    private void Awake()
    {
        transform.position = movingPlatform[0].position;
    }
    private void Update()
    {

        MovingPlatformFromOneTransForm();
        

    }
   
   
    private void MovingPlatformFromOneTransForm()
    {
        if (Vector3.Distance(transform.position, movingPlatform[platformNum].position) >= 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, movingPlatform[platformNum].position, Time.deltaTime*0.5f);
        }
        else
        {
            if (platformNum < movingPlatform.Capacity-1)
            {
                platformNum++;
               

            }
            else
            {
                platformNum = 0;
                transform.position = Vector3.Lerp(transform.position, movingPlatform[platformNum].position, Time.deltaTime);
            }

        }

    }
}
