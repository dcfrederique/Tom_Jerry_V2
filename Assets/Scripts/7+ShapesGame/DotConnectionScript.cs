using UnityEngine;
using System.Collections;

public class DotConnectionScript : MonoBehaviour
{
		private Vector3 startPos;
		// Use this for initialization
		void Start ()
		{
				startPos = transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		void OnTriggerExit (Collider collisionInfo)
		{
				int otherDotNr = int.Parse (collisionInfo.gameObject.name);
				Debug.Log (otherDotNr);
				int ownNr = int.Parse (gameObject.name);
				if (ownNr + 1 == otherDotNr) {
						Destroy (GetComponent<DotConnectionScript> ());
						GameObject.Find ("" + otherDotNr).AddComponent ("DotConnectionScript");
						Destroy (gameObject);
				}
		}
		void OnMouseUp ()
		{
				transform.position = startPos;
		}
}
