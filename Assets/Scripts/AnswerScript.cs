using UnityEngine;
using System.Collections;

public class AnswerScript : MonoBehaviour
{

		// Use this for initialization
		public string correctAnswer;
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		void OnTriggerEnter (Collider colliderinfo)
		{
				if (correctAnswer.Equals (colliderinfo.name)) {
						Destroy (colliderinfo.gameObject.GetComponent ("tk2dUIDragItem"));
						Destroy (colliderinfo);
						Destroy (gameObject.collider);
						float x = gameObject.transform.position.x;
						float y = gameObject.transform.position.y;
						colliderinfo.gameObject.transform.position = new Vector3 (x, y, colliderinfo.gameObject.transform.position.z);
				}
		}
}
