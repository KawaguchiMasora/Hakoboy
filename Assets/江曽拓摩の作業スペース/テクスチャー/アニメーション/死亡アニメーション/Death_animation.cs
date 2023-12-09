using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_animation : MonoBehaviour
{
    [SerializeField]
    private GameObject ps_obj;
    public void Death_Anime()
    {
        Instantiate(ps_obj, this.transform.position, Quaternion.identity);
    }
}
