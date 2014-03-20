using UnityEngine;
using System.Collections;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class SoundEffectsHelper : MonoBehaviour
{
	
		/// <summary>
		/// Singleton
		/// </summary>
		public static SoundEffectsHelper Instance;
		public AudioClip correctSound;
		public AudioClip wrongSound;
	
		void Awake ()
		{
				Instance = this;
		}
	
		public void MakeCorrectAnswerSound ()
		{
				MakeSound (correctSound);
		}
	
		public void MakeWrongAnswerSound ()
		{
				MakeSound (wrongSound);
		}
	
		/// <summary>
		/// Play a given sound
		/// </summary>
		/// <param name="originalClip"></param>
		private void MakeSound (AudioClip originalClip)
		{
				// As it is not 3D audio clip, position doesn't matter.
				AudioSource.PlayClipAtPoint (originalClip, transform.position);
		}
}