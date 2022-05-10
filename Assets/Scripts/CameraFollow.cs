using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Component player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = player.transform.position.x - 6f;
        pos.y = player.transform.position.y + 6f;
        pos.z = player.transform.position.z;
        transform.position = pos;
    }
}
