using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// PARTS: CPU Cooler, Harddrive, Fans
public class UIActions : MonoBehaviour {

    public GameObject[] pcParts;
    public GameObject hmd;
    public float spawnDistance = 10f;

    public void SpawnMotherboard()
    {
        Vector3 spawnPoint = PointInFrontofHMD();

        for (int i = 0; i <= pcParts.Length - 1 ; i++)
        {
            if (CheckIfExists(pcParts[i]))
            {
                if (pcParts[i].name == "Motherboard")
                {
                    GameObject go = (GameObject)Instantiate(pcParts[i], spawnPoint, Quaternion.identity);
                }
            }
        }
    }

    // runs through UI
    public void OnCategoryClick(Button button)
    {

        GameObject scrollview = GameObject.Find("Scroll View");
        GameObject categories = GameObject.Find("Menu Title").transform.Find("Categories").gameObject;
        Debug.Log(button.name);
        GameObject partPicker = categories.transform.Find(button.name + " Parts").gameObject;
       
        if (scrollview == null)
        {
            Debug.Log("Scroll view could not be found");
            return;
        }
  
        else
        {
            scrollview.SetActive(false);

        }

        if (categories == null)
        {
            Debug.Log("Could not find categories");
            return;
        }

        else
        {
            categories.SetActive(true);
        }

        if (partPicker == null)
        {
            Debug.Log("Could not find the Part category of " + this.name);
            return;
        }

        else
        {
            partPicker.SetActive(true);
        }
    }
   
    public void onBackClick(Button button)
    {

    }

    //public void SpawnCPU()
    //{

    //}

    //public void SpawnGPU()
    //{

    //}

    //public void SpawnCase()
    //{

    //}

    //public void SpawnRAM()
    //{

    //}

    private Vector3 PointInFrontofHMD()
    {
        Ray hmdRay = new Ray(hmd.transform.position, hmd.transform.TransformDirection(Vector3.forward));

        return hmdRay.GetPoint(spawnDistance);
    }

    private bool CheckIfExists(GameObject selectedObj)
    {
        if (!selectedObj)
        {
            Debug.Log("Requested part not found");
            return false;
        }

        else
            return true;
    }
}
