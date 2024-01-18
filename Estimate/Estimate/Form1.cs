using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Estimate
{
    public partial class Form1 : Form
    {
        internal static List<Student> students;
        public static bool booln = false;
        public string path = @"students.xml";
        public Form1()
        {
            InitializeComponent();
            students = File.Exists("students.xml") ? DeserializeFromXML(@"students.xml") : new List<Student>();
            addStudents();
            updateList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void addStudents()
        {
            if (booln == false)
            {
                students.Add(new Student("Марков", "Максим", "Глебович", 2, 2, 2));
                students.Add(new Student("Крылова", "Ева", "Андреевна", 2, 2, 2));
                students.Add(new Student("Лосев", "Дмитрий", "Артемович", 2, 2, 2));
                students.Add(new Student("Старикова", "Милана", "Марковна", 2, 2, 2));
                students.Add(new Student("Зимин", "Александр", "Лукич", 2, 2, 2));
                students.Add(new Student("Ефимов", "Давид", "Александрович", 2, 2, 2));
                students.Add(new Student("Давыдов", "Вадим", "Андреевич", 2, 2, 2));
                students.Add(new Student("Коротков", "Всеволод", "Сергеевич", 2, 2, 2));
                students.Add(new Student("Демьянов", "Николай", "Иванович", 2, 2, 2));
                students.Add(new Student("Филиппов", "Алексей", "Матвеевич", 2, 2, 2));
                students.Add(new Student("Логинов", "Егор", "Маркович", 2, 2, 2));
                students.Add(new Student("Горлова", "Милана", "Михайловна", 2, 2, 2));
                students.Add(new Student("Савельева", "Екатерина", "Кирилловна", 2, 2, 2));
                students.Add(new Student("Сорокин", "Дмитрий", "Максимович", 2, 2, 2));
                students.Add(new Student("Галкина", "София", "Артемовна", 2, 2, 2));
            }
            
        }

        private void updateList()
        {
            studentslist.Items.Clear();
            for (int i = 0; i < students.Count; i++)
            {
                studentslist.Items.Add(String.Join(" ", students[i].Surname, students[i].Name, students[i].Patronymic));
            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = studentslist.SelectedIndex;
            if (index != -1)
            {
                Form2 inputDialog = new Form2(students[index].Grade_math, students[index].Grade_biology, students[index].Grade_practice);
                if (inputDialog.ShowDialog(this) == DialogResult.OK)
                {
                    students[index].Grade_math = Convert.ToInt32(inputDialog.mathGrade_num.Value);
                    students[index].Grade_biology = Convert.ToInt32(inputDialog.bioGrade_num.Value);
                    students[index].Grade_practice = Convert.ToInt32(inputDialog.practiceGrade_num.Value);
                    studentslist_SelectedIndexChanged(sender, e);
                }
                inputDialog.Close();
            }
            else
            {
                MessageBox.Show("Сначала выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void studentslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = studentslist.SelectedIndex;
            if (index == -1)
            {
                math.Text = "";
                biology.Text = "";
                practice.Text = "";
            } else
            {
                math.Text = students[index].Grade_math.ToString();
                setGrade(math, math.Text);
                biology.Text = students[index].Grade_biology.ToString();
                setGrade(biology, biology.Text);
                practice.Text = students[index].Grade_practice.ToString();
                setGrade(practice, practice.Text);
            }
            
        }

        private void setGrade(Label subjectLb, string grade)
        {
            subjectLb.Text = grade;
            switch (grade)
            {
                case "2":
                    subjectLb.BackColor = Color.Red; break;
                case "3":
                    subjectLb.BackColor = Color.Orange; break;
                case "4":
                    subjectLb.BackColor = Color.Yellow; break;
                case "5":
                    subjectLb.BackColor = Color.LawnGreen; break;
            }
        }

        private void addStudent_Click(object sender, EventArgs e)
        {
            if (name.Text.Length == 0 || surname.Text.Length == 0 || patronymic.Text.Length == 0) 
            {
                MessageBox.Show("ФИО студента было введено не полностью", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                students.Add(new Student(surname.Text, name.Text, patronymic.Text, 2, 2, 2));
                updateList();
                studentslist.SelectedIndex = students.Count - 1;
                name.Clear();
                surname.Clear();
                patronymic.Clear();
                button2_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = studentslist.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Сначала выберите студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            students.RemoveAt(index);
            updateList();
            studentslist.SelectedIndex = -1;
            studentslist_SelectedIndexChanged(sender, e);
            MessageBox.Show("Студент был отчислен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void SerializeToXML(List<Student> lib, string path)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            TextWriter textWriter = new StreamWriter(path);
            serializer.Serialize(textWriter, lib);
            textWriter.Close();
        }

        private static List<Student> DeserializeFromXML(string path)
        {
            booln = true;
            var deserializer = new XmlSerializer(typeof(List<Student>));
            TextReader textReader = new StreamReader(path);
            var lib = (List<Student>)deserializer.Deserialize(textReader);
            textReader.Close();
            return lib;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show(this, "Вы действительно хотите выйти?", "Закрытие программы",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            var result = MessageBox.Show(this, "Вы хотели бы сохранить изменения?", "Сохранение",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) SerializeToXML(students, Path.GetFullPath(path));

        }
    }

    public class Student
    {
        public Student() { }
        public Student(string surname, string name, string patronymic, int grade_math, int grade_biology, int grade_practice)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Grade_math = grade_math;
            Grade_biology = grade_biology;
            Grade_practice = grade_practice;
        }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public int Grade_math { get; set; }
        public int Grade_biology { get; set; }
        public int Grade_practice { get; set; }

    }
}
