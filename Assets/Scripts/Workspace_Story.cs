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
        Debug.Log("Debug");
        VRTK.VRTK_SnappingObject snappingObject = previousGrabbingObject.GetComponent<VRTK.VRTK_SnappingObject>();

        switch (curr_state++)
        {
            case 0: // motherboard attached to table
                break;

            case 1: // cpu attached to motherboard; snappingObject = cpu
                break;
            case 2: // fan attached to cpu
                break;

            case 3: // ram attached to motherboard
                break;
            case 4: // case attached to table
                // unsnap motherboard
                snappingObject.attachTo = "caseSnap";
                snappingObject.attachPoint = new Vector3(0.0048f, 0.009f, 0f);
                snappingObject.attachRotation = new Vector3(180, 90, 0);
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

        Debug.Log("State is now: " + curr_state);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
