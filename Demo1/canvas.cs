using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
namespace Demo1
{
    class canvas
    {
        // instance data for pen and x,y pos and graphics context
        //graphics context is the drawing area to draw on (see Session 3)
        Graphics g;
        Pen Pen;
        Brush brush;
        int xPos, yPos; //pen position when drawing
        public bool Fill = false;


        /// <summary>
        /// Constructor initialises canvas to white pen at 0,0
        /// </summary>
        /// ‹param name= "g" > Graphics context of place to draw on‹/param>
        public canvas(Graphics g)
        {
            this.g = g;
            xPos = yPos = 0;
            Pen = new Pen(Color.Black, 2); //standard pen (should use constants)
            brush = new SolidBrush(Color.Black);
        }


        // Method to Change pen color to Red, Green, Blue or Black
        public void PenColor(String pencolor)
        {
            if (pencolor == "red")
            {
                Pen.Color = Color.Red;
            }
            else if (pencolor == "green")
            {
                Pen.Color = Color.Green;
            }
            else if (pencolor == "yellow")
            {
                Pen.Color = Color.Yellow;
            }
            else if (pencolor == "black")
            {
                Pen.Color = Color.Black;
            }
        }




        public void Reset(int toX, int toY)
        {
            xPos = 0;
            yPos = 0;
            Pen = new Pen(Color.Black, 1); // reinitializing pen position to 0,0
        }

        public void Clear()
        {
            g.Clear(Color.Transparent);
        }
        /// <summary>
        /// draw a line from current pen pos(×Pos, yPos)
        /// </summary>
        ///<param name = "toX"> x position to draw to</param>
        ///<param name = "toY"> y position to draw to</param>

        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(Pen, xPos, yPos, toX, toY); //draw the line
            xPos = toX;
            yPos = toY;
        }
        public void DrawSquare(int width)
        {
            g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + width);
            if (Fill)
                g.FillRectangle(brush, xPos, yPos, xPos + width, yPos + width);
        }

        public void DrawCircle(int radius)
        {
            g.DrawEllipse(Pen, xPos, yPos, xPos + (radius * 2), yPos + (radius * 2));
            if (Fill)
                g.FillEllipse(brush, xPos, yPos, xPos + (radius * 2), yPos + (radius * 2));
        }

        public void DrawRectangle(int length, int width)
        {
            g.DrawRectangle(Pen, xPos, yPos, xPos + length, yPos + width);
            if (Fill)
                g.FillRectangle(brush, xPos, yPos, xPos + length, yPos + width);

        }

        // Method to draw a triangle by specifying end point of the first two lines and making last line go back to origin point
        public void DrawTriangle(int v1, int v2, int v3 )
        {

            Point a = new Point(v1, v2);
            Point b = new Point(v2, v3);

            double y = (Math.Pow(v1, 2) + Math.Pow(v3, 2) - Math.Pow(v2, 2)) / (2 * v1);
            double x = Math.Sqrt(Math.Pow(v3, 2) - Math.Pow(y, 2));

            Point c = new Point((int)x, (int)y);
            g.DrawLine(Pen, a, b);
            g.DrawLine(Pen, b, c);
            g.DrawLine(Pen, c, a);

            if (Fill)
            {
                //g.FillPolygon(brush, PointF[] points)
            }

        }


        public void MoveTo(int toX, int toY)
        {
            xPos = toX;
            yPos = toY;
        }

       
    }
}
