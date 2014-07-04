using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace RayTraycer
{

    class Triangle : IObject3D
    {
        private Vector3[] points = new Vector3[3];
        private System.Drawing.Color m_color = System.Drawing.Color.Blue;

        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
        }

        public bool intersect(Vector3 source, Vector3 ray, out float distance,
            out System.Drawing.Color color)
        {
            Vector3 e1 = points[1] - points[0];
            Vector3 e2 = points[2] - points[0];
            Vector3 e1CrossE2 = Vector3.Cross(e2, e1);

            Vector3 normal = e1CrossE2;
            normal.Normalize();

            distance = -Vector3.Dot((source - points[0]), normal) /
                Vector3.Dot(ray, normal);

            if (distance < 0)
            {
                color = m_color;
                return false;
            }

            Vector3 p = source + ray * distance;

            Vector3 d1 = p - points[0];

            Vector3 p1 = Vector3.Cross(ray, e2);
            Vector3 q1 = Vector3.Cross(d1, e1);

            float tr = Vector3.Dot(p1, e1);

            float u = Vector3.Dot(p1, d1) / tr;
            float v = Vector3.Dot(p1, ray) / tr;

            //float tr1 = Vector3.Dot(Vector3.Cross(d1, e1), normal);
            //float tr2 = Vector3.Dot(Vector3.Cross(e2, d1), normal);
            //float b1 = tr1 / tr;
            //float b2 = tr2 / tr;

            color = m_color;

            return (u + v) <= 1;
        }
    }
}
