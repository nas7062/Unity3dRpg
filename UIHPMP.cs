using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIHPMP : MonoBehaviour
{
	[SerializeField]

	private Entry entry;
	[SerializeField]
	private Slider sliderHP;
	[SerializeField]
	private TextMeshProUGUI textHP;
	[SerializeField]
	private Slider sliderMP;
	[SerializeField]
	private TextMeshProUGUI textMP;

	private void Update()
	{
		if (sliderHP != null)
			sliderHP.value = Utils.Percent(entry.HP, entry.MaxHp);
		if (textHP != null)
			textHP.text = $"{entry.HP:F0} /{entry.MaxMp:F0}";
		if (sliderMP != null)
			sliderMP.value = Utils.Percent(entry.MP, entry.MaxHp);
		if (textMP != null)
			textMP.text = $"{entry.MP:F0} /{entry.MaxMp:F0}";

	}


}
