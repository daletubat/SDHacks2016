using UnityEngine;
using System.Collections;

public class Workspace_Story : MonoBehaviour {
    public GameObject Monitor;
    // Use this for initialization
    public int curr_state = 0;

    void Start () {
        // monitor start instructions
        // user snaps mobo into desk

	
	}
	public void ungrabbed(GameObject previousGrabbingObject)
    {
        Debug.Log("Debug"+previousGrabbingObject.name);

        if (previousGrabbingObject.name == "Controller (right)" || previousGrabbingObject.name == "Controller (left)")
            return;

        


        switch (curr_state)
        {
            case 0: // motherboard attached to table
                if (previousGrabbingObject.name != "Motherboard") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("CPU").gameObject.SetActive(true);
                break;

            case 1: // cpu attached to motherboard; snappingObject = cpu
                if(previousGrabbingObject.name != "CPU") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("CPUCooler").gameObject.SetActive(true);
                break;

            case 2: // fan attached to cpu
                if (previousGrabbingObject.name != "CPUCooler") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("RAM").gameObject.SetActive(true);
                break;

            case 3: // ram attached to motherboard
                if (previousGrabbingObject.name != "RAM") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("Case").gameObject.SetActive(true);
                break;

            case 4: // case attached to table
                // unsnap motherboard
                GameObject motherboard = GameObject.Find("Motherboard");
                VRTK.VRTK_SnappingObject snappingObject = motherboard.GetComponent<VRTK.VRTK_SnappingObject>();
                snappingObject.enabled = true;
                snappingObject.isGrabbable = true;
                snappingObject.attachTo = "caseSnap";
                snappingObject.attachPoint = new Vector3(0.0048f, 0.009f, 0f);
                snappingObject.attachRotation = new Vector3(180, 90, 0);
                Rigidbody rigidbody = motherboard.GetComponent<Rigidbody>();
                rigidbody.useGravity = true;
                rigidbody.isKinematic = false;
                GameObject.Find("CPU").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("CPUCooler").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("RAM").GetComponent<BoxCollider>().enabled = false;

                break;

            case 5: // 

                break;

            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
        }

        curr_state++;

        Debug.Log("State is now: " + curr_state);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
