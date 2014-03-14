using UnityEngine;
using System.Collections;

public class ShapeMatchingScript : MonoBehaviour
{
		
		private Vector3 startPos;
		private int correctScore = 0;
		void Start ()
		{
				startPos = transform.position;
				PlayerPrefs.SetInt ("correctScore", correctScore);
		}
		void OnTriggerEnter (Collider colliderinfo)
		{
				if (colliderinfo.name.LastIndexOf (gameObject.name.Split ('(') [0]) != -1) {
						Destroy (gameObject.GetComponent ("tk2dUIDragItem"));
						Destroy (gameObject.collider);
						Destroy (colliderinfo.gameObject);
						float x = colliderinfo.gameObject.transform.position.x;
						float y = colliderinfo.gameObject.transform.position.y;
						transform.position = new Vector3 (x, y, colliderinfo.gameObject.transform.position.z);
						correctScore = PlayerPrefs.GetInt ("correctScore");
						correctScore++;
						PlayerPrefs.SetInt ("correctScore", correctScore);

				} else if (colliderinfo.name.IndexOf ("Answer") != -1) {
						GetComponent<tk2dUIDragItem> ().enabled = false;
						transform.position = startPos;
						GetComponent<tk2dUIDragItem> ().enabled = true;
				}
		}
}
