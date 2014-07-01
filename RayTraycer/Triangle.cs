using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace RayTraycer
{

    class Triangle
    {
        private Vector3[] points = new Vector3[3];

        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
        }

        bool intersect(Vector3 source, Vector3 target, out float t)
        {
            Vector3 normal = Vector3.Cross(points[0] - points[1],
                points[0] - points[2]);
            normal.Normalize();

            t = - Vector3.Dot((source - points[0]), normal) / 
                Vector3.Dot(target, normal);

            Vector3 p = source + target * t;
            Vector3 u = points[1] - points[0];
            Vector3 v = points[3] - points[0];
            Vector3 w = p - points[0];
            Vector3 vCrossW = Vector3.Cross(v, w);
            Vector3 vCrossU = Vector3.Cross(v, u);
            if (Vector3.Dot(vCrossW, vCrossU) < 0)
                return false;
            Vector3 uCrossW = Vector3.Cross(u, w);
            Vector3 uCrossV = Vector3.Cross(u, v);
            // Test sign of t
            if (Vector3.Dot(uCrossW, uCrossV) < 0)
                return false;
 
            // At this point, we know that r and t and both > 0.
            // Therefore, as long as their sum is <= 1, each must be less <= 1
            float denom = uCrossV.Length();
            float r = vCrossW.Length() / denom;
            float k = uCrossW.Length() / denom;

            return (r + k <= 1);
        }
    }
}
