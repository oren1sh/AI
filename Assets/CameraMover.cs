using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    public VariableJoystick joystickRot;
    public VariableJoystick joystickMov;
    public bool Generate = false;

    public BrainCreator creator;
    public Material lineMat;

    public GameHeader GameHeader;

    private Rigidbody camera;
    Quaternion rot;
    public int playerSpeed;
    private Vector3 inputRotation;
    private Vector3 mousePlacement;
    private Vector3 screenCentre;

    // Use this for initialization
    void Start () {

        camera = GetComponent<Rigidbody>();
        lineMat = creator.lineMat;

       

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed); //move forward
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * playerSpeed); //move backwards
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * playerSpeed); //move left
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * playerSpeed); //move right
        }
        
        if (Input.GetKey("c"))
        {
            Look();
        }
        
        //FindCrap();
        //transform.rotation = Quaternion.LookRotation(inputRotation);

       
    }

    void FindCrap()
    {
        screenCentre = new Vector3(Screen.width * 0.5f, 0, Screen.height * 0.5f);
        mousePlacement = Input.mousePosition;
        mousePlacement.z = mousePlacement.y;
        mousePlacement.y = 0;
        inputRotation = mousePlacement - screenCentre;
    }

    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    public void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        //transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        //transform.localRotation = Quaternion.Euler(0, rotation.y * lookSpeed, 0);
        transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, rotation.y * lookSpeed, 0);
    }

    public void OnPress()
    {
        if (Generate)
        {
            Generate = false;
        }
        else
        {
            Generate = true;
        }

    }

    void OnPostRender()
    {
        RenderLine();

        if (Generate)
        {
            creator.PlaceState();
            
            Generate = false;
        }

        for (int i = 0; i < (GameHeader.BoradSize * GameHeader.BoradSize); i++)
        {

        }
    }
    //// To show the lines in the editor
    //void OnDrawGizmos()
    //{
    //    Debug.Log("OnDrawGizmos");
    //    //RenderLine();
    //    if(Generate)
    //    {
    //        creator.PlaceState();
    //        RenderLine();
    //        Generate = false;
    //    }

    //}


    void RenderLine()
    {
        List<GameObject> nodes = this.GetComponent<BrainCreator>().nodes;
        

        foreach (GameObject item in nodes)
        {
            foreach (Edge E in item.GetComponent<StateShower>().state.Edges)
            {
                GameObject Target = nodes.Find(x => x.name == E.Sto);
                if (Target)
                {
                    GL.Begin(GL.LINES);
                    lineMat.SetPass(0);
                    if(item.GetComponent<StateShower>().state.Layer % 2 == 0)
                    {
                        GL.Color(Color.blue);
                    }
                    else
                    {
                        GL.Color(Color.red);
                    }
                   
                    GL.Vertex(item.transform.position);
                    GL.Vertex(Target.transform.position);
                    GL.End();
                }
                
            }
            

        }       
       
        

        //GL.PopMatrix();

    }
}
