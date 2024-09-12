using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatUI : MonoBehaviour
{
	public GameObject playerStatUI;

	void Update()
	{
		// Check to see if we should open/close the inventory
		if (Input.GetButtonDown("PlayerStat"))
		{
			playerStatUI.SetActive(!playerStatUI.activeSelf);
			Inventory.instance.DestroyItemInfo();
		}
	}
}
