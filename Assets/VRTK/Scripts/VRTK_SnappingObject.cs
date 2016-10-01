// Interactable Object|Scripts|0160
namespace VRTK
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using Highlighters;

    public class VRTK_SnappingObject : VRTK_InteractableObject
    {
        //final attach point of object
        public Vector3 attachPoint = new Vector3(0f, 0f, 0f);
        public string attachTo = "Nothing";
        private bool colliding = false;
        private GameObject collidingObj;

    

        /// <summary>
        /// The Ungrabbed method is called automatically when the object has stopped being grabbed. It is also a virtual method to allow for overriding in inherited classes.
        /// </summary>
        /// <param name="previousGrabbingObject">The game object that was previously grabbing this object.</param>
        public override void Ungrabbed(GameObject previousGrabbingObject)
        {
            base.Ungrabbed(previousGrabbingObject);
            
            Collider collider = previousGrabbingObject.GetComponent(typeof(Collider)) as Collider;

            if (colliding)
            {
                this.transform.parent = collidingObj.transform;
                Debug.Log("hey");
                this.transform.localPosition = attachPoint;
                this.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);

            }

        }

        void OnTriggerEnter(Collider collider) {

            string checkAttach = collider.gameObject.name;
            if(checkAttach == attachTo)
            {
                colliding = true;
                collidingObj = collider.gameObject;

            }
            else
            {
                colliding = false;
            }

        }

        void OnTriggerExit(Collider collider)
        {
            colliding = false;

        }


    }
}
