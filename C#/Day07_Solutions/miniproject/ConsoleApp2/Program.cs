using System;

namespace ExaminationSystem
{
    // ==================== ENUMS ====================
    public enum ExamMode
    {
        Starting,
        Queued,
        Finished
    }

    // ==================== DELEGATES AND EVENTS ====================
    public delegate void ExamStartingEventHandler(object sender, ExamEventArgs e);

    public class ExamEventArgs : EventArgs
    {
        public string ExamTitle { get; set; }
        public string SubjectName { get; set; }
        

        public ExamEventArgs(string examTitle, string subjectName)
        {
            ExamTitle = examTitle;
            SubjectName = subjectName;
          
        }
    }

    // ==================== SUBJECT CLASS ====================
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<Student> EnrolledStudents { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            EnrolledStudents = new List<Student>();
        }

        public void EnrollStudent(Student student)
        {
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
            }
        }
    }

    // ==================== STUDENT CLASS ====================
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public Student(int studentId, string studentName)
        {
            StudentId = studentId;
            StudentName = studentName;
        }

        public void ReceiveNotification(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"[NOTIFICATION] Student '{StudentName}' notified: Exam '{e.ExamTitle}' for subject '{e.SubjectName}");
        }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
                return StudentId == other.StudentId;
            return false;
        }

        public override int GetHashCode()
        {
            return StudentId.GetHashCode();
        }
    }

    // ==================== ANSWER CLASSES ====================
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public override string ToString()
        {
            return $"[{AnswerId}] {AnswerText}";
        }
    }

    public class AnswerList : List<Answer>
    {
        public AnswerList() : base() { }

        public override string ToString()
        {
            return string.Join(", ", this.Select(a => a.AnswerText));
        }
    }

    // ==================== QUESTION CLASSES ====================
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }

        protected Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = new AnswerList();
        }

        public abstract void Display();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Question other)
        {
            if (other == null) return 1;
            return this.Marks.CompareTo(other.Marks);
        }

        public override string ToString()
        {
            return $"[{Header}] {Body} (Marks: {Marks})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Question other)
                return Header == other.Header && Body == other.Body && Marks == other.Marks;
            return false;
        }

        public override int GetHashCode()
        {
            return (Header + Body + Marks).GetHashCode();
        }
    }

    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(string header, string body, int marks, bool correctAnswer)
            : base(header, body, marks)
        {
            CorrectAnswer = correctAnswer;
            Answers.Add(new Answer(1, "True"));
            Answers.Add(new Answer(2, "False"));
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Header}");
            Console.WriteLine($"{Body} (Marks: {Marks})");
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }
    }

    public class ChooseOneQuestion : Question
    {
        public int CorrectAnswerId { get; set; }

        public ChooseOneQuestion(string header, string body, int marks, int correctAnswerId)
            : base(header, body, marks)
        {
            CorrectAnswerId = correctAnswerId;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Header}");
            Console.WriteLine($"{Body} (Marks: {Marks})");
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i].AnswerText}");
            }
        }
    }

    public class ChooseAllQuestion : Question
    {
        public List<int> CorrectAnswerIds { get; set; }

        public ChooseAllQuestion(string header, string body, int marks, List<int> correctAnswerIds)
            : base(header, body, marks)
        {
            CorrectAnswerIds = correctAnswerIds;
        }

        public override void Display()
        {
            Console.WriteLine($"\n{Header}");
            Console.WriteLine($"{Body} (Marks: {Marks})");
            Console.WriteLine("(Select all that apply)");
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Answers[i].AnswerText}");
            }
        }
    }

    // ==================== QUESTION LIST CLASS ====================
    public class QuestionList : List<Question>
    {
        private string _logFilePath;

        public QuestionList(string logFilePath) : base()
        {
            _logFilePath = logFilePath;
        }

        public new void Add(Question question)
        {
            // Keep default behavior
            base.Add(question);

            // Log to file
            LogQuestionToFile(question);
        }

        private void LogQuestionToFile(Question question)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine(question.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging question: {ex.Message}");
            }
        }
    }

    // ==================== EXAM BASE CLASS ====================
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int ExamId { get; set; }
        public string ExamTitle { get; set; }
        public int TimeInMinutes { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject Subject { get; set; }
        public QuestionList Questions { get; set; }
        public Dictionary<Question, object> QuestionAnswerDictionary { get; set; }
        public ExamMode Mode { get; set; }

        public event ExamStartingEventHandler ExamStarting;

        protected Exam(int examId, string examTitle, int timeInMinutes, Subject subject)
            : this(examId, examTitle, timeInMinutes, subject, new QuestionList($"ExamLog_{examId}.txt"))
        {
        }

        protected Exam(int examId, string examTitle, int timeInMinutes, Subject subject, QuestionList questions)
        {
            ExamId = examId;
            ExamTitle = examTitle;
            TimeInMinutes = timeInMinutes;
            Subject = subject;
            Questions = questions;
            NumberOfQuestions = questions.Count;
            QuestionAnswerDictionary = new Dictionary<Question, object>();
            Mode = ExamMode.Queued;
        }

        public void StartExam()
        {
            Mode = ExamMode.Starting;
            OnExamStarting(new ExamEventArgs(ExamTitle, Subject.SubjectName));
        }

        protected virtual void OnExamStarting(ExamEventArgs e)
        {
            if (ExamStarting != null)
            {
                ExamStarting(this, e);
            }
        }

        public void SubscribeStudents()
        {
            foreach (var student in Subject.EnrolledStudents)
            {
                ExamStarting += student.ReceiveNotification;
            }
        }

        public abstract void ShowExam();

        public void FinishExam()
        {
            Mode = ExamMode.Finished;
            Console.WriteLine("\n=== EXAM FINISHED ===");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Exam other)
        {
            if (other == null) return 1;
            return this.TimeInMinutes.CompareTo(other.TimeInMinutes);
        }

        public override string ToString()
        {
            return $"Exam: {ExamTitle}, Subject: {Subject.SubjectName}, Time: {TimeInMinutes} mins, Questions: {NumberOfQuestions}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Exam other)
                return ExamId == other.ExamId;
            return false;
        }

        public override int GetHashCode()
        {
            return ExamId.GetHashCode();
        }
    }

    // ==================== PRACTICE EXAM CLASS ====================
    public class PracticeExam : Exam
    {
        public PracticeExam(int examId, string examTitle, int timeInMinutes, Subject subject)
            : base(examId, examTitle, timeInMinutes, subject)
        {
        }

        public PracticeExam(int examId, string examTitle, int timeInMinutes, Subject subject, QuestionList questions)
            : base(examId, examTitle, timeInMinutes, subject, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║           PRACTICE EXAM: {ExamTitle,-30} ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine($"Subject: {Subject.SubjectName}");
            Console.WriteLine($"Time Allowed: {TimeInMinutes} minutes");
            Console.WriteLine($"Total Questions: {NumberOfQuestions}");
            Console.WriteLine(new string('=', 60));

            foreach (var question in Questions)
            {
                question.Display();
                Console.Write("Your Answer: ");
                string userAnswer = Console.ReadLine()!;
                QuestionAnswerDictionary[question] = userAnswer;
            }

            FinishExam();
            ShowCorrectAnswers();
        }

        private void ShowCorrectAnswers()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    CORRECT ANSWERS                     ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            int questionNumber = 1;
            foreach (var question in Questions)
            {
                Console.WriteLine($"\nQuestion {questionNumber}: {question.Header}");

                if (question is TrueFalseQuestion tfq)
                {
                    Console.WriteLine($"Correct Answer: {tfq.CorrectAnswer}");
                }
                else if (question is ChooseOneQuestion coq)
                {
                    Console.WriteLine($"Correct Answer: {coq.Answers[coq.CorrectAnswerId - 1].AnswerText}");
                }
                else if (question is ChooseAllQuestion caq)
                {
                    Console.Write("Correct Answers: ");
                    foreach (var id in caq.CorrectAnswerIds)
                    {
                        Console.Write($"{caq.Answers[id - 1].AnswerText}, ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"Your Answer: {QuestionAnswerDictionary[question]}");
                questionNumber++;
            }
        }
    }

    // ==================== FINAL EXAM CLASS ====================
    public class FinalExam : Exam
    {
        public FinalExam(int examId, string examTitle, int timeInMinutes, Subject subject)
            : base(examId, examTitle, timeInMinutes, subject)
        {
        }

        public FinalExam(int examId, string examTitle, int timeInMinutes, Subject subject, QuestionList questions)
            : base(examId, examTitle, timeInMinutes, subject, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║            FINAL EXAM: {ExamTitle} ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine($"Subject: {Subject.SubjectName}");
            Console.WriteLine($"Time Allowed: {TimeInMinutes} minutes");
            Console.WriteLine($"Total Questions: {NumberOfQuestions}");
            Console.WriteLine(new string('=', 60));

            foreach (var question in Questions)
            {
                question.Display();
                Console.Write("Your Answer: ");
                string userAnswer = Console.ReadLine()!;
                QuestionAnswerDictionary[question] = userAnswer;
            }

            FinishExam();
            Console.WriteLine("\nExam submitted successfully. Results will be announced later.");
        }
    }

    // ==================== MAIN PROGRAM ====================
    class Program
    {
        static void Main(string[] args)
        {
            // Create Subject
            Subject mathSubject = new Subject(1, "Mathematics");

            // Create Students
            Student student1 = new Student(101, "Ahmed Ali");
            Student student2 = new Student(102, "Fatima Hassan");
            Student student3 = new Student(103, "Mohamed Ibrahim");

            // Enroll Students
            mathSubject.EnrollStudent(student1);
            mathSubject.EnrollStudent(student2);
            mathSubject.EnrollStudent(student3);

            // Create Questions for Practice Exam
            QuestionList practiceQuestions = new QuestionList("PracticeExam_Log.txt");

            TrueFalseQuestion q1 = new TrueFalseQuestion(
                "Question 1",
                "Is 2 + 2 equal to 4?",
                5,
                true
            );
            practiceQuestions.Add(q1);

            ChooseOneQuestion q2 = new ChooseOneQuestion(
                "Question 2",
                "What is the square root of 16?",
                10,
                2
            );
            q2.Answers.Add(new Answer(1, "2"));
            q2.Answers.Add(new Answer(2, "4"));
            q2.Answers.Add(new Answer(3, "8"));
            practiceQuestions.Add(q2);

            ChooseAllQuestion q3 = new ChooseAllQuestion(
                "Question 3",
                "Which of the following are prime numbers?",
                15,
                new List<int> { 1, 3 }
            );
            q3.Answers.Add(new Answer(1, "2"));
            q3.Answers.Add(new Answer(2, "4"));
            q3.Answers.Add(new Answer(3, "5"));
            q3.Answers.Add(new Answer(4, "6"));
            practiceQuestions.Add(q3);

            // Create Questions for Final Exam
            QuestionList finalQuestions = new QuestionList("FinalExam_Log.txt");

            TrueFalseQuestion fq1 = new TrueFalseQuestion(
                "Question 1",
                "Is 3 + 5 equal to 8?",
                5,
                true
            );
            finalQuestions.Add(fq1);

            ChooseOneQuestion fq2 = new ChooseOneQuestion(
                "Question 2",
                "What is 10 divided by 2?",
                10,
                2
            );
            fq2.Answers.Add(new Answer(1, "3"));
            fq2.Answers.Add(new Answer(2, "5"));
            fq2.Answers.Add(new Answer(3, "7"));
            finalQuestions.Add(fq2);

            // Create Exams
            PracticeExam practiceExam = new PracticeExam(1, "Math Practice Test", 30, mathSubject, practiceQuestions);
            FinalExam finalExam = new FinalExam(2, "Math Final Exam", 60, mathSubject, finalQuestions);

            // Subscribe students to exam notifications
            practiceExam.SubscribeStudents();
            finalExam.SubscribeStudents();

            // User Selection
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         EXAMINATION SYSTEM - EXAM SELECTION            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\nSelect Exam Type:");
            Console.WriteLine("1. Practice Exam");
            Console.WriteLine("2. Final Exam");
            Console.Write("\nEnter your choice (1 or 2): ");

            string choice = Console.ReadLine()!;

            Exam selectedExam = null;

            switch (choice)
            {
                case "1":
                    selectedExam = practiceExam;
                    break;
                case "2":
                    selectedExam = finalExam;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Practice Exam.");
                    selectedExam = practiceExam;
                    break;
            }

            // Start and Show Exam
            selectedExam.StartExam();
            Console.WriteLine($"\nExam Mode: {selectedExam.Mode}");
            Console.WriteLine("\nPress any key to begin the exam...");
            Console.ReadKey();

            selectedExam.ShowExam();

            // Display exam information using overridden methods
            Console.WriteLine("\n\n=== EXAM INFORMATION ===");
            Console.WriteLine(selectedExam.ToString());
            Console.WriteLine($"Exam Hash Code: {selectedExam.GetHashCode()}");

            // Test ICloneable
            Exam clonedExam = (Exam)selectedExam.Clone();
            Console.WriteLine($"\nCloned Exam: {clonedExam.ToString()}");

            // Test IComparable
            int comparisonResult = practiceExam.CompareTo(finalExam);
            Console.WriteLine($"\nComparison (Practice vs Final): {comparisonResult}");

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}