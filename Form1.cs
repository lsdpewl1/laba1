﻿using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba1
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null;

        private ToolStripLabel dateLabel;
        private ToolStripLabel timeLabel;
        private ToolStripLabel layoutLabel;
        private void UpdateStatusLabels(object sender, EventArgs e)
        {
            dateLabel.Text = "" + DateTime.Now.ToLongDateString();
            timeLabel.Text = "" + DateTime.Now.ToLongTimeString();

            var currentLayout = InputLanguage.CurrentInputLanguage.LayoutName;
            layoutLabel.Text = "Раскладка: " + currentLayout;
        }
        public void Back()
        {
            FastColoredTextBox tb = inputTextBox;
            if (tb.UndoEnabled)
                tb.Undo();
        }
        public void Next()
        {
            FastColoredTextBox tb = inputTextBox;
            if (tb.RedoEnabled)
                tb.Redo();
        }
        public void In() { inputTextBox.Paste(); }
        public void Copy() { if (inputTextBox.SelectionLength > 0) { inputTextBox.Copy(); } }
        public void Cut() { if (inputTextBox.SelectionLength > 0) { inputTextBox.Cut(); } }
        public void Help() { MessageBox.Show("Описание функций меню\r\n\r\nФайл - производит действия с файлами\r\n\r\nСоздать - создает файл\r\nОткрыть - открывает файл\r\nСохранить - сохраняет изменения в файле\r\nСохранить как - сохраняет изменения в новый файл\r\nВыход - осуществляет выход из программы\r\n\r\nПравка - осуществляет изменения в файле\r\n\r\nОтменить - отменяет последнее изменение\r\nПовторить - повторяет последнее действие\r\nВырезать - вырезает выделенный фрагмент\r\nКопировать - копирует выделенный фрагмент\r\nВставить - вставляет выделенный фрагмент\r\nУдалить - удаляет выделенный фрагмент\r\nВыделить все - выделяет весь текст\r\n\r\nСправка - показывает справочную информацию\r\n\r\nВызов справки - описывает функции меню\r\nО программе - содержит информацию о программе", "Справка"); }
        public void About() { MessageBox.Show("Данная программа является результатом первой лабораторной работы Разработка пользовательского интерфейса (GUI) для языкового процессора по дисциплине Теория формальных языков и компиляторов. Целью работы было Разработать приложение – текстовый редактор. В дальнейшем он будет дополнен функциями языкового процессора.", "О программе"); }
        public void Create()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, "");
                currentFilePath = saveFileDialog.FileName;
            }
        }
        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                currentFilePath = openFileDialog.FileName;
            }
        }
        public void Save()
        {
            if (currentFilePath != null)
            {
                File.WriteAllText(currentFilePath, inputTextBox.Text);

            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, inputTextBox.Text);
                    currentFilePath = saveFileDialog.FileName;
                }
            }
        }
        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filePath in filePaths)
            {

                string fileContent = File.ReadAllText(filePath);

                inputTextBox.AppendText(fileContent + Environment.NewLine);
            }
        }
        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += Form_DragEnter;
            this.DragDrop += Form_DragDrop;

            dateLabel = new ToolStripLabel();
            dateLabel.Text = "";
            timeLabel = new ToolStripLabel();
            timeLabel.Text = "";
            layoutLabel = new ToolStripLabel();

            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            statusStrip1.Items.Add(layoutLabel);

            var timer = new Timer { Interval = 1000 };
            timer.Tick += UpdateStatusLabels;
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip t1 = new System.Windows.Forms.ToolTip();
            t1.SetToolTip(buttonCreate, "Создать");

            System.Windows.Forms.ToolTip t2 = new System.Windows.Forms.ToolTip();
            t2.SetToolTip(buttonOpen, "Открыть");

            System.Windows.Forms.ToolTip t3 = new System.Windows.Forms.ToolTip();
            t3.SetToolTip(buttonSave, "Сохранить");

            System.Windows.Forms.ToolTip t4 = new System.Windows.Forms.ToolTip();
            t4.SetToolTip(buttonCopy, "Копировать");

            System.Windows.Forms.ToolTip t5 = new System.Windows.Forms.ToolTip();
            t5.SetToolTip(buttonCut, "Вырезать");

            System.Windows.Forms.ToolTip t6 = new System.Windows.Forms.ToolTip();
            t6.SetToolTip(buttonIn, "Вставить");

            System.Windows.Forms.ToolTip t7 = new System.Windows.Forms.ToolTip();
            t7.SetToolTip(buttonBack, "Отменить");

            System.Windows.Forms.ToolTip t8 = new System.Windows.Forms.ToolTip();
            t8.SetToolTip(buttonNext, "Повторить");

            System.Windows.Forms.ToolTip t9 = new System.Windows.Forms.ToolTip();
            t9.SetToolTip(buttonInfo, "О программе");

            System.Windows.Forms.ToolTip t10 = new System.Windows.Forms.ToolTip();
            t10.SetToolTip(buttonHelp, "Вызов справки");

            System.Windows.Forms.ToolTip t11 = new System.Windows.Forms.ToolTip();
            t11.SetToolTip(buttonPlay, "Пуск");
        }
        private void buttonHelp_Click(object sender, EventArgs e) { Help(); }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e) { Help(); }
        private void buttonInfo_Click(object sender, EventArgs e) { About(); }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) { About(); }
        private void buttonCopy_Click(object sender, EventArgs e) { Copy(); }
        private void buttonCut_Click(object sender, EventArgs e) { Cut(); }
        private void buttonIn_Click(object sender, EventArgs e) { In(); }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) { Cut(); }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) { Copy(); }
        private void inToolStripMenuItem_Click(object sender, EventArgs e) { In(); }
        private void buttonBack_Click(object sender, EventArgs e) { Back(); }
        private void buttonNext_Click(object sender, EventArgs e)
        {

            Next();
        }
        private void backToolStripMenuItem_Click(object sender, EventArgs e) { Back(); }
        private void nextToolStripMenuItem_Click(object sender, EventArgs e) { Next(); }
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputTextBox.SelectedText != "")
            {
                inputTextBox.Text = inputTextBox.Text.Remove(inputTextBox.SelectionStart, inputTextBox.SelectionLength);
            }
        }
        private void allToolStripMenuItem_Click(object sender, EventArgs e) { inputTextBox.SelectAll(); }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e) { Open(); }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, inputTextBox.Text);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) { Save(); }
        private void createToolStripMenuItem_Click(object sender, EventArgs e) { Create(); }
        private void buttonCreate_Click(object sender, EventArgs e) { Create(); }
        private void buttonOpen_Click(object sender, EventArgs e) { Open(); }
        private void buttonSave_Click(object sender, EventArgs e) { Save(); }
        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            // Обновление размеров элементов управления при изменении размера панелей
            inputTextBox.Width = splitContainer1.Panel1.Width;
            inputTextBox.Height = splitContainer1.Panel1.Height;

            //outputTextBox.Width = splitContainer1.Panel2.Width;
            //outputTextBox.Height = splitContainer1.Panel2.Height;
        }
        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Сохранить изменения перед выходом?", "Подтверждение", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Save();
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
            //Application.Exit();
        }

        public class Lexeme
        {
            public int Code { get; set; }
            public LexemeType Type { get; set; }
            public string Token { get; set; }
            public int StartPosition { get; set; }
            public int EndPosition { get; set; }

            public Lexeme(int code, LexemeType type, string input, int startPosition, int endPosition)
            {
                Code = code;
                Type = type;
                Token = input.Substring(startPosition, endPosition - startPosition + 1);
                StartPosition = startPosition;
                EndPosition = endPosition;
            }
        }

        public enum LexemeType
        {
            //const MARKS:i32 = 100; 
            Keyword,
            Identifier,
            Delimiter,
            Colon,
            DataType,
            Equally,
            Minus,
            Plus,
            Number,
            Semicolon,
            Invalid
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text;

            Dictionary<LexemeType, int> lexemeCodes = new Dictionary<LexemeType, int>()
    {
        { LexemeType.Keyword, 1 },
        { LexemeType.Identifier, 2 },
        { LexemeType.Delimiter, 3 },
        { LexemeType.Colon, 4 },
        { LexemeType.DataType, 5 },
        { LexemeType.Equally, 6 },
        { LexemeType.Minus, 7 },
        { LexemeType.Plus, 8 },
        { LexemeType.Number, 9 },
        { LexemeType.Semicolon, 10 },        
        { LexemeType.Invalid, 11 }
    };

            string[] keywords = { "const" };
            string[] delimiters = { " " };
            string[] colons = { ":" };
            string[] dataTypes = { "i32" };
            string[] equallies = { "=" };
            string[] pluses = { "+" };
            string[] minuses = { "-" };
            string[] semicolones = { ";" };
            

            List<Lexeme> lexemes = new List<Lexeme>();

            int position = 0;
            while (position < input.Length)
            {
                bool found = false;

                //const
                foreach (string keyword in keywords)
                {
                    if (input.Substring(position).StartsWith(keyword))
                    {
                        lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Keyword], LexemeType.Keyword, input, position, position + keyword.Length - 1));
                        position += keyword.Length;
                        found = true;
                        break;
                    }
                }

                if (found) continue;

                //:
                foreach (string op in colons)
                {
                    if (input.Substring(position).StartsWith(op))
                    {
                        lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Colon], LexemeType.Colon, input, position, position + op.Length - 1));
                        position += op.Length;
                        found = true;
                        break;
                    }
                }

                if (found) continue;

                //data type
                foreach (string dataType in dataTypes)
                {
                    if (input.Substring(position).StartsWith(dataType))
                    {
                        lexemes.Add(new Lexeme(lexemeCodes[LexemeType.DataType], LexemeType.DataType, input, position, position + dataType.Length - 1));
                        position += dataType.Length;
                        found = true;
                        break;
                    }
                }

                if (found) continue;
                  
                //=
                foreach (string op in equallies)
                {
                    if (input.Substring(position).StartsWith(op))
                    {
                        lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Equally], LexemeType.Equally, input, position, position + op.Length - 1));
                        position += op.Length;
                        found = true;
                        break;
                    }
                }

                if (found) continue;

                //+
                foreach (string op in pluses)
                {
                    if (input.Substring(position).StartsWith(op))
                    {
                        lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Equally], LexemeType.Plus, input, position, position + op.Length - 1));
                        position += op.Length;
                        found = true;
                        break;
                    }
                }

                if (found) continue;

                //-
                foreach (string op in minuses)
                {
                    if (input.Substring(position).StartsWith(op))
                    {
                        lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Equally], LexemeType.Minus, input, position, position + op.Length - 1));
                        position += op.Length;
                        found = true;
                        break;
                    }
                }

                if (found) continue;

                //;
                foreach (string op in semicolones)
                {
                    if (input.Substring(position).StartsWith(op))
                    {
                        lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Semicolon], LexemeType.Semicolon, input, position, position + op.Length - 1));
                        position += op.Length;
                        found = true;
                        break;
                    }
                }

                

                if (found) continue;

                //_
                foreach (string delimiter in delimiters)
                {
                    if (input.Substring(position).StartsWith(delimiter))
                    {
                        lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Delimiter], LexemeType.Delimiter, input, position, position + delimiter.Length - 1));
                        position += delimiter.Length;
                        found = true;
                        break;
                    }
                }

                if (found) continue;

                //name
                if (char.IsLetter(input[position]))
                {
                    int start = position;
                    while (position < input.Length && char.IsLetterOrDigit(input[position]))
                    {
                        position++;
                    }
                    string identifier = input.Substring(start, position - start);
                    lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Identifier], LexemeType.Identifier, input, start, position - 1));
                }
                //value
                else if (char.IsDigit(input[position]))
                {
                    int start = position;
                    while (position < input.Length && char.IsDigit(input[position]))
                    {
                        position++;
                    }
                    string number = input.Substring(start, position - start);
                    lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Number], LexemeType.Number, input, start, position - 1));
                }
                //error
                else
                {
                    string invalid = input[position].ToString();
                    lexemes.Add(new Lexeme(lexemeCodes[LexemeType.Invalid], LexemeType.Invalid, input, position, position));
                    position++;
                }
            }

            dataGridView1.Rows.Clear();
            foreach (Lexeme lexeme in lexemes)
            {
                dataGridView1.Rows.Add(lexeme.Code, lexeme.Type, lexeme.Token, lexeme.StartPosition, lexeme.EndPosition);
            }
        }



    }
}