using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTraycer
{
    class Sphere : IObject3D
    {
        private readonly Vector3 m_center;
        private readonly float m_radius;
        private readonly System.Drawing.Color m_color;

        public Sphere(Vector3 center, float radius, System.Drawing.Color color)
        {
            m_center = center;
            m_radius = radius;
            m_color = color;
        }

        public bool intersect(Vector3 source, Vector3 ray,
            out float distance, out System.Drawing.Color color)
        {
            Vector3 s = m_center - source;
            float rayDotS = Vector3.Dot(ray, s);

            float discr = 4.0f * (float)(Math.Pow(rayDotS, 2) - Math.Pow(ray.Length(), 2)
                * (Math.Pow(s.Length(), 2) - Math.Pow(m_radius, 2)));

            if (discr >= 0)
            {
                float t1 = (float)(rayDotS + Math.Sqrt(discr)
                    / (2.0f * Math.Pow(ray.Length(), 2)));
                float t2 = (float)(rayDotS - Math.Sqrt(discr)
                    / (2.0f * Math.Pow(ray.Length(), 2)));

                if (t2 > 0)
                {
                    distance = t2;
                }
                else
                {
                    distance = t1;
                }
            }
            else
            {
                distance = 0;
            }

            color = m_color;


            return (discr >= 0);
        }


    }


}
