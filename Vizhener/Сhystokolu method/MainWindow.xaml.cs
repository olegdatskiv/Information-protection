using System;
using System.Windows;
using static System.Array;

namespace Task
{
    public partial class MainWindow : Window
    {
        char[] alphabet = new char[] {
                  'A','B','C','D','E',
                  'F','G','H','I', 'J','K',
                  'L','M','N','O','P',
                  'Q','R','S','T','U',
                  'V','W','X','Y','Z', ' ' };
        public MainWindow()
        {
            InitializeComponent();

        }
        private string getKey()
        {
            string key;
            if (checkBox.IsChecked == true)
            {
                key = Generate_Key(textBoxToEncrypt.Text.Length, 200);
                label1.Content = key;
            }
            else
            {
                key = textBox2.Text.ToUpper();
            }
            return key;
        }
        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            Encrypted.Text = Encrypt(textBoxToEncrypt.Text.ToUpper(), getKey());
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            decryptedResult.Text = Decrypt(encryptedText.Text.ToUpper(), getKey());
        }
        private string Encrypt(string input, string keyword)
        {
            string result = "";
            int keywordIndex = 0;
            foreach (char messageSymbol in input)
            {
                int ci = (IndexOf(alphabet, messageSymbol) + IndexOf(alphabet, keyword[keywordIndex])) % alphabet.Length;
                result += alphabet[ci];
                keywordIndex++;
                if ((keywordIndex + 1) == keyword.Length)
                {
                    keywordIndex = 0;
                }
            }
            return result;
        }
        private string Decrypt(string input, string keyword)
        {
            string result = "";
            int keywordIndex = 0;
            foreach (char symbol in input)
            {
                int position = (IndexOf(alphabet, symbol) + alphabet.Length - IndexOf(alphabet, keyword[keywordIndex])) % alphabet.Length;
                result += alphabet[position];
                keywordIndex++;
                if ((keywordIndex + 1) == keyword.Length)
                {
                    keywordIndex = 0;
                }
            }
            return result;
        }
        private string Generate_Key(int length, int startSeed)
        {
            Random rand = new Random(startSeed);
            string result = "";
            for (int i = 0; i < length; i++)
                result += alphabet[rand.Next(0, alphabet.Length)];
            return result;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
