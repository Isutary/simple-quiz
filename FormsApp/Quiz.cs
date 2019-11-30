using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace FormsApp
{
    class Quiz
    {
        private Form MainForm;
        private List<Question> AllQuestions;
        private Label QuestionArea;
        private int score = 0;
        private int CurrentStep = 0;
        private int QuizLength = 0;
        private Button ButtonA;
        private Button ButtonB;
        private Button ButtonC;
        private Button ButtonD;
        private Button PlayAgain;
        private Timer timer = new Timer() { Interval = 1500 };
        public Quiz(List<Question> AllQuestions, int QuizLength)
        {
            MainForm = CreateForm();
            this.QuizLength = (QuizLength >= AllQuestions.Count) ? AllQuestions.Count : QuizLength;
            this.AllQuestions = Shuffle(AllQuestions);
            timer.Tick += new EventHandler(Next);
        }
        public void Start()
        {
            Next(null, null);
            MainForm.ShowDialog();
        }
        private void Next(object sender, EventArgs e)
        {
            timer.Stop();
            if (CurrentStep < QuizLength)
            {
                ButtonA.BackColor = default(Color);
                ButtonB.BackColor = default(Color);
                ButtonC.BackColor = default(Color);
                ButtonD.BackColor = default(Color);
                QuestionArea.Text = AllQuestions[CurrentStep].QuestionText;
                ButtonA.Text = AllQuestions[CurrentStep].Answers[0];
                ButtonB.Text = AllQuestions[CurrentStep].Answers[1];
                ButtonC.Text = AllQuestions[CurrentStep].Answers[2];
                ButtonD.Text = AllQuestions[CurrentStep].Answers[3];
            }
            else
            {
                QuestionArea.Text = $"Your score is { score } out of { QuizLength }";
                PlayAgain.Visible = true;
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            timer.Start();
            if (CurrentStep >= AllQuestions.Count) return;
            Button clickedButton = (Button)sender;
            int CurrentAnswer = AllQuestions[CurrentStep].CorrectAnswer;
            CurrentStep++;
            switch (CurrentAnswer)
            {
                case 0:
                    ButtonA.BackColor = Color.Green;
                    break;
                case 1:
                    ButtonB.BackColor = Color.Green;
                    break;
                case 2:
                    ButtonC.BackColor = Color.Green;
                    break;
                case 3:
                    ButtonD.BackColor = Color.Green;
                    break;
                default:
                    break;
            }
            switch (clickedButton.Name) {
                case "A":
                    if (CurrentAnswer == 0) score++;
                    else
                    {
                        ButtonA.BackColor = Color.Red;
                    }
                    break;
                case "B":
                    if (CurrentAnswer == 1) score++;
                    else
                    {
                        ButtonB.BackColor = Color.Red;
                    }
                    break;
                case "C":
                    if (CurrentAnswer == 2) score++;
                    else
                    {
                        ButtonC.BackColor = Color.Red;
                    }
                    break;
                case "D":
                    if (CurrentAnswer == 3) score++;
                    else
                    {
                        ButtonD.BackColor = Color.Red;
                    }
                    break;
                default:
                    break;
            }
        }
        private void PlayAgain_Click(object sender, EventArgs e)
        {
            score = 0;
            CurrentStep = 0;
            AllQuestions = Shuffle(AllQuestions);
            PlayAgain.Visible = false;
            Next(null, null);
        }
        private Form CreateForm()
        {
            Form newForm = new Form() {
                Text = "Quiz",
                Size = new Size(500, 500),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };
            QuestionArea = CreateLable();
            PlayAgain = CreateButton("Play Again", 140, 155);
            PlayAgain.Click += PlayAgain_Click;
            PlayAgain.Visible = false;
            newForm.Controls.Add(PlayAgain);
            newForm.Controls.Add(QuestionArea);
            ButtonA = CreateButton("A", 30, 270);
            ButtonA.Click += Button_Click;
            newForm.Controls.Add(ButtonA);
            ButtonB = CreateButton("B", 255, 270);
            ButtonB.Click += Button_Click;
            newForm.Controls.Add(ButtonB);
            ButtonC = CreateButton("C", 30, 360);
            ButtonC.Click += Button_Click;
            newForm.Controls.Add(ButtonC);
            ButtonD = CreateButton("D", 255, 360);
            ButtonD.Click += Button_Click;
            newForm.Controls.Add(ButtonD);
            return newForm;
        }
        private Button CreateButton(string name, int x, int y)
        {
            return new Button()
            {
                Name = name,
                Text = name,
                Location = new Point(x, y),
                Size = new Size(205, 80)
            };
        }
        private Label CreateLable()
        {
            return new Label()
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.None,
                Font = new Font("Arial", 16),
                Text = "Question area",
                Size = new Size(430, 210),
                Location = new Point(30, 30),
                BorderStyle = BorderStyle.FixedSingle
            };
        }
        private List<Question> Shuffle(List<Question> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Question value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}
