using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace Aceade.Util.NullHunter 
{
	public class FindNullReferences : EditorWindow
	{
		
		List<MonoBehaviour> types = new List<MonoBehaviour>();
		List<NullRefHolder> objectsWithNullRefs = new List<NullRefHolder>();

		MonoBehaviour objectToAdd;

		[MenuItem("Tools/Aceade/FindNullRefs")]
		static void ShowWindow()
		{
			EditorWindow myWindow = EditorWindow.GetWindow(typeof(FindNullReferences));
			myWindow.titleContent = new GUIContent("Null Fields in Scene");
		}

		void OnGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.BeginHorizontal();
			objectToAdd = (MonoBehaviour)EditorGUILayout.ObjectField(objectToAdd, typeof(MonoBehaviour));
			if (GUILayout.Button("Add Type"))
			{
				AddType(objectToAdd);
			}
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();

			// show the types here
			GUILayout.Box("Examining:");
			for (int i = 0; i < types.Count; i++)
			{
				
				EditorGUILayout.BeginHorizontal();
				types[i] = (MonoBehaviour)EditorGUILayout.ObjectField(types[i], typeof(MonoBehaviour));
				if (GUILayout.Button("X"))
				{
					types.RemoveAt(i);
				}
				EditorGUILayout.EndHorizontal();
			}
			EditorGUILayout.Space();

			if (GUILayout.Button("Find Null References"))
			{
				SearchForNulls();
			}
		}

		void SearchForNulls()
		{
			objectsWithNullRefs.Clear();
			for (int j = 0; j < types.Count; j++)
			{
				FindNullRefInType(types[j]);
			}
			CreateReport();
		}

		/// <summary>
		/// Adds the specified type, if it is not already in the list.
		/// </summary>
		/// <param name="type">Type.</param>
		void AddType(MonoBehaviour type)
		{
			Debug.LogFormat("Adding a new type {0} to examine", type);
			if (!types.Contains(type))
			{
				types.Add(type);
			}
		}

		void FindNullRefInType(MonoBehaviour theType)
		{
			var fields = theType.GetType().GetFields();
			var nullFields = new List<FieldInfo>();
			for (int k = 0; k < fields.Length; k++)
			{
				var theField = fields[k];
				var fieldName = theField.Name;
				object value = theField.GetValue(theType);
				if (value.Equals(null))
				{
					Debug.LogWarningFormat("The field {0} of type {1} is null!", fieldName, theType);
					nullFields.Add(theField);
				}
			}

			// if the object has at least 1 null field, add it to the report list.
			if(nullFields.Count > 0)
			{
				NullRefHolder newWarning = new NullRefHolder(theType, nullFields);
				objectsWithNullRefs.Add(newWarning);
			}
		}

		/// <summary>
		/// Creates the report.
		/// </summary>
		void CreateReport()
		{
			Debug.Log("Generating report");
			var count = objectsWithNullRefs.Count;
			string report = string.Format("{0} null {1} found at {2}\n\n", count, count == 1 ? "object" : "objects",
				DateTime.Now);
			for (int j = 0; j < objectsWithNullRefs.Count; j++)
			{
				report += objectsWithNullRefs[j];
			}
			Debug.Log(report);

			InputOutput.WriteToFile(report, "Assets/Aceade/NullCheck/NullReport.txt");
		}
	}

}
