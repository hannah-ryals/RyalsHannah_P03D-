using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GoalText : MonoBehaviour
{

	[Space(10)]
	[Header("Toggle for the gui on off")]
	public bool GuiOn;


	[Space(10)]
	[Header("Text")]
	public string Text = "Turn Back";

	public Rect BoxSize = new Rect(0, 0, 200, 100);



	// if this script is on an object with a collider display the Gui
	void OnTriggerEnter()
	{
		GuiOn = true;
	}


	void OnTriggerExit()
	{
		GuiOn = false;
	}

	void OnGUI()
	{

		if (GuiOn == true)
		{
			// Make a group on the center of the screen
			GUI.BeginGroup(new Rect((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height) / 2, BoxSize.width, BoxSize.height));
			// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

			GUI.Label(BoxSize, Text);

			// End the group we started above. This is very important to remember!
			GUI.EndGroup();

		}


	}

}

