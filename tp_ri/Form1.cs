using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace tp_ri
{
    public partial class Form1 : Form
    {
        static List<string> Tache_1_i(string word, decimal line, string fileName)
        {
            List<string> result = new List<string>();
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                if (sr.ReadLine().Contains(word))
                {
                    result.Add($"Le mot est trouvé.");
                    return result;
                }
                else
                {
                    result.Add("Le mot n'est pas trouver");
                    return result;
                }
            }
        }
        static List<string> Tache_1_ii(string word, decimal line, string fileName)
        {
            List<string> result = new List<string>();
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n', '|', '!', ';', '?' };
                string text = sr.ReadLine();
                string[] listWords = text.Split(delimiterChars);
                if (listWords.Contains(word))
                {
                    result.Add("Le mot est trouvé.");
                    return result;
                }
                else
                {
                    result.Add("Le mot n'est pas trouvé.");
                    return result;
                }
            }
        }

        static List<string> Tache_1_iii(string word, string fileName)
        {
            List<string> result = new List<string>();
            Boolean found = false;
            using (var sr = new StreamReader(fileName))
            {
                char[] delimiterChars = { ',', '.', ':', '\t', '\n', '|', '!', ';', '?' };
                string text = sr.ReadToEnd();
                string[] listSentences = text.Split(delimiterChars);
                foreach (string sentence in listSentences)
                {
                    if (sentence.Contains(word))
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                    result.Add("Le mot est trouvé.");
                else
                    result.Add("Le mot n'est pas trouvé.");
                return result;
            }
        }
        static List<string> Tache_2(string subword, string fileName)
        {
            List<string> result = new List<string>();
            Boolean found = false;
            using (var sr = new StreamReader(fileName))
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n', '|', '!', ';', '?' };
                string text = sr.ReadToEnd();
                string[] listWords = text.Split(delimiterChars);
                if (text.Contains(subword))
                {
                    foreach (string word in listWords)
                    {
                        if (word == subword)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        result.Add("C'est un mot");
                    else
                        result.Add("C'est un sous-mot");
                }
                else
                    result.Add("N'existe pas");
                return result;
            }
        }
        static List<string> Tache_3(string word, string fileName)
        {
            List<string> result = new List<string>();
            using (var sr = new StreamReader(fileName))
            {
                string text = sr.ReadToEnd();
                if (text.Contains(word))
                {
                    result.Add("Le mot est trouvé.");
                    return result;
                }
                else
                {
                    result.Add("Le mot n'est pas trouvé.");
                    return result;
                }
            }
        }
        static List<string> Tache_4(string word, string folderName)
        {
            Boolean b = false;
            List<string> result = new List<string>();
            foreach (string file in Directory.EnumerateFiles(folderName))
            {
                using (var sr = new StreamReader(file))
                {
                    char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n', '|', '!', ';', '?' };
                    string text = sr.ReadToEnd();
                    string[] listWords = text.Split(delimiterChars);
                    if (text.Contains(word))
                    {
                        foreach (string subword in listWords)
                        {
                            if (word == subword)
                            {
                                b = true;
                                break;
                            }
                            else
                                b = false;
                        }
                        if (b == true)
                        {
                            result.Add("Trouver comme un mot.");
                        }
                        else
                            result.Add("Trouver comme un sous-mot.");
                    }
                    else
                        result.Add("Le mot n'est pas trouvé.");
                }
            }
            return result;
        }
        static List<string> Tache_5(string word, string folderName)
        {
            int count = 0;
            List<string> finalResult = new List<string>();
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (string file in Directory.EnumerateFiles(folderName))
            {
                using (var sr = new StreamReader(file))
                {
                    string text = sr.ReadToEnd();
                    foreach (Match m in Regex.Matches(text, word))
                    {
                        count++;
                    }
                    result.Add(file, count);
                }
                count = 0;

            }
            var sortedResult = from entry in result orderby entry.Value descending select entry;
            foreach (KeyValuePair<string, int> element in sortedResult)
            {
                finalResult.Add($"Trouver dans {element.Key}.");
                finalResult.Add($"{element.Value.ToString()} fois.");
            }
            return finalResult;

        }
        static List<string> Tache_9(string word, string folderName)
        {
            int count = 0;
            List<string> finalResult = new List<string>();
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (string file in Directory.EnumerateFiles(folderName))
            {
                using (var sr = new StreamReader(file))
                {
                    string text = sr.ReadToEnd().ToLower();
                    foreach (Match m in Regex.Matches(text, word.ToLower()))
                    {
                        count++;
                    }
                    result.Add(file, count);
                }
                count = 0;

            }
            var sortedResult = from entry in result orderby entry.Value descending select entry;
            foreach (KeyValuePair<string, int> element in sortedResult)
            {
                finalResult.Add($"Trouver dans {element.Key}.");
                finalResult.Add($"{element.Value.ToString()} fois.");
            }
            return finalResult;

        }

        static List<string> Tache_10(string word, string folderName)
        {
            List<string> result = new List<string>();
            if (word.Contains(' '))
            {
                string[] query = word.Split(' ');
                foreach (string file in Directory.EnumerateFiles(folderName))
                {
                    using (var sr = new StreamReader(file))
                    {
                        string[] text = sr.ReadToEnd().Split('\n');
                        foreach (string line in text)
                        {
                            if (query.Any(line.ToLower().Contains))
                            {
                                result.Add($"Trouver dans {file}.");
                                result.Add(line);
                            }
                        }
                    }

                }
            }
            else
            {
                foreach (string file in Directory.EnumerateFiles(folderName))
                {
                    using (var sr = new StreamReader(file))
                    {
                        string[] text = sr.ReadToEnd().Split('\n');
                        foreach (string line in text)
                        {
                            if (word.Any(line.ToLower().Contains))
                            {
                                result.Add($"Trouver dans {file}.");
                                result.Add(line);
                            }
                        }
                    }

                }
            }
            return result;
        }
        static List<string> Tache_11(string word1, string word2, string fileName)
        {
            List<string> result = new List<string>();
            using (var sr = new StreamReader(fileName))
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\n', '|', '!', ';', '?' };
                string text = sr.ReadToEnd().ToLower();
                string[] listWords = text.Split(delimiterChars);
                int distance = text.IndexOf(word2.ToLower()) - text.IndexOf(word1.ToLower());
                result.Add($"La distance : {Math.Abs(distance).ToString()}.");
                return result;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }


        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1i_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_1_i(textBox1.Text, numericUpDown1.Value, label4.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();
            label5.Text = folderDialog.SelectedPath;
        }

        private void buttonfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            label4.Text = fileDialog.FileName;
        }


        private void button1ii_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_1_ii(textBox1.Text, numericUpDown1.Value, label4.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button1iii_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_1_iii(textBox1.Text, label4.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_2(textBox1.Text, label4.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_3(textBox1.Text, label4.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_4(textBox1.Text, label5.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_5(textBox1.Text, label5.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_9(textBox1.Text, label5.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_10(textBox1.Text, label5.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = Tache_11(textBox1.Text, textBox2.Text, label4.Text);
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
