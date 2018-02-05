using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmoControl : MonoBehaviour {

    public static Action<Atmosphere> ChangeAtmo;

    public enum Atmosphere { Daylight, Overcast, Night };

    Atmosphere[] atmos = new Atmosphere[] { Atmosphere.Daylight, Atmosphere.Overcast, Atmosphere.Night };
    int atmoIndex = 0;

    public Atmosphere atmo;
    public List<Material> skies;

    // Use this for initialization
    void Start () {
        ChangeAtmo += ChangeAtmosphere;

        atmo = atmos[atmoIndex];
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (atmoIndex < atmos.Length-1)
                atmoIndex++;
            else
                atmoIndex = 0;

            ChangeAtmo(atmos[atmoIndex]);
        }
	}

    void ChangeAtmosphere(Atmosphere toAtmo)
    {
        atmo = toAtmo;
        UpdateSkybox(toAtmo);
    }

    void UpdateSkybox(Atmosphere toAtmo)
    {
        switch (toAtmo)
        {
            case Atmosphere.Daylight:
                RenderSettings.skybox = skies[0];
                break;
            case Atmosphere.Overcast:
                RenderSettings.skybox = skies[1];
                break;
            case Atmosphere.Night:
                RenderSettings.skybox = skies[2];
                break;
        }
    }
}
