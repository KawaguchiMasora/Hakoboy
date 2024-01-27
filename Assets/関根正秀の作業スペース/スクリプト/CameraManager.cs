using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Lookout;
    public float cameraZ;
    public float caneraY;
    private Collider2D LookCollider;

    public bool Look = true;
    // Start is called before the first frame update
    void Start()
    {
        LookCollider = Lookout.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Look == true)
        {
            //ZŽ²‚ðŒÅ’è‚µ‚ÄX‚ÆYŽ²‚Ì‚Ý’Ç”ö‚·‚é
            Vector3 playerPos = this.player.transform.position;
            transform.position = new Vector3(playerPos.x, caneraY, cameraZ);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Lookout)
        {
            Look = false;
            Debug.Log("IN");
        }
    }
}
