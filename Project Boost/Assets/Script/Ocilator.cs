using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocilator : MonoBehaviour
{
    Vector3 Opos;
    Vector3 Fpos;
    [SerializeField] Vector3 Muvment;
    [SerializeField] [Range(0 , 1)] float Factor;

    [SerializeField] float period = 2f;

    void Start()
    {
        Opos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period == 0) {return;}
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        Vector3 offset = Muvment * Factor;
        transform.position = Opos + offset;

        Factor = (rawSinWave + 1) /2;
    }
}
