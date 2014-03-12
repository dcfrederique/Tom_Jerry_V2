using UnityEngine;
using System.Collections;

public class ShapeMatchingScript : MonoBehaviour
{
		
		private Vector3 startPos;
		void Start ()
		{
				startPos = transform.position;
		}
		void Update ()
		{
	
		}
		void OnTriggerEnter (Collider colliderinfo)
		{
				if (colliderinfo.name.LastIndexOf (gameObject.name.Split ('(') [0]) != -1) {
						Destroy (gameObject.GetComponent ("tk2dUIDragItem"));
						Destroy (gameObject.collider);
						Destroy (colliderinfo);
						float x = colliderinfo.gameObject.transform.position.x;
						float y = colliderinfo.gameObject.transform.position.y;
						transform.position = new Vector3 (x, y, colliderinfo.gameObject.transform.position.z);
				} else {
						GetComponent<tk2dUIDragItem> ().enabled = false;
						transform.position = startPos;
						GetComponent<tk2dUIDragItem> ().enabled = true;
				}
		}
}
