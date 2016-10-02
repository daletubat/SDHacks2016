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
        public Vector3 attachRotation = new Vector3(0f, 0f, 0f);
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
                this.transform.parent = collidingObj.transform.parent.gameObject.transform;
                Debug.Log(this.transform.localRotation);

                this.transform.localPosition = attachPoint;
                this.transform.localEulerAngles = attachRotation;
                this.isGrabbable = false;
                Rigidbody rigidbody = this.GetComponent<Rigidbody>();
                rigidbody.useGravity = false;
                rigidbody.isKinematic = true;


                Renderer renderer = collidingObj.GetComponent<Renderer>();
                //if (renderer != null)
                    //renderer.material.color = Color.blue;
                this.enabled = false;
            }

        }

        void OnTriggerEnter(Collider collider) {
            Renderer renderer = collider.gameObject.GetComponent<Renderer>();

            if (enabled)
            {

                string checkAttach = collider.gameObject.name;
                if (checkAttach == attachTo)
                {
                    colliding = true;
                    collidingObj = collider.gameObject;
                    //if (renderer != null)
                        //renderer.material.color = Color.green;
                }
                else
                {
                    colliding = false;
                    collidingObj = collider.gameObject;
                    //if(renderer != null)
                        //renderer.material.color = Color.red;
                }


            }
        }

        void OnTriggerExit(Collider collider)
        {
            Renderer renderer = collider.gameObject.GetComponent<Renderer>();
            if (enabled)
            {
                if (renderer != null)
                    //renderer.material.color = Color.blue;
                colliding = false;
            }
        }


    }
}
