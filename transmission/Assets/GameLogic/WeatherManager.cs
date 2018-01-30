using System.Collections;
using System.Collections.Generic;
using Tenkoku.Core;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
	private Tenkoku.Core.TenkokuModule tenkokuModule;

	 enum WeatherState {
		Neg3,
		Neg2,
		Neg1,
		Neutral,
		Pos1,
		Pos2,
		Pos3,
	};

	[SerializeField]
	private WeatherState weatherState;

	// Use this for initialization
	void Awake () {
		tenkokuModule = GameObject.Find("Tenkoku DynamicSky").gameObject.GetComponent<Tenkoku.Core.TenkokuModule>();;
		weatherState = WeatherState.Neutral;
	}
	
	private float velocity_OvercastAmt  = 0.0F;
	private float velocity_cloudCumulusAmt = 0.0F;
	private float velocity_RainAmt = 0.0F;
	private float velocity_rainbow = 0.0F;
	private float velocity_lightning = 0.0F;

	void Update() 
	{
		changeSceneWeather();
	} 

	public void IncrementWeatherState()
	{
		if (weatherState != WeatherState.Pos3)
		{
			weatherState++;
		}
	}

    public void DecrementWeatherState()
	{
		if (weatherState != WeatherState.Neg3)
		{
			weatherState--;
		}
	}

	void changeSceneWeather()
	{
		if (weatherState == WeatherState.Pos3)
		{
			tenkokuModule.weather_OvercastAmt = Mathf.SmoothDamp(tenkokuModule.weather_OvercastAmt, 0f, ref velocity_OvercastAmt, 5);
			tenkokuModule.weather_cloudAltAmt = Mathf.SmoothDamp(tenkokuModule.weather_cloudAltAmt, .10f, ref velocity_cloudCumulusAmt, 5);
			tenkokuModule.weather_RainAmt = Mathf.SmoothDamp(tenkokuModule.weather_RainAmt, 0f, ref velocity_RainAmt, 5);
			tenkokuModule.weather_rainbow = Mathf.SmoothDamp(tenkokuModule.weather_rainbow, .67f, ref velocity_rainbow, 5);
			tenkokuModule.weather_lightning = Mathf.SmoothDamp(tenkokuModule.weather_lightning, 0f, ref velocity_lightning, 5);
		} else if (weatherState == WeatherState.Pos2)
		{
			tenkokuModule.weather_OvercastAmt = Mathf.SmoothDamp(tenkokuModule.weather_OvercastAmt, .0f, ref velocity_OvercastAmt, 5);
			tenkokuModule.weather_cloudAltAmt = Mathf.SmoothDamp(tenkokuModule.weather_cloudAltAmt, .27f, ref velocity_cloudCumulusAmt, 5);
			tenkokuModule.weather_RainAmt = Mathf.SmoothDamp(tenkokuModule.weather_RainAmt, 0f, ref velocity_RainAmt, 5);
			tenkokuModule.weather_rainbow = Mathf.SmoothDamp(tenkokuModule.weather_rainbow, .20f, ref velocity_rainbow, 5);
			tenkokuModule.weather_lightning = Mathf.SmoothDamp(tenkokuModule.weather_lightning, 0f, ref velocity_lightning, 5);
		} else if (weatherState == WeatherState.Pos1)
		{	
			tenkokuModule.weather_OvercastAmt = Mathf.SmoothDamp(tenkokuModule.weather_OvercastAmt, .07f, ref velocity_OvercastAmt, 5);
			tenkokuModule.weather_cloudAltAmt = Mathf.SmoothDamp(tenkokuModule.weather_cloudAltAmt, .5f, ref velocity_cloudCumulusAmt, 5);
			tenkokuModule.weather_RainAmt = Mathf.SmoothDamp(tenkokuModule.weather_RainAmt, 0f, ref velocity_RainAmt, 5);
			tenkokuModule.weather_rainbow = Mathf.SmoothDamp(tenkokuModule.weather_rainbow, 0f, ref velocity_rainbow, 5);
			tenkokuModule.weather_lightning = Mathf.SmoothDamp(tenkokuModule.weather_lightning, 0f, ref velocity_lightning, 5);
		} else if (weatherState == WeatherState.Neutral)
		{
			tenkokuModule.weather_OvercastAmt = Mathf.SmoothDamp(tenkokuModule.weather_OvercastAmt, .14f, ref velocity_OvercastAmt, 5);
			tenkokuModule.weather_cloudAltAmt = Mathf.SmoothDamp(tenkokuModule.weather_cloudAltAmt, .5f, ref velocity_cloudCumulusAmt, 5);
			tenkokuModule.weather_RainAmt = Mathf.SmoothDamp(tenkokuModule.weather_RainAmt, 0f, ref velocity_RainAmt, 5);
			tenkokuModule.weather_rainbow = Mathf.SmoothDamp(tenkokuModule.weather_rainbow, 0f, ref velocity_rainbow, 5);
			tenkokuModule.weather_lightning = Mathf.SmoothDamp(tenkokuModule.weather_lightning, 0f, ref velocity_lightning, 5);
		}
		else if (weatherState == WeatherState.Neg1)
		{
			tenkokuModule.weather_OvercastAmt = Mathf.SmoothDamp(tenkokuModule.weather_OvercastAmt, .32f, ref velocity_OvercastAmt, 5);
			tenkokuModule.weather_cloudAltAmt = Mathf.SmoothDamp(tenkokuModule.weather_cloudAltAmt, .5f, ref velocity_cloudCumulusAmt, 5);
			tenkokuModule.weather_RainAmt = Mathf.SmoothDamp(tenkokuModule.weather_RainAmt, 0f, ref velocity_RainAmt, 5);
			tenkokuModule.weather_rainbow = Mathf.SmoothDamp(tenkokuModule.weather_rainbow, 0f, ref velocity_rainbow, 5);
			tenkokuModule.weather_lightning = Mathf.SmoothDamp(tenkokuModule.weather_lightning, 0f, ref velocity_lightning, 5);
		} else if (weatherState == WeatherState.Neg2)
		{
			tenkokuModule.weather_OvercastAmt = Mathf.SmoothDamp(tenkokuModule.weather_OvercastAmt, .4f, ref velocity_OvercastAmt, 5);
			tenkokuModule.weather_cloudAltAmt = Mathf.SmoothDamp(tenkokuModule.weather_cloudAltAmt, .5f, ref velocity_cloudCumulusAmt, 5);
			tenkokuModule.weather_RainAmt = Mathf.SmoothDamp(tenkokuModule.weather_RainAmt, .05f, ref velocity_RainAmt, 5);
			tenkokuModule.weather_rainbow = Mathf.SmoothDamp(tenkokuModule.weather_rainbow, 0f, ref velocity_rainbow, 5);
			tenkokuModule.weather_lightning = Mathf.SmoothDamp(tenkokuModule.weather_lightning, .3f, ref velocity_lightning, 5);
		} else if (weatherState == WeatherState.Neg3)
		{
			tenkokuModule.weather_OvercastAmt = Mathf.SmoothDamp(tenkokuModule.weather_OvercastAmt, .67f, ref velocity_OvercastAmt, 5);
			tenkokuModule.weather_cloudAltAmt = Mathf.SmoothDamp(tenkokuModule.weather_cloudAltAmt, .5f, ref velocity_cloudCumulusAmt, 5);
			tenkokuModule.weather_RainAmt = Mathf.SmoothDamp(tenkokuModule.weather_RainAmt, .09f, ref velocity_RainAmt, 5);
			tenkokuModule.weather_rainbow = Mathf.SmoothDamp(tenkokuModule.weather_rainbow, 0f, ref velocity_rainbow, 5);
			tenkokuModule.weather_lightning = Mathf.SmoothDamp(tenkokuModule.weather_lightning, 1f, ref velocity_lightning, 5);
		}
	}
}
