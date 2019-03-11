using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateShower : MonoBehaviour {
    public Material lineMat;
    public GameObject panel;
    public List<Button> Buttons;
    public State state;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        panel.SetActive(true);
        SetBoard(this.name);
    }

    public void SetBoard(string Target)//set the board by state string
    {
        int index = 0;
        foreach (Button Bnt in Buttons)
        {
            Bnt.GetComponentInChildren<Text>().text = Target[index] + "";
            index++;
            //   Debug.Log("set button num=" + (int.Parse(Bnt.name.Replace("Button-", ""))));
            //   Debug.Log("set button text=" + Bnt.GetComponentInChildren<Text>());
        }
        //Debug.Log(index + " buttons text= " + Target);
    }

    
}
