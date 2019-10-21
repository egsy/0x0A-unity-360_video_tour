using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpherechange : MonoBehaviour
{
    public GameObject m_Fader;

    //This ensures that we don't mash to change spheres
    public bool changing = false;    

    void Awake()
    {

        //Check if we found something
        if (m_Fader == null)
            Debug.LogWarning("No Fader object found on camera.");

    }


    public void ChangeSphere(Transform nextSphere)
    {
        if(m_Fader == null)
        {
           //no fader, so just change the position of camera
            Camera.main.transform.parent.position = nextSphere.position;
        }
        else
        {
            //triger the animation
        }
        //Start the fading process
        //StartCoroutine(FadeCamera(nextSphere));

    }

    void Update()
    {

    }


    IEnumerator FadeCamera(Transform nextSphere)
    {

        //Ensure we have a fader object
        if (m_Fader != null)
        {
            Debug.Log("Got Fader!");
            //Fade the Quad object in and wait 0.75 seconds

            StartCoroutine(FadeIn(0.75f, m_Fader.GetComponent<Renderer>().material));

            yield return new WaitForSeconds(0.75f);

          


            //Fade the Quad object out 
            StartCoroutine(FadeOut(0.75f, m_Fader.GetComponent<Renderer>().material));

            yield return new WaitForSeconds(0.75f);
        }
        else
        {
            Debug.Log("No Fader!");
            //No fader, so just swap the camera position
            Camera.main.transform.parent.position = nextSphere.position;
        }


    }


    IEnumerator FadeOut(float time, Material mat)
    {

        //While we are still visible, remove some of the alpha colour
        while (mat.color.a >= 0.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a - (Time.deltaTime / time));
            //change the bool to true when its completely fade out                      
            yield return null;
        }
    }


    IEnumerator FadeIn(float time, Material mat)
    {
        //While we aren't fully visible, add some of the alpha colour
        while (mat.color.a <= 1.0f)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, mat.color.a + (Time.deltaTime / time));
            //change the bool to true when its completely fade out              
            yield return null;
        }

    }


}
