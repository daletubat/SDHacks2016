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

        MonitorController monitorController = Monitor.GetComponent<MonitorController>();

        switch (curr_state)
        {
            case 0: // motherboard attached to table
                if (previousGrabbingObject.name != "Motherboard") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("CPU").gameObject.SetActive(true);
                monitorController.showSlide(1);
                break;

            case 1: // cpu attached to motherboard; snappingObject = cpu
                if(previousGrabbingObject.name != "CPU") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("CPUCooler").gameObject.SetActive(true);
                monitorController.showSlide(2);
                break;

            case 2: // fan attached to cpu
                if (previousGrabbingObject.name != "CPUCooler") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("RAM").gameObject.SetActive(true);
                monitorController.showSlide(3);
                break;

            case 3: // ram attached to motherboard
                if (previousGrabbingObject.name != "RAM") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("Case").gameObject.SetActive(true);
                monitorController.showSlide(4);
                break;

            case 4: // case attached to table
                // unsnap motherboard
                GameObject motherboard = GameObject.Find("Motherboard");
                VRTK.VRTK_SnappingObject snappingObject = motherboard.GetComponent<VRTK.VRTK_SnappingObject>();
                snappingObject.enabled = true;
                snappingObject.isGrabbable = true;
                snappingObject.attachTo = "caseMoboSnap";
                snappingObject.attachPoint = new Vector3(0.134f, -0.0595f, -0.0063f);
                snappingObject.attachRotation = new Vector3(0, -90, 90);
                Rigidbody rigidbody = motherboard.GetComponent<Rigidbody>();
                rigidbody.useGravity = true;
                rigidbody.isKinematic = false;
                GameObject.Find("CPU").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("CPUCooler").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("RAM").GetComponent<BoxCollider>().enabled = false;
                monitorController.showSlide(5);
                break;

            case 5: // 
                if (previousGrabbingObject.name != "Motherboard") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("SSD").gameObject.SetActive(true);
                monitorController.showSlide(6);
                break;

            case 6:
                if (previousGrabbingObject.name != "SSD") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("GTX1080").gameObject.SetActive(true);
                monitorController.showSlide(7);
                break;
            case 7:
                if (previousGrabbingObject.name != "GTX1080") { return; }
                GameObject.Find("PartsQueue").transform.FindChild("PowerSupply").gameObject.SetActive(true);
                monitorController.showSlide(8); 
                break;
            case 8:
                monitorController.showSlide(9);
                break;
            case 9:
                monitorController.showSlide(10);
                GameObject.Find("Case").transform.localPosition = new Vector3(0.06f, 0.3f, -0.55f);
                GameObject.Find("Case").transform.localEulerAngles = new Vector3(0f, 0f, 180f);
                //GameObject.Find("Case").GetComponent<Rigidbody>().isKinematic = true;
                GameObject.Find("Case").GetComponent<Rotating>().IsRotating = true;
                break;
    
        }

        curr_state++;

        Debug.Log("State is now: " + curr_state);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
