using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateQuad : MonoBehaviour {
	void Start () {
		// Create the mesh
		Mesh mesh = new Mesh ();
		Vector3[] vertices = new Vector3[] { new Vector3(1f, 1f, 0f), new Vector3(-1f, 1f, 0f), new Vector3(-1f, -1f, 0f), new Vector3(1f, -1f, 0f)};
		int[] triangles = new int[] { 0, 2, 1, 0, 3, 2 };
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateNormals ();
		// Add the mesh filter component to the object,
		// and assign the new mesh
		gameObject.AddComponent<MeshFilter> ().mesh = mesh;
		// Add the mesh renderer component to the object
		// and assign the shader "Standard" so the material is Default-Material
		gameObject.AddComponent<MeshRenderer> ().material = new Material(Shader.Find("Standard"));
	}
}
