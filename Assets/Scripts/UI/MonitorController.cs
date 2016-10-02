using UnityEngine;
using System.Collections;

public class MonitorController : MonoBehaviour {

    private GameObject[] slides;
    public int NUMSLIDES = 10;
    public GameObject currentActiveSlide = null;

	// Use this for initialization
	void Start () {

        slides = new GameObject[NUMSLIDES];

        for (int i = 0; i <  NUMSLIDES; i++)
        {
            slides[i] = GameObject.Find("Monitor").transform.Find("Instruction Panel " + (i + 1)).gameObject;
        }
	}
	
    public void showSlide (int slideNum)
    {
        if ((slideNum >= NUMSLIDES) || (slideNum < 0))
        {
            Debug.Log("slideNum is OOB");
            return;
        }

        if (currentActiveSlide != null)
        {
            currentActiveSlide.SetActive(false);
        }

        else
        {
            Debug.Log("no active slide");
            return;
        }

        currentActiveSlide = slides[slideNum];
        currentActiveSlide.SetActive(true);
    }
}
