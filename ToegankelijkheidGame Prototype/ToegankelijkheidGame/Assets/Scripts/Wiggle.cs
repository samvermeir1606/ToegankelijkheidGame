using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
	public float BotsWiggleSpeed;
	public float BotsWiggleStrength;
	private void Update()
	{
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Sin(Time.timeSinceLevelLoad * BotsWiggleStrength) * BotsWiggleSpeed);
        //localTime += Time.deltaTime;
        //Position.y = Mathf.Sin(localTime * HoverSpeed + Offset) * HoverHeight + StartHeight;
        //transform.position = Position;
        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, Mathf.Sin(Time.timeSinceLevelLoad * BotsWiggleStrength) * BotsWiggleSpeed,0.0f);

	}
}
