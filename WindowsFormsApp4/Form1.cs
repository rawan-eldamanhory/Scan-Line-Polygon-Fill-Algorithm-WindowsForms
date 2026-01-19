using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Scan-Line Polygon Fill Algorithm

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point[] points = new Point[] {
            new Point(50, 50),
            new Point(200, 100),
            new Point(150, 200),
            new Point(100, 150)
            };

            e.Graphics.DrawPolygon(Pens.Black, points);

            ScanLineFill(points, Color.Blue, e.Graphics);
        }

        private void ScanLineFill(Point[] points, Color fillColor, Graphics g)
        {
            int minY = int.MaxValue, maxY = int.MinValue;
            foreach (Point p in points)
            {
                if (p.Y < minY) minY = p.Y;
                if (p.Y > maxY) maxY = p.Y;
            }

            for (int y = minY; y <= maxY; y++)
            {
                List<int> intersections = new List<int>();

                for (int i = 0; i < points.Length; i++)
                {
                    Point p1 = points[i];
                    Point p2 = points[(i + 1) % points.Length];

                    // Check if the edge intersects the scan line
                    if ((p1.Y <= y && p2.Y > y) || (p1.Y > y && p2.Y <= y))
                    {
                        double x = ((double)(y - p1.Y) / (p2.Y - p1.Y)) * (p2.X - p1.X) + p1.X;
                        intersections.Add((int)x);
                    }
                }

                intersections.Sort();

                // Fill the pixels between each pair of intersection points
                for (int i = 0; i < intersections.Count - 1; i += 2)
                {
                    int x1 = intersections[i];
                    int x2 = intersections[i + 1];

                    // Draw a horizontal line between the intersection points
                    g.DrawLine(new Pen(fillColor), x1, y, x2, y);
                }
            }
        }
    }
}
