using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowLines : MonoBehaviour {

    public Material mat;
    public Vector3 startVertex;
    public Vector3 end;

    public GameObject A;
    public GameObject B;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrawGizmos()
    {
        
    }

    public void OnPostRender()
    {
        startVertex = B.transform.position;
        end = A.transform.position;
        DrawLines();
    }


    private void DrawLines()
    {
        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }
        //GL.PushMatrix();
        
        //GL.LoadOrtho();

        GL.Begin(GL.LINES);
        mat.SetPass(0);
        GL.Color(Color.red);
        GL.Vertex(startVertex);
        GL.Vertex(end);
        GL.End();

        //GL.PopMatrix();

    }
}
