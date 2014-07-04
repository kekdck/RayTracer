using SharpDX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTraycer
{
    class Scene
    {
        private Int32 imageWidth = 800;
        private Int32 imageHeight = 600;
        //private Triangle triangle = new Triangle(new Vector3(0.0f, 1.0f, 0.0f),
        //    new Vector3(1.0f, 0.0f, 0.0f), new Vector3(-1.0f, 0.0f, 0.0f));
        private List<IObject3D> objects = new List<IObject3D>();
        private System.Drawing.Color m_backgroundColor = System.Drawing.Color.Black;

        public Scene()
        {
            Sphere sphere = new Sphere(new Vector3(1.0f, 1.0f, 0.0f),
                1, System.Drawing.Color.Red);
            objects.Add(sphere);
            sphere = new Sphere(new Vector3(-1.0f, -1.0f, 0.0f),
                1, System.Drawing.Color.Blue);
            objects.Add(sphere);
            sphere = new Sphere(new Vector3(0.0f, 0.0f, 0.0f),
                1, System.Drawing.Color.Green);
            objects.Add(sphere);
        }

        public Int32 Width
        {
            get { return imageWidth; }
        }

        public Int32 Height
        {
            get { return imageHeight; }
        }

        public Bitmap renderToImage()
        {
            Bitmap image = new Bitmap(imageWidth, imageHeight);

            Vector3 source = new Vector3(0.0f, 0.0f, -2.0f);
            Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);
            Vector3 forward = target - source;
            forward.Normalize();
            Vector3 right = Vector3.Cross(up, forward);
            right.Normalize();

            for (int i = 1; i < imageHeight - 1; ++i)
            {
                float beta = (imageHeight / 2 - (float)i) / (imageHeight / 2);
                for (int j = 1; j < imageWidth - 1; ++j)
                {
                    float alpha = (imageWidth / 2 - (float)j) / (imageWidth / 2);

                    Vector3 ray = forward - (alpha * right + beta * up);
                    ray.Normalize();

                    float minDist = float.PositiveInfinity;
                    System.Drawing.Color color = m_backgroundColor;
                    foreach (IObject3D object3D in objects)
                    {
                        System.Drawing.Color tempColor;
                        float dist;

                        if (object3D.intersect(source, ray, out dist, out tempColor) &&
                            dist < minDist)
                        {
                            minDist = dist;
                            color = tempColor;
                        }
                    }

                    image.SetPixel(j, imageHeight - i, color);



                }
            }
            return image;
        }


    }


}
