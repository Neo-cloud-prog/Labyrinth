using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrinth
{
    public partial class Form1 : Form
    {
        static string[,] LabyrinthArray =
{
    { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
    { "#", "* ", "* ", "* ", "* ", "* ", "* ", "#", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "A", "#" },
    { "#", "* ", "* ", "* ", "* ", "* ", "* ", "#", "* ", "#", "#", "#", "#", "#", "#", "#", "* ", "#" },
    { "#", "* ", "#", "#", "#", "#", "* ", "* ", "* ", "#", "#", "#", "#", "#", "#", "#", "* ", "#" },
    { "#", "* ", "* ", "* ", "* ", "* ", "#", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "#" },
    { "#", "#", "#", "#", "#", "* ", "#", "* ", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
    { "#", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "#" },
    { "#", "* ", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "* ", "#" },
    { "#", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "#" },
    { "#", "#", "#", "#", "#", "#", "* ", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
    { "#", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "#" },
    { "#", "* ", "#", "#", "#", "#", "* ", "* ", "* ", "#", "#", "#", "#", "#", "#", "#", "* ", "#" },
    {"#", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "#"},
    {"#", "* ", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
    {"#", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "#"},
    { "#", "* ", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
    { "#", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "#" },
    { "#", "* ", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
    { "#", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "W", " ", "#" },
    { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" }
};
        static string LabyrinthString = "";

        static int Row = LabyrinthArray.GetLength(1) - 2;

        static int Col = 1;

        static string NextElement = "";

        void LoadLabyrinth()
        {
            LabyrinthString = string.Join(Environment.NewLine, Enumerable.Range(0, LabyrinthArray.GetLength(0)).Select(i => string.Join("      ", Enumerable.Range(0, LabyrinthArray.GetLength(1)).Select(j => LabyrinthArray[i, j]))));
            lbLabyrinth.Text = LabyrinthString;
        }

        void Move(int X, int Y)
        {
            NextElement = LabyrinthArray[Y, X];
            if (NextElement == "#")
            {
                return;
            }
            LabyrinthArray[Col, Row] = "* ";
            LabyrinthArray[Y, X] = "A";
            LoadLabyrinth();
            Row = X;
            Col = Y;
            if (NextElement == "W")
            {
                Victory();
            }
        }

        void Victory()
        {
            MessageBox.Show("Congratulations you have completed the task", "Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLabyrinth();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            Move(Row - 1, Col);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            Move(Row + 1, Col);
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            Move(Row, Col - 1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Move(Row, Col + 1);
        }
    }
}
