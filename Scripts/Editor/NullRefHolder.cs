using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

namespace Aceade.Util.NullHunter
{
	/// <summary>
	/// Utility class that holds a MonoBehaviour and null fields on that MonoBehaviour.
	/// </summary>
	public class NullRefHolder 
	{

		MonoBehaviour targetObject;

		List<FieldInfo> fields = new List<FieldInfo>();

		/// <summary>
		/// Create a new empty Warning class.
		/// </summary>
		public NullRefHolder ()
		{

		}

		/// <summary>
		/// Create a new Warning for an object that has null fields.
		/// </summary>
		/// <param name="newTarget">Object with null fields.</param>
		/// <param name="newFields">List of null fields.</param>
		public NullRefHolder(MonoBehaviour newTarget, List<FieldInfo> newFields)
		{
			targetObject = newTarget;
			fields = newFields;
		}

		/// <summary>
		/// Returns the target object.
		/// </summary>
		/// <returns>The target object.</returns>
		public MonoBehaviour GetTargetObject()
		{
			return targetObject;
		}

		/// <summary>
		/// Sets the target object.
		/// </summary>
		/// <param name="newTargetObject">New target object.</param>
		public void SetTargetObject(MonoBehaviour newTargetObject)
		{
			targetObject = newTargetObject;
		}

		/// <summary>
		/// Returns the list of null fields.
		/// </summary>
		/// <returns>The fields.</returns>
		public List<FieldInfo> GetFields()
		{
			return fields;
		}

		/// <summary>
		/// Sets a new list of null fields.
		/// </summary>
		/// <returns>The fields.</returns>
		/// <param name="newFields">New fields.</param>
		public void SetFields(List<FieldInfo> newFields)
		{
			fields = newFields;
		}


		public override string ToString ()
		{
			var message = string.Format("Type {0}: {1} fields\n", targetObject, fields.Count);
			for (int i = 0; i < fields.Count; i++)
			{
				message += ("\t" + fields[i].Name + "\n");
			}
			message += ("\n");

			return message;
		}
	}

}
