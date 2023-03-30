using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class DrawMesh : MonoBehaviour
{
    [SerializeField] private Transform debugVisual1;
    [SerializeField] private Transform debugVisual2;
    public GameObject parent;

    private Mesh mesh;
    private List<GameObject> meshList = new List<GameObject>();
    private Vector3 lastMousePosition;
    private bool isDrawing;
    [SerializeField] private Material material;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (UIWorldDetect.draw == false)
                return;

            mesh = new Mesh();
            isDrawing = true;
            GameObject temp = new GameObject();
            temp.AddComponent<MeshFilter>().mesh = mesh;
            temp.AddComponent<MeshRenderer>().material = material; 
            temp.transform.parent = parent.transform;
            // Mouse Pressed
           // if (mesh)
                meshList.Add(temp.gameObject);

            Vector3[] vertices = new Vector3[4];
            Vector2[] uv = new Vector2[4];
            int[] triangles = new int[6];

            vertices[0] = UtilsClass.GetMouseWorldPosition();
            vertices[1] = UtilsClass.GetMouseWorldPosition();
            vertices[2] = UtilsClass.GetMouseWorldPosition();
            vertices[3] = UtilsClass.GetMouseWorldPosition();

            uv[0] = Vector2.zero;
            uv[1] = Vector2.zero;
            uv[2] = Vector2.zero;
            uv[3] = Vector2.zero;

            triangles[0] = 0;
            triangles[1] = 3;
            triangles[2] = 1;

            triangles[3] = 1;
            triangles[4] = 3;
            triangles[5] = 2;

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.MarkDynamic();

            lastMousePosition = UtilsClass.GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0) && isDrawing)
        {
            if (UIWorldDetect.draw == false)
                return;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform.tag != "Drawable")
                    return;
            }

            // Mouse held down
            float minDistance = 0.1f;
            if (Vector3.Distance(UtilsClass.GetMouseWorldPosition(), lastMousePosition) > minDistance)
            {
                Vector3[] vertices = new Vector3[mesh.vertices.Length + 2];
                Vector2[] uv = new Vector2[mesh.uv.Length + 2];
                int[] triangles = new int[mesh.triangles.Length + 6];

                mesh.vertices.CopyTo(vertices, 0);
                mesh.uv.CopyTo(uv, 0);
                mesh.triangles.CopyTo(triangles, 0);

                int vIndex = vertices.Length - 4;
                int vIndex0 = vIndex + 0;
                int vIndex1 = vIndex + 1;
                int vIndex2 = vIndex + 2;
                int vIndex3 = vIndex + 3;

                Vector3 mouseForwardVector = (UtilsClass.GetMouseWorldPosition() - lastMousePosition).normalized;
                Vector3 normal2D = new Vector3(0, 0, -1f);
                float lineThickness = 0.03f;
                Vector3 newVertexUp = UtilsClass.GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal2D) * lineThickness;
                Vector3 newVertexDown = UtilsClass.GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal2D * -1f) * lineThickness;

                vertices[vIndex2] = newVertexUp;
                vertices[vIndex3] = newVertexDown;

                uv[vIndex2] = Vector2.zero;
                uv[vIndex3] = Vector2.zero;

                int tIndex = triangles.Length - 6;

                triangles[tIndex + 0] = vIndex0;
                triangles[tIndex + 1] = vIndex2;
                triangles[tIndex + 2] = vIndex1;

                triangles[tIndex + 3] = vIndex1;
                triangles[tIndex + 4] = vIndex2;
                triangles[tIndex + 5] = vIndex3;

                mesh.vertices = vertices;
                mesh.uv = uv;
                mesh.triangles = triangles;

                lastMousePosition = UtilsClass.GetMouseWorldPosition();
            }    
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }
    }

    public void ClearNotes()
    {
        foreach (GameObject meshItem in meshList)
        Destroy(meshItem);
    }

}