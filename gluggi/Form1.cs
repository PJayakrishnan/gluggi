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
        private float m_answer;
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


        //
        private void CreateAnswerAndQuestion()
        {
            
            int quesParts = 2; //RandomNumBw2and4();

            string question = string.Empty;

            if (quesParts == 2)
            {
                question = QuestionWithTwoParts();
            }
            else if (quesParts == 3)
            {
                question = QuestionWithThreeParts();
            }
            else if (quesParts == 4)
            {
                question = QuestionWithFourParts();
            }

            this.lblQuestion.Text = question;

            DataTable calc = new DataTable();

            m_answer = (float)Convert.ToDouble(calc.Compute(question, string.Empty));

            CreateOptions(m_answer);
        }

        private string QuestionWithTwoParts()
        {
            string quesString;

            quesString = RandomNumBelow(1000).ToString() + RandomBinaryOperator() + RandomNumBelow(1000);
            
            return quesString;
        }

        private string QuestionWithThreeParts()
        {


            return "";
        }

        private string QuestionWithFourParts()
        {
            return "";
        }

        private string RandomBinaryOperator()
        {
            int rand = RandomNumBelow(4);
            string oprtr = string.Empty;

            switch (rand)
            {
                case 1:
                    oprtr = "+";
                    break;
                case 2:
                    oprtr = "-"; 
                    break;
                case 3:
                    oprtr = "*"; 
                    break;
                case 4:
                    oprtr = "/"; 
                    break;
                default:
                    break;
            }
            return oprtr;
        }

        private int RandomNumBelow(int num)
        {
            Random randum = new Random();
            int rand_num = randum.Next(1, num + 1);
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

        private void CreateOptions(float answer)
        {
            int random = RandomNumBelow(4);
            float[] optionarray = new float[4];
            optionarray[0] = answer - 10.0f;
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
