using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;


namespace Diagrams
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           miNewDiagram_Click(null, null);
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        int i = 0;
        private void miNewDiagram_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                string message = "Бажаєте зберегти схему?";
                string caption = "Зберегти";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    miSave_Click(sender, e);
                }
            }
            ++i;
            dbDiagram.Diagram = new Diagram();
           dbDiagram.Diagram = dbDiagram.Diagram;
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (sfdDiagram.ShowDialog() == DialogResult.OK)
                dbDiagram.Diagram.Save(sfdDiagram.FileName);
        }

        private void miLoad_Click(object sender, EventArgs e)
        {
            if (ofdDiagram.ShowDialog() == DialogResult.OK)
                dbDiagram.Diagram = Diagram.Load(ofdDiagram.FileName);
        }

        private void dbDiagram_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dbDiagram.SelectedBeginEditText();
        }

        Point startDragPoint;

        private void miAddRect_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RectFigure>(startDragPoint);
        }

        private void addRoundRectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RoundRectFigure>(startDragPoint);
        }

        private void addRhombToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RhombFigure>(startDragPoint);
        }

        private void addParalelogrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<ParalelogrammFigure>(startDragPoint);
        }

    

        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedBringToFront();
        }

        private void miAddLedgeLine_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedAddLedgeLine();
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedDelete();
        }

        private void editTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedBeginEditText();
        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedSendToBack();
        }

        private void dbDiagram_MouseUp(object sender, MouseEventArgs e)
        {
            startDragPoint = e.Location;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dbDiagram.SelectedFigure == null)
                    cmMain.Show(dbDiagram.PointToScreen(e.Location));
                else
                    cmSelectedFigure.Show(dbDiagram.PointToScreen(e.Location));
            }  
        }

        private void dbDiagram_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                dbDiagram.SelectedDelete();
        }

        private void addCycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<CycleFigure>(startDragPoint);
        }

        private void addCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<CircleFigure>(startDragPoint);
        }

        private void addProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<ProcessFigure>(startDragPoint);
        }

        private void addRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RectFigure>(startDragPoint);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RoundRectFigure>(startDragPoint);
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RhombFigure>(startDragPoint);
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<ParalelogrammFigure>(startDragPoint);
        }

      

        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<CycleFigure>(startDragPoint);
        }

        private void addToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<CircleFigure>(startDragPoint);
        }

        private void addToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<ProcessFigure>(startDragPoint);
        }

        private void editTextToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dbDiagram.SelectedBeginEditText();
        }

        private void addEdgeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedAddLedgeLine();
        }

        private void deleteBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedDelete();
        }

        private void bringToFrontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedBringToFront();
        }

        private void sendToBackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedSendToBack();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
                    dbDiagram.GetImage().Save(sfdImage.FileName);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Бажаєте зберегти схему?";
            string caption = "Зберегти";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                miSave_Click(sender, e);
            }
        }
        
        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str1 = "Програма FlowChart Editor Допомога";
            MessageBox.Show(dbDiagram.Help(), str1);
        }


        private void commentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<CommentFigure>(startDragPoint);
        }

        private void commentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<CommentFigure>(startDragPoint);
        }

        private void incToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.Inc();
        }

        private void decToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.Dec();            
        }

        private void incToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbDiagram.Inc();
        }

        private void decToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbDiagram.Dec();  
        }
    }
}
