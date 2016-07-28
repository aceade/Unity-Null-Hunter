using UnityEngine;

namespace Aceade.Util.NullHunter
{
	/// <summary>
	/// Test script. Attach this to the main camera, and leave the targetTransform field blank.
	/// </summary>
	public class TestScript : MonoBehaviour {

		/// <summary>
		/// The target transform should not be null. If so, it will be flagged as a null public field.
		/// </summary>
		public Transform targetTransform;

		/// <summary>
		/// The second transform should not be null either. However, private unitialised variables will not be reported.
		/// This is a limitation of Reflection.
		/// </summary>
		Transform secondTransform;

		/// <summary>
		/// The speed is left blank; it defaults to zero, and thus will not be reported.
		/// </summary>
		public int speed;

		Vector3 direction = Vector3.up;

		/// <summary>
		/// The test string is not used anywhere. Its purpose is to demonstrate that private
		/// uninitialised primitives will not be reported.
		/// </summary>
		string testString;
		
		// Update is called once per frame. You do *not* want a NullReference being spammed into the log every frame.
		void Update () {
			targetTransform.Rotate(direction * speed * Time.deltaTime);
		}
	}
}

