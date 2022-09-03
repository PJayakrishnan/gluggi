using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gluggi
{
    public partial class Form1 : Form
    {
        int m_timerCount = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateAnswerAndQuestion()
        {
            int answer = RandomNumBw1and1000();

            int quesParts = RandomNumBw2and4();

            string question = string.Empty;

            if (quesParts == 2)
            {
                question = QuestionWithTwoParts(answer);
            }
            else if (quesParts == 3)
            {
                question = QuestionWithThreeParts(answer);
            }
            else if (quesParts == 4)
            {
                question = QuestionWithFourParts(answer);
            }

            this.lblQuestion.Text = question;
        }

        private string QuestionWithTwoParts(int answer)
        {
            return "";
        }

        private string QuestionWithThreeParts(int answer)
        {
            return "";
        }

        private string QuestionWithFourParts(int answer)
        {
            return "";
        }

        private int RandomNumBw2and4()
        {
            Random randum = new Random();
            int rand_num = randum.Next(2, 4);
            return rand_num;
        }

        private int RandomNumBw1and1000()
        {
            Random randum = new Random();
            int rand_num = randum.Next(1, 1000);
            return rand_num;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = false;
            timer =new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();

            //CreateAnswerAndQuestion
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            m_timerCount--;
            this.lblTimer.Text = m_timerCount.ToString();
            if (m_timerCount == 0)
            {
                timer.Stop();
                m_timerCount = 20;
                this.btnStart.Enabled = true;
            }
        }
    }
}
