using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour
{
    public GameObject info;

    public void MoreInfo(GameObject info)
    {
        if (info.activeSelf == true)
        {
            info.SetActive(false);
        }
        else
        {
            info.SetActive(true);
        }
    }

}
