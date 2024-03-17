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
        List<int[]> arrays = new List<int[]>(); // колекція масивів

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

        private void button5_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи вже існують два масиви
            if (arrays.Count >= 2)
            {
                // Якщо так, то видаляємо їх
                arrays.Clear();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
            }

            // Створюємо масив з 3 випадкових цілих чисел
            Random random = new Random();
            int[] array = new int[3];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 100); // Змініть діапазон, якщо потрібно
            }

            // Додаємо масив до колекції
            arrays.Add(array);

            // Відображаємо масив у відповідному listBox
            if (arrays.Count == 1)
            {
                listBox1.Items.AddRange(array.Select(x => x.ToString()).ToArray());
            }
            else if (arrays.Count == 2)
            {
                listBox2.Items.AddRange(array.Select(x => x.ToString()).ToArray());
            }
        }



        private void button7_Click(object sender, EventArgs e)
        {
            // Знаходимо масиви з максимальною та мінімальною сумою елементів
            int[] maxArray = arrays.OrderByDescending(array => array.Sum()).First();
            int[] minArray = arrays.OrderBy(array => array.Sum()).First();
            // Виводимо їх номери в колекції
            int maxIndex = arrays.IndexOf(maxArray);
            int minIndex = arrays.IndexOf(minArray);
            MessageBox.Show($"Максимальна сума: {maxArray.Sum()} (масив №{maxIndex + 1}), Мінімальна сума: {minArray.Sum()} (масив №{minIndex + 1})");
            // Міняємо їх місцями в колекції
            arrays[maxIndex] = minArray;
            arrays[minIndex] = maxArray;
        }

    }
}
