using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_03_pr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> collection1 = new List<int>(); // колекція 1
        List<int> collection2 = new List<int>(); // колекція 2
        List<Label> labelList = new List<Label>(); // список label

        private void button1_Click(object sender, EventArgs e)
        {
            // Додає у колекцію цілі числа з першого текстового поля
            string[] numbers = textBox1.Text.Split(' ');
            foreach (string number in numbers)
            {
                if (int.TryParse(number, out int result))
                {
                    collection1.Add(result);
                }
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(collection1.Select(x => x.ToString()).ToArray());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Додає у колекцію цілі числа з другого текстового поля
            string[] numbers = textBox2.Text.Split(' ');
            foreach (string number in numbers)
            {
                if (int.TryParse(number, out int result))
                {
                    collection2.Add(result);
                }
            }
            listBox2.Items.Clear();
            listBox2.Items.AddRange(collection2.Select(x => x.ToString()).ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Видаляє елементи, які є у колекції 2 з колекції 1
            foreach (int number in collection2)
            {
                collection1.RemoveAll(x => x == number);
            }
            listBox1.Items.Clear();
            listBox1.Items.AddRange(collection1.Select(x => x.ToString()).ToArray());
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {
            // Створюємо новий Label
            Label newLabel = new Label();
            // Налаштовуємо його властивості
            newLabel.Text = "Новий Label"; // Замініть цей текст на те, що потрібно відображати
            newLabel.AutoSize = true; // Автоматично налаштувати розмір Label
                                      // Розміщаємо новий Label на формі
            int labelTop = 50 + labelList.Count * 30; // Визначаємо вертикальне положення Label
            newLabel.Location = new Point(50, labelTop); // Встановлюємо положення Label на формі
            this.Controls.Add(newLabel); // Додаємо Label до колекції контролів форми
                                         // Додаємо новий Label до колекції labelList
            labelList.Add(newLabel);
        }


        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Знаходить і показує масив з цієї колекції з максимальною сумою елементів
            List<int[]> arrays = new List<int[]>(); // колекція масивів
            // Додавання масивів в колекцію
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                int[] randomArray = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    randomArray[j] = rnd.Next(-100, 100); // генеруємо випадкове число від -100 до 99
                }
                arrays.Add(randomArray);
            }
            // Пошук масиву з максимальною сумою елементів
            int maxSum = arrays.Max(arr => arr.Sum());
            int[] maxSumArray = arrays.First(arr => arr.Sum() == maxSum);
            // Вивід масиву з максимальною сумою елементів
            MessageBox.Show("Масив з максимальною сумою елементів: " + string.Join(", ", maxSumArray));
        }
        private void button9_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            // Створюємо множину для зберігання унікальних значень індексів з колекції 2
            HashSet<int> uniqueIndexes = new HashSet<int>(collection2);
            // Сортуємо та фільтруємо індекси
            List<int> sortedIndexes = uniqueIndexes.Where(index => index >= 0 && index < collection1.Count).OrderBy(index => index).ToList();
            // Виводимо значення елементів за відфільтрованими індексами
            foreach (int index in sortedIndexes)
            {
                listBox2.Items.Add(collection1[index]);
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Беремо номер елементу з текстбоксу1
            if (int.TryParse(textBox1.Text, out int index) && index >= 0 && index < labelList.Count)
            {
                // Беремо текст з текстбоксу2
                string newText = textBox2.Text;
                // Знаходимо Label за вказаним індексом та змінюємо його текст
                labelList[index].Text = newText;
            }
            else
            {
                MessageBox.Show("Введіть коректний номер елементу.");
            }
        }
    }
}
