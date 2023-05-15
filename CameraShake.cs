using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	private static CameraShake instance;
	public static CameraShake Instance => instance;
	private float ShakeTime;
	private float ShakeIntensitiy;

	public CameraShake()
	{
		instance = this;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			OnShakeCamera(0.1f, 1.0f);
		}

	}

	public void OnShakeCamera(float shaketime, float shakeintensity)
	{
		ShakeTime = shaketime;
		ShakeIntensitiy = shakeintensity;

		StopCoroutine(ShakeByPosition());
		StartCoroutine(ShakeByPosition());
	}

	IEnumerator ShakeByPosition()
	{
		Vector3 startposition = transform.position;

		while (ShakeTime > 0.0f)
		{
			transform.position = startposition + Random.insideUnitSphere * ShakeIntensitiy;
			ShakeTime -= Time.deltaTime;

			yield return null;
		}

		transform.position = startposition;
	}
}
