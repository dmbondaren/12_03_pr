using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            AddNumbersToList(textBox1.Text, collection1);
            UpdateListBoxItems(listBox1, collection1);
        }

        private void AddNumbersToList(string text, List<int> collection)
        {
            string[] numbers = text.Split(' ');
            foreach (string number in numbers)
            {
                if (int.TryParse(number, out int result))
                {
                    collection.Add(result);
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void UpdateListBoxItems(ListBox listBox, List<int> collection)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(collection.Select(x => x.ToString()).ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Додає у колекцію цілі числа з другого текстового поля
            AddNumbersToList(textBox2.Text, collection2);
            UpdateListBoxItems(listBox2, collection2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Видаляє елементи, які є у колекції 2 з колекції 1
            RemoveElementsFromCollection(collection1, collection2);
            UpdateListBoxItems(listBox1, collection1);
        }

        private void RemoveElementsFromCollection(List<int> source, List<int> toRemove)
        {
            foreach (int number in toRemove)
            {
                source.RemoveAll(x => x == number);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Створюємо новий Label
            Label newLabel = CreateNewLabel();
            // Додаємо новий Label до колекції labelList
            labelList.Add(newLabel);
        }

        private Label CreateNewLabel()
        {
            Label newLabel = new Label();
            newLabel.Text = "Новий Label";
            newLabel.AutoSize = true;
            int labelTop = 50 + labelList.Count * 30;
            newLabel.Location = new Point(50, labelTop);
            this.Controls.Add(newLabel);
            return newLabel;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            DisplayElementsWithSortedIndexes(listBox2, collection1, collection2);
        }

        private void DisplayElementsWithSortedIndexes(ListBox listBox, List<int> source, List<int> indexes)
        {
            HashSet<int> uniqueIndexes = new HashSet<int>(indexes);
            List<int> sortedIndexes = uniqueIndexes.Where(index => index >= 0 && index < source.Count).OrderBy(index => index).ToList();
            foreach (int index in sortedIndexes)
            {
                listBox.Items.Add(source[index]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateLabelWithText();
        }

        private void UpdateLabelWithText()
        {
            if (int.TryParse(textBox1.Text, out int index) && index >= 0 && index < labelList.Count)
            {
                string newText = textBox2.Text;
                labelList[index].Text = newText;
            }
            else
            {
                MessageBox.Show("Введіть коректний номер елементу.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerateAndDisplayRandomArrays();
        }

        private void GenerateAndDisplayRandomArrays()
        {
            if (arrays.Count >= 2)
            {
                arrays.Clear();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
            }

            Random random = new Random();
            int[] array = new int[3];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 100);
            }

            arrays.Add(array);

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
            SwapArrays();
        }

        private void SwapArrays()
        {
            int[] maxArray = arrays.OrderByDescending(array => array.Sum()).First();
            int[] minArray = arrays.OrderBy(array => array.Sum()).First();
            int maxIndex = arrays.IndexOf(maxArray);
            int minIndex = arrays.IndexOf(minArray);
            MessageBox.Show($"Максимальна сума: {maxArray.Sum()} (масив №{maxIndex + 1}), Мінімальна сума: {minArray.Sum()} (масив №{minIndex + 1})");
            arrays[maxIndex] = minArray;
            arrays[minIndex] = maxArray;
        }
    }
}
