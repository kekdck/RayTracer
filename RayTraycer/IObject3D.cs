using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTraycer
{
    interface IObject3D
    {
        bool intersect(Vector3 source, Vector3 ray, out float distance, out System.Drawing.Color color);
    }
}
