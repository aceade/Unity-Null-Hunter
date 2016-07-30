# Unity-Null-Hunter
A Unity Editor extension that searches for null fields in the scene

## Purpose
Unity Null Hunter is an Editor extension I wrote after being spammed with NullReferenceExceptions when I forgot to assign some public variables. It consists of an Editor Window that allows you to add or remove MonoBehaviours to examine, a utility class that holds any null fields found in a particular MonoBehaviour, and a test MonoBehaviour to demonstrate the functionality.

## How to use it

1. Copy this into the Assets/Aceade folder.
2. Attach the TestScript.cs file to a GameObject, and leave the _Target Transform_ field blank.
3. On the main toolbar, click "Tools" -> Aceade -> FindNullRefs.
4. When the window opens, add the TestScript MonoBehaviour in the field at the top.
5. Click the "Find Null References" button.

## Licence
MIT Licence (see the attached Licence file)

