using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    float dayNightMinutes = 180;
    bool sunGoingUp = true;
    [SerializeField] float dayNightSpeed = 0.1f;
    [SerializeField] float dayTime = 60f;
    [SerializeField] float nightTime = 60f;

    private void Start()
    {
        StartCoroutine("SunUp");
    }

    IEnumerator SunUp()
    {
        while (dayNightMinutes > -360)
        {
            spriteRenderer.color = new Color(0, 0, 0, (dayNightMinutes + 360)/900);
            dayNightMinutes -= 1;
            yield return new WaitForSeconds(dayNightSpeed);
        }
        StartCoroutine("Day");
        yield return null;
    }

    IEnumerator SunDown()
    {
        while (dayNightMinutes < 360)
        {
            spriteRenderer.color = new Color(0, 0, 0, (dayNightMinutes + 360)/900);
            dayNightMinutes += 1;
            yield return new WaitForSeconds(dayNightSpeed);
        }
        StartCoroutine("Night");
        yield return null;
    }
    IEnumerator Day()
    {
        spriteRenderer.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(dayTime);
        StartCoroutine("SunDown");
    }
    IEnumerator Night()
    {
        spriteRenderer.color = new Color(0, 0, 0, 0.8f);
        yield return new WaitForSeconds(nightTime);
        StartCoroutine("SunUp");
    }

}
