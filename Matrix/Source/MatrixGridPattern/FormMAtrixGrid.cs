using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixGridPattern
{
    public partial class FormMAtrixGrid : Form
    {
        //Memeber Variables
        public int m_width;
        public int m_height;

        public int m_NoOfRows;
        public int m_NoOfCol;

        public int m_XOffSet;
        public int m_YOffSet;
        public int limit = 8;

        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 100;
        public const int DEFAULT_NO_ROW = 2;
        public const int DEFAULT_NO_COL = 2 ;
        public const int DEFAULT_WIDTH = 60;
        public const int DEFAULT_HEIGHT = 60;
        int iCounter = 2;
        
        public FormMAtrixGrid()
        {
            Intialize();
            InitializeComponent();
            bThreadStatus=false;

    }

        private void OnPaint(object sender, EventArgs e)
        {
            OnDraw();
        }
        public void Intialize()
        {
            m_width = DEFAULT_WIDTH;
            m_height = DEFAULT_HEIGHT;
            m_NoOfCol = DEFAULT_NO_COL;
            m_NoOfRows = DEFAULT_NO_ROW;
            m_XOffSet = DEFAULT_X_OFFSET;
            m_YOffSet = DEFAULT_Y_OFFSET;
        }
        private void OnDraw()
        {
            Graphics boardLayout = this.CreateGraphics();
            Pen layoutPen = new Pen(Color.OrangeRed);
            layoutPen.Width = 3;
            //boardLayout.DrawLine(layoutPen,0,0,100,0);
            int X = DEFAULT_X_OFFSET;
            int Y = DEFAULT_Y_OFFSET;

            //Draw the Rows

            for (int i = 0; i <= iCounter; i++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X + this.m_width * this.iCounter, Y);
                Y = Y +this. m_height;
            }

            X = DEFAULT_X_OFFSET;
            Y = DEFAULT_Y_OFFSET;


            //Draw the Coloums

            for (int j = 0; j <= iCounter; j++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_height * this.iCounter);
                X = X +this. m_width;
            }
        }
        public void ThreadCounter()
        {

            try
            {
                while (true)
                {
                    iCounter++;

                    if (iCounter > limit)
                    {
                        iCounter = 1; 
                    }
                    Invalidate();
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
            }
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {

            counterThread = new Thread(new ThreadStart(ThreadCounter));
            counterThread.Start();
            bThreadStatus = true;
            Invalidate();
        }
    
       
        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            counterThread.Resume();
        }
      
        private void toolStripButtonResume_Click(object sender, EventArgs e)
        {
            counterThread.Suspend();
        }
       

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            limit = 3;
            this.Refresh();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            limit = 4;
            this.Refresh();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            limit = 5;
            this.Refresh();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            limit = 6;
            this.Refresh();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            limit = 7;
            this.Refresh();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            limit = 8;
            this.Refresh();
        }
    }
   
}
