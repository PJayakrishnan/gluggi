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
        private int m_timerCount;
        private int m_answer;
        private int m_score;
        public Form1()
        {
            InitializeComponent();
            m_timerCount = 20;
            m_score = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //The idea is to initaially decide the answer and make a
        //question string from it randomly. Then check whether the
        //input is equal to the answer or not.
        private void CreateAnswerAndQuestion()
        {
            m_answer = RandomNumBw1and1000();

            int quesParts = 2; //RandomNumBw2and4();

            string question = string.Empty;

            if (quesParts == 2)
            {
                question = QuestionWithTwoParts(m_answer);
            }
            else if (quesParts == 3)
            {
                question = QuestionWithThreeParts(m_answer);
            }
            else if (quesParts == 4)
            {
                question = QuestionWithFourParts(m_answer);
            }

            this.lblQuestion.Text = question;
            CreateOptions(m_answer);
        }

        private string QuestionWithTwoParts(int answer)
        {
            int rand = RandomNumBw1and2();
            int number = RandomNumBelow(answer);
            string quesString;

            switch (rand)
            {
                case 1:
                    quesString  = (answer - number).ToString() + " + " + (answer - (answer - number)).ToString();
                    break;
                default:
                    quesString = (answer + number).ToString() + " - " + ((answer + number)- answer).ToString();
                    break;
            }
            

            return quesString;
        }

        private string QuestionWithThreeParts(int answer)
        {


            return "";
        }

        private string QuestionWithFourParts(int answer)
        {
            return "";
        }

        private int RandomNumBw1and2()
        {
            Random randum = new Random();
            int rand_num = randum.Next(1, 3);
            return rand_num;
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

        private int RandomNumBelow(int num)
        {
            Random randum = new Random();
            int rand_num = randum.Next(1, num - 2);
            return rand_num;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartQuiz();
        }

        private void StartQuiz()
        {
            this.btnStart.Enabled = false;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();

            CreateAnswerAndQuestion();
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

        private void LblOption1_Click(object sender, EventArgs e)
        {
            if (lblOption1.Text == m_answer.ToString() && m_timerCount != 0)
            {
                m_score++;
                lblScore.Text = m_score.ToString();
            }
            timer.Stop();
            m_timerCount = 20;
            StartQuiz();
        }

        private void LblOption2_Click(object sender, EventArgs e)
        {
            if (lblOption2.Text == m_answer.ToString() && m_timerCount != 0)
            {
                m_score++;
                lblScore.Text = m_score.ToString();
            }
            timer.Stop();
            m_timerCount = 20;
            StartQuiz();
        }

        private void LblOption3_Click(object sender, EventArgs e)
        {
            if (lblOption3.Text == m_answer.ToString() && m_timerCount != 0)
            {
                m_score++;
                lblScore.Text = m_score.ToString();
            }
            timer.Stop();
            m_timerCount = 20;
            StartQuiz();
        }

        private void LblOption4_Click(object sender, EventArgs e)
        {
            if (lblOption4.Text == m_answer.ToString() && m_timerCount != 0)
            {
                m_score++;
                lblScore.Text = m_score.ToString();
            }
            timer.Stop();
            m_timerCount = 20;
            StartQuiz();
        }

        private void CreateOptions(int answer)
        {
            int random = RandomNumBw2and4();
            int[] optionarray = new int[4];
            optionarray[0] = answer - 10;
            optionarray[1] = answer - random; 
            optionarray[2] = answer + random; 
            optionarray[3] = answer; 

             Random r = new Random();

            optionarray = optionarray.OrderBy(x => r.Next()).ToArray();


            lblOption1.Text = optionarray[0].ToString();
            lblOption2.Text = optionarray[1].ToString();
            lblOption3.Text = optionarray[2].ToString();
            lblOption4.Text = optionarray[3].ToString();
        }
    }
}
