using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1;
    [SerializeField] float shakeMagnitude = 0.5f;


    Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    public void Play()
    {
        Coroutine shake= StartCoroutine(Shake());

    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime<shakeDuration)
        {
            transform.position = initPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
           
        }
        transform.position = initPos;

    }
}