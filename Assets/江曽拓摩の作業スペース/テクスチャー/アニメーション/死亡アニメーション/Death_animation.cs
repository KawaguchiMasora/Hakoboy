using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_animation : MonoBehaviour
{
    [SerializeField]
    private GameObject ps_obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Death_Anime()
    {
        Instantiate(ps_obj, this.transform.position, Quaternion.identity);
    }
}
