using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreatePrefab : EditorWindow {

	[MenuItem ("Examples/Create Prefab Quad")]
	static void CreatePrefabQuad() {

		// Create needed folders
		if (!AssetDatabase.IsValidFolder ("Assets/Materials")) {
			AssetDatabase.CreateFolder ("Assets", "Materials");
			Debug.Log ("Materials folder created.");
		}
		if (!AssetDatabase.IsValidFolder ("Assets/Models")) {
			AssetDatabase.CreateFolder ("Assets", "Models");
			Debug.Log ("Models folder created.");
		}
		if (!AssetDatabase.IsValidFolder ("Assets/Prefabs")) {
			AssetDatabase.CreateFolder ("Assets", "Prefabs");
			Debug.Log ("Prefabs folder created.");
		}

		// For the labels of the Prefabs created
		System.DateTime date = System.DateTime.Now;
		string dateString = date.ToString ("yyyyMMddHHmmss");

		// Create the mesh
		Mesh mesh = new Mesh ();
		Vector3[] vertices = new Vector3[] { new Vector3(1f, 1f, 0f), new Vector3(-1f, 1f, 0f), new Vector3(-1f, -1f, 0f), new Vector3(1f, -1f, 0f)};
		int[] triangles = new int[] { 0, 2, 1, 0, 3, 2 };
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateNormals ();

		// Save the mesh as an asset
		string path = "Assets/Models/" + "mesh" + dateString + ".asset";
		AssetDatabase.CreateAsset (mesh, path);

		// Create the material
		Material material = new Material(Shader.Find("Standard"));
		// Save it as an asset
		path = "Assets/Materials/" + "material" + dateString + ".mat";
		AssetDatabase.CreateAsset (material, path);

		// Create game object
		GameObject gameObject = new GameObject("Quad" + dateString);
		Debug.Log ("Created empty object named " + gameObject.name);

		// Add the mesh filter component to the object,
		// and assign the new mesh
		gameObject.AddComponent<MeshFilter> ().mesh = mesh;
		// Add the mesh renderer component to the object
		// and assign the shader "Standard" so the material is Default-Material
		gameObject.AddComponent<MeshRenderer> ().material = material;

		// Save prefab
		path = "Assets/Prefabs/" + gameObject.name + ".prefab";
		Object prefab = PrefabUtility.CreateEmptyPrefab(path);
		PrefabUtility.ReplacePrefab(gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
		DestroyImmediate (gameObject);
	}
}
