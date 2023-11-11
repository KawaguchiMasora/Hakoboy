using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public float cameraZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ZŽ²‚ðŒÅ’è‚µ‚ÄX‚ÆYŽ²‚Ì‚Ý’Ç”ö‚·‚é
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, cameraZ);
    }
}
