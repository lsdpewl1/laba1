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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba1
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null;

        private ToolStripLabel dateLabel;
        private ToolStripLabel timeLabel;
        private ToolStripLabel layoutLabel;

        //private void inputTextBox_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (ModifierKeys.HasFlag(Keys.Control))
        //    {
        //        ChangeFontSize(e.Delta > 0 ? 1 : -1);
        //        e.Handled = true;
        //    }
        //}

        //private void lineNumbersTextBox_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (ModifierKeys.HasFlag(Keys.Control))
        //    {
        //        ChangeFontSize(e.Delta > 0 ? 1 : -1);
        //        e.Handled = true;

        //    }
        //}

        //private void ChangeFontSize(int delta)
        //{
        //    const int minFontSize = 6;
        //    const int maxFontSize = 72;

        //    //int newFontSize = inputTextBox.Font.Size + delta;
        //    int newFontSize = (int)(inputTextBox.Font.Size + delta);

        //    if (newFontSize < minFontSize || newFontSize > maxFontSize)
        //        return;

        //    Font newFont = new Font(inputTextBox.Font.FontFamily, newFontSize);
        //    //inputTextBox.Font = newFont;
        //    lineNumbersTextBox.Font = newFont;
        //}

        private void UpdateStatusLabels(object sender, EventArgs e)
        {

            dateLabel.Text = "" + DateTime.Now.ToLongDateString();
            timeLabel.Text = "" + DateTime.Now.ToLongTimeString();


            var currentLayout = InputLanguage.CurrentInputLanguage.LayoutName;
            layoutLabel.Text = "Раскладка: " + currentLayout;
        }


        public void Back() { if (inputTextBox.CanUndo) { inputTextBox.Undo(); } }
        public void Next() { if (inputTextBox.CanRedo) { inputTextBox.Redo(); } }
        public void In() { inputTextBox.Paste(); }
        public void Copy() { if (inputTextBox.SelectionLength > 0) { inputTextBox.Copy(); } }
        public void Cut() { if (inputTextBox.SelectionLength > 0) { inputTextBox.Cut(); } }
        public void Help() { MessageBox.Show("Описание функций меню\r\n\r\nФайл - производит действия с файлами\r\n\r\nСоздать - создает файл\r\nОткрыть - открывает файл\r\nСохранить - сохраняет изменения в файле\r\nСохранить как - сохраняет изменения в новый файл\r\nВыход - осуществляет выход из программы\r\n\r\nПравка - осуществляет изменения в файле\r\n\r\nОтменить - отменяет последнее изменение\r\nПовторить - повторяет последнее действие\r\nВырезать - вырезает выделенный фрагмент\r\nКопировать - копирует выделенный фрагмент\r\nВставить - вставляет выделенный фрагмент\r\nУдалить - удаляет выделенный фрагмент\r\nВыделить все - выделяет весь текст\r\n\r\nСправка - показывает справочную информацию\r\n\r\nВызов справки - описывает функции меню\r\nО программе - содержит информацию о программе", "Справка"); }
        public void About() { MessageBox.Show("Это текстовый редактор", "О программе"); }
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

        //private void Form1_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    // Проверяем, нажата ли клавиша Ctrl
        //    if (ModifierKeys.HasFlag(Keys.Control))
        //    {
        //        // Изменяем масштаб текста в inputTextBox
        //        if (e.Delta > 0)
        //        {
        //            // Увеличиваем масштаб текста
        //            inputTextBox.ZoomFactor += 0.1f;
        //        }
        //        else if (e.Delta < 0)
        //        {
        //            // Уменьшаем масштаб текста
        //            if (inputTextBox.ZoomFactor > 0.1f)
        //            {
        //                inputTextBox.ZoomFactor -= 0.1f;
        //            }
        //        }

        //        // Синхронизируем масштаб текста в lineNumbersTextBox
        //        lineNumbersTextBox.ZoomFactor = inputTextBox.ZoomFactor;
        //    }
        //}


        private void Form1_Load(object sender, EventArgs e)
        {
            //inputTextBox.MouseWheel += inputTextBox_MouseWheel;
            //lineNumbersTextBox.MouseWheel += lineNumbersTextBox_MouseWheel;
            //this.MouseWheel += Form1_MouseWheel;

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

            // Add line numbering functionality
            inputTextBox.ScrollBars = RichTextBoxScrollBars.Both;
            inputTextBox.WordWrap = false;
            inputTextBox.Multiline = true;
            inputTextBox.TextChanged += InputTextBox_TextChanged;
            inputTextBox.VScroll += InputTextBox_VScroll;
            inputTextBox.FontChanged += InputTextBox_FontChanged;
            inputTextBox.ContentsResized += InputTextBox_ContentsResized;
            UpdateLineNumbers();
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            // Сохранение текущей позиции курсора
            int selectionStart = inputTextBox.SelectionStart;
            int selectionLength = inputTextBox.SelectionLength;

            // Очистка форматирования текста
            inputTextBox.SelectAll();
            inputTextBox.SelectionColor = Color.Black;

            // Определение ключевых слов
            string[] keywords = { "using", "namespace", "class", "public", "private", "static", "void", "int", "string" };

            // Поиск и форматирование ключевых слов
            foreach (string keyword in keywords)
            {
                int index = 0;
                while (index < inputTextBox.TextLength)
                {
                    int keywordStart = inputTextBox.Find(keyword, index, RichTextBoxFinds.WholeWord);
                    if (keywordStart == -1)
                        break;

                    inputTextBox.Select(keywordStart, keyword.Length);
                    inputTextBox.SelectionColor = Color.Blue;
                    index = keywordStart + keyword.Length;
                }
            }

            // Восстановление позиции курсора
            inputTextBox.Select(selectionStart, selectionLength);
            inputTextBox.SelectionColor = Color.Black;
            UpdateLineNumbers();


        }

        private void InputTextBox_VScroll(object sender, EventArgs e)
        {
            UpdateLineNumbers();
        }

        private void InputTextBox_FontChanged(object sender, EventArgs e)
        {
            UpdateLineNumbers();
        }

        private void InputTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            UpdateLineNumbers();
        }

        private void UpdateLineNumbers()
        {
            Point pt = new Point(0, 0);
            int firstIndex = inputTextBox.GetCharIndexFromPosition(pt);
            int firstLine = inputTextBox.GetLineFromCharIndex(firstIndex);
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            int lastIndex = inputTextBox.GetCharIndexFromPosition(pt);
            int lastLine = inputTextBox.GetLineFromCharIndex(lastIndex);
            Point lastCharPt = inputTextBox.GetPositionFromCharIndex(inputTextBox.Text.Length);
            int lineHeight = lastCharPt.Y + inputTextBox.Font.Height;
            if (lastLine > firstLine)
                inputTextBox.Margin = new Padding(0, 0, ClientRectangle.Width - lastCharPt.X - 20, 0);
            else
                inputTextBox.Margin = new Padding(0);
            lineNumbersTextBox.Text = "";
            for (int i = firstLine; i <= lastLine + 1; i++)
                lineNumbersTextBox.Text += i + 1 + "\n";
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

        private void buttonNext_Click(object sender, EventArgs e) { Next(); }

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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Сохранить изменения перед выходом?", "Подтверждение", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Save();
            }
            else if (result == DialogResult.Cancel)
            {
                // Отмена закрытия формы
                return;
            }

            Application.Exit();

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

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            // Обновление размеров элементов управления при изменении размера панелей
            inputTextBox.Width = splitContainer1.Panel1.Width;
            inputTextBox.Height = splitContainer1.Panel1.Height;

            outputTextBox.Width = splitContainer1.Panel2.Width;
            outputTextBox.Height = splitContainer1.Panel2.Height;
        }

        private class LineNumberTextBox : RichTextBox
        {
            private int currentLine;

            public LineNumberTextBox()
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.DoubleBuffer, true);
                SetStyle(ControlStyles.ResizeRedraw, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                DrawLineNumbers(e.Graphics);
            }

            private void DrawLineNumbers(Graphics g)
            {
                int firstVisibleChar = GetCharIndexFromPosition(new Point(0, 0));
                int firstVisibleLine = GetLineFromCharIndex(firstVisibleChar);
                int lineHeight = Font.Height;
                int yOffset = 2;

                for (int i = firstVisibleLine; i < Lines.Length; i++)
                {
                    string lineText = (i + 1).ToString();
                    g.DrawString(lineText, Font, Brushes.Black, 3, yOffset);
                    yOffset += lineHeight;
                }
            }

            protected override void OnVScroll(EventArgs e)
            {
                base.OnVScroll(e);
                Invalidate();
            }

            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                Invalidate();
            }

         
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
