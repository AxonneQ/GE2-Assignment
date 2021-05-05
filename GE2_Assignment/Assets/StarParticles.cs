using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParticles : MonoBehaviour
{
    private ParticleSystem.Particle[] points;
    private float pointDistSqr;
    private float pointClipDistSqr;

    public Color pointColor;
    public int maxPoints = 600;
    public float pointSize = .35f;
    public float pointDistance = 60f;
    public float pointClipDistance = 15f;
    // Start is called before the first frame update
    void Start()
    {
        pointDistSqr = pointDistance * pointDistance;
        pointClipDistSqr = pointClipDistance * pointClipDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(points == null) {
            CreatePoints();
        }

        for(int i = 0; i < maxPoints; i++) {
            if((points[i].position - transform.position).sqrMagnitude > pointDistSqr) {
                points[i].position = Random.insideUnitSphere.normalized * pointDistance + transform.position;
            }

            if((points[i].position - transform.position).sqrMagnitude <= pointClipDistSqr) {
                float percent = (points[i].position - transform.position).sqrMagnitude / pointClipDistSqr;
                points[i].startColor = new Color(1,1,1, percent);
                points[i].startSize = percent * pointSize;
            }
        }
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }

    private void CreatePoints() {
        points = new ParticleSystem.Particle[maxPoints];
        for(int i = 0; i < maxPoints; i++) {
            points[i].position = Random.insideUnitSphere * pointDistance + transform.position;
            points[i].startColor = pointColor;
            points[i].startSize = pointSize;
        }
    }
}
