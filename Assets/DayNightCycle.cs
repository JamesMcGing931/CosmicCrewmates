using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{

    [Header("Time")]
    [Tooltip("Day Length in Minutes")]
    [SerializeField]
    private float _targetDayLength = 0.5f; //length of day in minutes
    public float targetDayLength
    {
        get
        {
            return _targetDayLength;
        }
    }
    [SerializeField]
    private float elapsedTime;
    /*    [SerializeField]
        private bool use24Clock = true;
        [SerializeField]
        private Text clockText;*/
    [SerializeField]
    [Range(0f, 1f)]
    private float _timeOfDay;
    public float timeOfDay
    {
        get
        {
            return _timeOfDay;
        }
    }

    private float _timeScale = 100f;

    public bool pause = false;
    [SerializeField]
    private AnimationCurve timeCurve;
    private float timeCurveNormalization;

    [Header("Sun Light")]
    [SerializeField]
    private Transform dailyRotation;
    [SerializeField]
    private Light sun;
    private float intensity;
    [SerializeField]
    private float sunBaseIntensity = 1f;
    [SerializeField]
    private float sunVariation = 1.5f;
    [SerializeField]
    private Gradient sunColor;

    private Transform sunSeasonalRotation;
    [SerializeField]
    [Range(-45f, 45f)]
    private float maxSeasonalTilt;
    private void Start()
    {
        NormalTimeCurve();
    }

    private void Update()
    {
        if (!pause)
        {
            UpdateTimeScale();
            UpdateTime();
            //  UpdateClock();
        }

        AdjustSunRotation();
        SunIntensity();
        AdjustSunColor();

    }

    private void UpdateTimeScale()
    {
        _timeScale = 24 / (_targetDayLength / 60);
        _timeScale *= timeCurve.Evaluate(elapsedTime / (targetDayLength * 60)); //changes timescale based on time curve
        _timeScale /= timeCurveNormalization; //keeps day length at target value
    }

    private void NormalTimeCurve()
    {
        float stepSize = 0.01f;
        int numberSteps = Mathf.FloorToInt(1f / stepSize);
        float curveTotal = 0;

        for (int i = 0; i < numberSteps; i++)
        {
            curveTotal += timeCurve.Evaluate(i * stepSize);
        }

        timeCurveNormalization = curveTotal / numberSteps; //keeps day length at target value
    }

    private void UpdateTime()
    {
        _timeOfDay += Time.deltaTime * _timeScale / 86400; // seconds in a day
        elapsedTime += Time.deltaTime;
    }

    /*private void UpdateClock()
    {
        float time = elapsedTime / (targetDayLength * 60);
        float hour = Mathf.FloorToInt(time * 24);
        float minute = Mathf.FloorToInt(((time * 24) - hour) * 60);

        string hourString;
        string minuteString;

        if (!use24Clock && hour > 12)
            hour -= 12;

        if (hour < 10)
            hourString = "0" + hour.ToString();
        else
            hourString = hour.ToString();

        if (minute < 10)
            minuteString = "0" + minute.ToString();
        else
            minuteString = minute.ToString();

        if (use24Clock)
            clockText.text = hourString + " : " + minuteString;
        else if (time > 0.5f)
            clockText.text = hourString + " : " + minuteString + " pm";
        else
            clockText.text = hourString + " : " + minuteString + " am";


    }*/

    //rotates the sun daily (and seasonally soon too);
    private void AdjustSunRotation()
    {
        float sunAngle = timeOfDay * 360f;
        dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));
    }

    private void SunIntensity()
    {
        intensity = Vector3.Dot(sun.transform.forward, Vector3.down);
        intensity = Mathf.Clamp01(intensity);

        sun.intensity = intensity * sunVariation + sunBaseIntensity;
    }

    private void AdjustSunColor()
    {
        sun.color = sunColor.Evaluate(intensity);
    }

}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class DayNightCycle : MonoBehaviour {
    
//     [Header("Time")]
//     [Tooltip("Day Length in Minutes")]
//     [SerializeField]
//     private float _targetDayLength = 0.5f; //length of day in minutes
//     public float targetDayLength
//     {
//         get
//         {
//             return _targetDayLength;
//         }
//     }
//     [SerializeField]
//     private float elapsedTime;
//     [SerializeField]
//     private bool use24Clock = true;
//     [SerializeField]
//     private Text clockText;
//     [SerializeField]
//     [Range(0f, 1f)]
//     private float _timeOfDay;
//     public float timeOfDay
//     {
//         get
//         {
//             return _timeOfDay;
//         }
//     }
//     [SerializeField]
//     private int _dayNumber = 0; //tracks the days passed
//     public int dayNumber
//     {
//         get
//         {
//             return _dayNumber;
//         }
//     }

//     private float _timeScale = 100f;
//     [SerializeField]

//     public bool pause = false;
//     [SerializeField]
//     private AnimationCurve timeCurve;
//     private float timeCurveNormalization;

//     [Header("Sun Light")]
//     [SerializeField]
//     private Transform dailyRotation;
//     [SerializeField]
//     private Light sun;
//     private float intensity;
//     [SerializeField]
//     private float sunBaseIntensity = 1f;
//     [SerializeField]
//     private float sunVariation = 1.5f;
//     [SerializeField]
//     private Gradient sunColor;


//     private void Update()
//     {
//         if (!pause)
//         {
//             UpdateTimeScale();
//             UpdateTime();
//         }

//         AdjustSunRotation();
//         SunIntensity();
//         AdjustSunColor();

//     }

//     private void UpdateTimeScale()
//     {
//         _timeScale = 24 / (_targetDayLength / 60);
//         _timeScale *= timeCurve.Evaluate(elapsedTime / (targetDayLength * 60)); //changes timescale based on time curve
//         _timeScale /= timeCurveNormalization; //keeps day length at target value
//     }

//     private void NormalTimeCurve()
//     {
//         float stepSize = 0.01f;
//         int numberSteps = Mathf.FloorToInt(1f / stepSize);
//         float curveTotal = 0;

//         for (int i = 0; i < numberSteps; i++)
//         {
//             curveTotal += timeCurve.Evaluate(i * stepSize);
//         }

//         timeCurveNormalization = curveTotal / numberSteps; //keeps day length at target value
//     }

//     private void UpdateTime()
//     {
//         _timeOfDay += Time.deltaTime * _timeScale / 86400; // seconds in a day
//         elapsedTime += Time.deltaTime;
//     }

//     //rotates the sun daily (and seasonally soon too);
//     private void AdjustSunRotation()
//     {
//         float sunAngle = timeOfDay * 360f;
//         dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));  
//     }

//     private void SunIntensity()
//     {
//         intensity = Vector3.Dot(sun.transform.forward, Vector3.down);
//         intensity = Mathf.Clamp01(intensity);

//         sun.intensity = intensity * sunVariation + sunBaseIntensity;
//     }

//     private void AdjustSunColor()
//     {
//         sun.color = sunColor.Evaluate(intensity);
//     }
// }
