using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletPattern
{
    Linear,
    Sine,
    Boomerang,
    Noise
}

public interface BulletPatternStruct
{

    Quaternion getRotation(float time);

}

public struct Sine : BulletPatternStruct
{

    float freq;
    float magnitude;

    public Sine(float _freq, float _mag)
    {
        freq = _freq;
        magnitude = _mag;
    }
    //this pattern returns a rotation that oscillates between magnitudes over time
    public Quaternion getRotation(float time)
    {
        return Quaternion.AngleAxis(Mathf.Cos(time * (Mathf.PI*2) * freq) * magnitude, Vector3.forward);
    }
}
public struct Boomerang : BulletPatternStruct
{

    
    public Quaternion getRotation(float time)
    {
        return Quaternion.AngleAxis(
            Mathf.Pow(
                Mathf.Cos(time*(Mathf.PI*2)),
                2)
            *(360-90)+45, Vector3.forward);
    }
}

public struct Noise : BulletPatternStruct
{
    float influence;

    public Noise(float _influence)
    {
        influence = _influence;
    }

    public Quaternion getRotation(float time)
    {
        return Quaternion.AngleAxis(Random.Range(-180,180)*influence, Vector3.forward);
    }
}

public class Bullet : MonoBehaviour
{
    public float speed;

    public BulletPattern pattern = BulletPattern.Linear;
    public BulletPatternStruct patternStruct;
    Quaternion firedRotation;

    public float lifeTime;
    float timer;
    private void OnEnable()
    {
        switch (pattern)
        {
            case BulletPattern.Sine:
                patternStruct = new Sine(5,30);
                break;
            case BulletPattern.Boomerang:
                patternStruct = new Boomerang();
                break;
            case BulletPattern.Noise:
                patternStruct = new Noise(0.3f);
                break;
            default:
                break;
        }
        //when the bullet is enabled reset the timer
        timer = lifeTime;
        firedRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (patternStruct != null) transform.rotation = firedRotation * patternStruct.getRotation(1f-(timer/lifeTime));

        //move bullet in local up direction
        transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);

        //check if bullet expired
        if (timer <= 0)
        {
            gameObject.SetActive(false);
            return;
        }
        timer -= Time.fixedDeltaTime;


    }

}
