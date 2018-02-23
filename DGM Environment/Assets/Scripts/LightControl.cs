using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {

    public float[] intensities;
    public Color[] colors;

    Light lightSource;

	// Use this for initialization
	void Start () {
        AtmoControl.ChangeAtmo += UpdateLight;

        lightSource = GetComponent<Light>();
    }

    void UpdateLight(AtmoControl.Atmosphere toAtmo)
    {
        switch (toAtmo)
        {
            case AtmoControl.Atmosphere.Daylight:
                lightSource.intensity = intensities[0];
                lightSource.color = colors[0];
                break;
            case AtmoControl.Atmosphere.Overcast:
                lightSource.intensity = intensities[0];
                lightSource.color = colors[0];
                break;
            case AtmoControl.Atmosphere.Night:
                lightSource.intensity = intensities[0];
                lightSource.color = colors[0];
                break;
        }
    }
}
