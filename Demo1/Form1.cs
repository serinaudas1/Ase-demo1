using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo1
{
    public partial class Form1 : Form
    {
        //bitmap to draw on which will be diaplayed in the picturebox
        Bitmap OutputBitmap = new Bitmap(680, 500); // should never use literals like this. it's not very readable and not very flexible
        canvas MyCanvas;


        public Form1()
        {
            InitializeComponent();
            MyCanvas = new canvas(Graphics.FromImage(OutputBitmap));



        }

        private void Commandline_KeyDown(object sender, KeyEventArgs e)
        {
            //implement when key pressed
            if (e.KeyCode == Keys.Enter)
            {

                // Console.WriteLine("Enter Pressed"); // When Enter is pressed, this line writes on console confirming it, used to check for enter key
                String Command = CommandLine.Text.Trim().ToLower();// user input to go in all lowe case so it stays uniform
                String[] split = Command.Split(' ');// assining arrays after splitting user input
                String command = split[0];//Object with array index 0 is the main command
                // variables
                String pencolor;

                String parameters;
                String[] parameter_split;
                int[] param = new int[0];



                //  parameters to enter the array index 1 of split
                if (split.Length > 1)
                {
                    parameters = split[1];
                    parameter_split = parameters.Split(',');
                    param = new int[parameter_split.Length];
                    // used for loop to go through all the parameters 
                    for (int i = 0; i < parameter_split.Length; i++)
                    {
                        bool isInt = int.TryParse(parameter_split[i], out param[i]);


                    }

                }




                // draw a the line when line is typed
                if (command.Equals("line") == true)
                {

                    //check for right parameters
                    if (param.Length == 2)
                    {
                        MyCanvas.DrawLine(param[0], param[1]);
                    }
                    //display error if parameter is wrong
                    else
                    {
                        MessageBox.Show("Incorrect Number of Parameters Entered",
             "Error Message");
                    }

                }
                // draw a the square when square is typed
                else if (command.Equals("square") == true)
                {
                    //check for right parameters
                    if (param.Length == 1)
                    {
                        MyCanvas.DrawSquare(param[0]);
                    }
                    else
                    //display error if parameter is wrong
                    {

                        MessageBox.Show("Incorrect Number of Parameters Entered",
             "Error Message");


                    }
                }
                // draw a the circle 
                else if (command.Equals("circle") == true)
                {
                    //check for right parameters
                    if (param.Length == 1)
                    {

                        MyCanvas.DrawCircle(param[0]);
                    }
                    //display error if parameter is wrong
                    else
                    {
                        MessageBox.Show("Incorrect Number of Parameters Entered",
             "Error Message");
                    }

                }
                // draw a the rectangle 
                else if (command.Equals("rect") == true)
                {
                    //check for right parameters
                    if (param.Length == 2)
                    {
                        MyCanvas.DrawRectangle(param[0], param[1]);
                    }
                    //display error if parameter is wrongS
                    else
                    {
                        MessageBox.Show("Incorrect Number of Parameters Entered",
             "Error Message");
                    }

                }
                // draw a the triangle 
                else if (command.Equals("tri") == true)
                {
                    //check for right parameters
                    if (param.Length == 3)
                    {

                        MyCanvas.DrawTriangle(param[0], param[1], param[2]);
                    }
                    else
                    //display error if parameter is wrong
                    {
                        MessageBox.Show("Incorrect Number of Parameters Entered",
            "Error Message");
                    }


                }



                else if (command.Equals("reset") == true)
                {

                    MyCanvas.Reset(0, 0);
                }
                else if (command.Equals("clear") == true)
                {
                    MyCanvas.Clear();

                }
                else if (command.Equals("moveto") == true)
                {

                    MyCanvas.MoveTo(param[0], param[1]);
                }
                else if (command.Equals("drawto") == true)
                {

                    // Console.WriteLine("LINE");
                    if (param.Length == 2)
                    {
                        MyCanvas.DrawLine(param[0], param[1]);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Number of Parameters Entered",
            "Error Message");
                    }

                }





                // Changing pen color to red
                else if (command.Equals("red") == true)
                {

                    pencolor = "red";
                    MyCanvas.PenColor(pencolor);

                }


                // Change pen color to green
                else if (command.Equals("green") == true)
                {

                    pencolor = "green";
                    MyCanvas.PenColor(pencolor);

                }
                // Change pen color to yellow
                else if (command.Equals("yellow") == true)
                {

                    pencolor = "yellow";
                    MyCanvas.PenColor(pencolor);

                }
                // Changing pen color to black
                else if (command.Equals("black") == true)
                {

                    pencolor = "black";
                    MyCanvas.PenColor(pencolor);

                }



                else if (command.Equals("run") == true)
                {
                    for (int i = 0; i < ProgramWindow.Lines.Length; i++)
                    {
                        String programm = ProgramWindow.Lines[i].Trim().ToLower();
                        String[] PWsplit = programm.Split(' ');

                        String Programcommand = PWsplit[0];
                        String Programparameters;
                        String[] Progarmparameter_split;
                        int[] ProgramInt = new int[0];


                        if (PWsplit.Length > 1)
                        {
                            Programparameters = PWsplit[1];
                            Progarmparameter_split = Programparameters.Split(',');
                            ProgramInt = new int[Progarmparameter_split.Length];

                            for (int a = 0; a < Progarmparameter_split.Length; a++)
                            {
                                bool isInt = int.TryParse(Progarmparameter_split[a], out ProgramInt[a]);

                                {


                                    // draw a the line
                                    if (Programcommand.Equals("drawto") == true)
                                    {
                                        if (ProgramInt.Length == 2)
                                        {
                                            MyCanvas.DrawLine(ProgramInt[0], ProgramInt[1]);
                                        }
                                        //Error message
                                        else
                                        {
                                            MessageBox.Show("Incorrect Number of Parameters Entered for drawto command", "Error Message");
                                        }
                                    }
                                    else if (Programcommand.Equals("line") == true)
                                    {
                                        if (ProgramInt.Length == 2)
                                        {
                                            MyCanvas.DrawLine(ProgramInt[0], ProgramInt[1]);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Incorrect Number of Parameters Entered for line command", "Error Message");
                                        }
                                    }
                                    //draw a the square
                                    else if (Programcommand.Equals("square") == true)
                                    {
                                        if (ProgramInt.Length == 1)
                                        {
                                            MyCanvas.DrawSquare(ProgramInt[0]);
                                        }
                                        //Error message
                                        else
                                        {
                                            MessageBox.Show("Incorrect Number of Parameters Entered for square command", "Error Message");
                                        }

                                    }
                                    //draw a the circle
                                    else if (Programcommand.Equals("circle") == true)
                                    {
                                        if (ProgramInt.Length == 1)
                                        {
                                            MyCanvas.DrawCircle(ProgramInt[0]);
                                        }
                                        //Error message
                                        else
                                        {
                                            MessageBox.Show("Incorrect Number of Parameters Entered for circle command", "Error Message");
                                        }

                                    }
                                    //draw a the rectangle
                                    else if (Programcommand.Equals("rect") == true)
                                    {
                                        if (ProgramInt.Length == 2)
                                        {
                                            MyCanvas.DrawRectangle(ProgramInt[0], ProgramInt[1]);
                                        }
                                        //Error message
                                        else
                                        {
                                            MessageBox.Show("Incorrect Number of Parameters Entered for rectangle command", "Error Message");
                                        }

                                    }
                                    //draw a the triangle
                                    else if (Programcommand.Equals("tri") == true)
                                    {
                                        if (ProgramInt.Length == 3)
                                        {
                                            MyCanvas.DrawTriangle(ProgramInt[0], ProgramInt[1], ProgramInt[2]);
                                        }
                                        //Error message
                                        else
                                        {
                                            MessageBox.Show("Incorrect Number of Parameters Entered for triangle command", "Error Message");
                                        }
                                    }
                                    else if (Programcommand.Equals("reset") == true)
                                    {

                                        MyCanvas.Reset(0, 0);
                                    }
                                    else if (Programcommand.Equals("clear") == true)
                                    {
                                        MyCanvas.Clear();

                                    }
                                    else if (Programcommand.Equals("moveto") == true)
                                    {
                                        MyCanvas.MoveTo(ProgramInt[0], ProgramInt[1]);
                                    }
                                    // Change pen color to red
                                    else if (Programcommand.Equals("red") == true)
                                    {

                                        pencolor = "red";
                                        MyCanvas.PenColor(pencolor);

                                    }
                                    // Change pen color to purple
                                    else if (Programcommand.Equals("Purple") == true)
                                    {

                                        pencolor = "Purple";
                                        MyCanvas.PenColor(pencolor);

                                    }
                                    // Change pen color to yellow
                                    else if (Programcommand.Equals("yellow") == true)
                                    {

                                        pencolor = "yellow";
                                        MyCanvas.PenColor(pencolor);

                                    }
                                    // pen color black
                                    else if (Programcommand.Equals("black") == true)
                                    {

                                        pencolor = "black";
                                        MyCanvas.PenColor(pencolor);

                                    }



                                    else
                                    {
                                        MessageBox.Show("Wrong Command", "Error Message");
                                    }


                                }
                                Refresh();
                            }

                        }
                    }
                }













                else
                {
                    MessageBox.Show("Wrong Command", "Error Message");
                }



                Refresh();

            }
        }





        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // get graphics context of form being displayed
            g.DrawImageUnscaled(OutputBitmap, 0, 0); // puts the bitmap on the screen
        }

        private void Fill_CheckedChanged(object sender, EventArgs e)
        {
            // MyCanvas.Fill = Fill.Checked;
        }

        private void ProgramWindow_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Stream st;
            OpenFileDialog d1 = new OpenFileDialog();
            if (d1.ShowDialog() == DialogResult.OK)
            {
                if ((st = d1.OpenFile()) != null)
                {
                    {
                        string file = d1.FileName;
                        String str = File.ReadAllText(file);
                        ProgramWindow.Text = str;

                    }
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter tw = new StreamWriter(@"C:\Users\Shreeya Dhakal\Documents\C# file.txt");
            tw.Write(ProgramWindow.Text);
            label1.Text = "File Save Successfully";
            Random r = new Random();
            label1.ForeColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
            tw.Close();

        }

        private void ProgramWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Error_TextChanged(object sender, EventArgs e)
        {

        }

        private void Error_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}