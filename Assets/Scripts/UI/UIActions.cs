using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
