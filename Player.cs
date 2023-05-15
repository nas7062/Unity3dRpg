using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
	public List<GameObject> pickupItems = new List<GameObject>();

	public int Gold;
	public TextMeshProUGUI GoldAmount;

	void Update()
	{
		GoldAmount.text = Gold + " Won";
	}
	
}
