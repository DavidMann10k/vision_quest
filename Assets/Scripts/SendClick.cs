using UnityEngine;
using System.Collections;

public class SendClick : MonoBehaviour {
	
	public GameObject[] targets;
	public string[] targets_messages;
	public string[] Messages;
	public string secondary_message = "OnAltClick";
	//public bool onClick;
	
	void Update() {
		if(Input.GetMouseButtonDown(0))
		{
			//if (onClick)
			//	SendMessageToObject("OnClick");
			
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width /2, Screen.height /2, 0));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				foreach(string m in Messages)
				{
					SendMessageToObject(hit.collider.gameObject, m);
				}
			}
			
			foreach(GameObject t in targets)
			{
				foreach(string m in targets_messages)
				{
					t.SendMessage(m);
				}
			}
		}
    }

	void SendMessageToObject(GameObject target, string message)
	{
		target.SendMessage(message, SendMessageOptions.DontRequireReceiver);
	}
	
	void send_highlight()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			hit.collider.gameObject.SendMessage("OnHighlight", SendMessageOptions.DontRequireReceiver);
		}
	}

//	void PlaceDetonation ()
//	{
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast(ray, out hit))
//		{
//			Instantiate(detonationPrefab, hit.point, Quaternion.identity);
//		}
//	}
}
