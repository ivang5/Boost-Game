using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector = new Vector3(7f, 0f, 0f);
    [SerializeField] float period = 3f;

    float movementFactor;  //0 for not moved, 1 for fully moved.

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // protect against period is zero
        if (period > Mathf.Epsilon)
        {
            float cycles = Time.time / period; // grows continually from 0

            const float tau = Mathf.PI * 2f; // about 6.28
            float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

            movementFactor = rawSinWave;

            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPos + offset;
        }
        
    }
}
