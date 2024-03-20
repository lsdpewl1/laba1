﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static laba1.Form1;
using System.Windows.Forms;

namespace laba1
{
    public class Parser
    {
        private List<Lexeme> lexemes;
        private int position;
        public int counter;
        public List<LexemeType> expectedLexemes;
        public List<LexemeType> foundLexemes;
        public string str;

        public Parser(List<Lexeme> lexemes)
        {
            this.lexemes = lexemes;
            this.position = 0;
            this.counter = 0;
        }

        public void Parse(DataGridView dataGridView1)
        {
            DEF(dataGridView1);
        }

        private void DEF(DataGridView dataGridView1)
        {
            try
            {
                if (lexemes[position].Type == LexemeType.Keyword)
                {
                    str += lexemes[position].Token;
                    position++;
                    
                    DEFREM(dataGridView1);
                }
                else if (lexemes[position].Type == LexemeType.Invalid)
                {

                    dataGridView1.Rows.Add($"Недопустимый символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    position++;
                    counter++;
                    DEF(dataGridView1);
                }
                else if (lexemes[position].Type != LexemeType.Keyword)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    position++;
                    counter++;
                    DEF(dataGridView1);
                }
                
                else
                {
                    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался ключевое слово 'const'");
                    counter++;
                    DEFREM(dataGridView1);
                }
                //}
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }
         
        private void DEFREM(DataGridView dataGridView1)
        {
            try
            {
                if (lexemes[position].Type == LexemeType.Delimiter)
                {
                    str += lexemes[position].Token;
                    position++;
                    ID(dataGridView1);
                }
                else if (lexemes[position].Type == LexemeType.Invalid)
                {

                    dataGridView1.Rows.Add($"Недопустимый символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    DEFREM(dataGridView1);
                }

                else if (lexemes[position].Type != LexemeType.Delimiter)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    DEFREM(dataGridView1);
                }
                else
                {
                    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался пробел");
                    counter++;
                    ID(dataGridView1);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void ID(DataGridView dataGridView1)
        {
            try
            {
                if (lexemes[position].Type == LexemeType.Identifier)
                {
                    str += lexemes[position].Token;
                    position++;
                    IDREM(dataGridView1);
                }
                else if (lexemes[position].Type == LexemeType.Invalid)
                {

                    dataGridView1.Rows.Add($"Недопустимый символ  {lexemes[position].Token}  в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    ID(dataGridView1);
                }
                else if (lexemes[position].Type != LexemeType.Identifier)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    ID(dataGridView1);
                }
                else
                {
                    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался идентификатор");
                    counter++;
                    IDREM(dataGridView1);
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void IDREM(DataGridView dataGridView1)
        {
            try
            {
                if (lexemes[position].Type == LexemeType.Colon)
                {
                    str += lexemes[position].Token;
                    position++;
                    TYPE(dataGridView1);
                }
                else if (lexemes[position].Type == LexemeType.Invalid)
                {

                    dataGridView1.Rows.Add($"Недопустимый символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    IDREM(dataGridView1);
                }
                else if (lexemes[position].Type != LexemeType.Colon)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    IDREM(dataGridView1);
                }
                else
                {
                    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался двоеточие");
                    counter++;
                    TYPE(dataGridView1);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
}

        private void TYPE(DataGridView dataGridView1)
        {
            try
            {


                if (lexemes[position].Type == LexemeType.DataType)
                {
                    str += lexemes[position].Token;
                    position++;
                    TYPEREM(dataGridView1);
                }
                else if (lexemes[position].Type == LexemeType.Invalid)
                {

                    dataGridView1.Rows.Add($"Недопустимый символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    TYPE(dataGridView1);
                }
                else if (lexemes[position].Type != LexemeType.DataType)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    TYPE(dataGridView1);
                }
                else
                {
                    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался тип данных");
                    counter++;
                    TYPEREM(dataGridView1);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void TYPEREM(DataGridView dataGridView1)
        {
            try
            {
                if (lexemes[position].Type == LexemeType.Delimiter)
                {
                    position++;
                    try
                    {
                        if (lexemes[position].Type == LexemeType.Equally)
                        {
                            str += lexemes[position].Token;
                            position++;
                            EQUAL(dataGridView1);
                        }
                        else if (lexemes[position].Type == LexemeType.Invalid)
                        {

                            dataGridView1.Rows.Add($"Недопустимый символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                            counter++;
                            position++;
                            TYPEREM(dataGridView1);
                        }
                        else if (lexemes[position].Type != LexemeType.Equally)
                        {
                            dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                            counter++;
                            position++;
                            TYPEREM(dataGridView1);
                        }
                        else
                        {
                            dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался равно");
                            counter++;
                            EQUAL(dataGridView1);
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                        counter++;
                    }
                }

                else if (lexemes[position].Type == LexemeType.Equally)
                {
                    str += lexemes[position].Token;
                    position++;
                    EQUAL(dataGridView1);
                }
                else if (lexemes[position].Type == LexemeType.Invalid)
                {

                    dataGridView1.Rows.Add($"Недопустимый символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    TYPEREM(dataGridView1);
                }
                else if (lexemes[position].Type != LexemeType.Equally && lexemes[position].Type != LexemeType.Delimiter)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    TYPEREM(dataGridView1);
                }
                else
                {
                    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался равно");
                    counter++;
                    EQUAL(dataGridView1);
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }

        }

        private void EQUAL(DataGridView dataGridView1)
        {
            if (lexemes[position].Type == LexemeType.Delimiter)
            {
                position++;
                if ((lexemes[position].Type == LexemeType.Plus) || (lexemes[position].Type == LexemeType.Minus))
                {
                    str += lexemes[position].Token;
                    position++;
                    NUMBER(dataGridView1);
                }
                else
                {
                    NUMBER(dataGridView1);
                }
            }
            else if ((lexemes[position].Type == LexemeType.Plus) || (lexemes[position].Type == LexemeType.Minus))
            {
                str += lexemes[position].Token;
                position++;
                NUMBER(dataGridView1);
            }
            else
            {
                NUMBER(dataGridView1);
            }
        }

        private void NUMBER(DataGridView dataGridView1)
        {
            try
            {


                if (lexemes[position].Type == LexemeType.Number)
                {
                    str += lexemes[position].Token;
                    position++;
                    NUMBERREM(dataGridView1);
                }
                else if (lexemes[position].Type == LexemeType.Invalid)
                {

                    dataGridView1.Rows.Add($"Недопустимый символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    NUMBER(dataGridView1);
                }
                else if (lexemes[position].Type != LexemeType.Number)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    NUMBER(dataGridView1);
                }
                else
                {
                    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидалось число");
                    counter++;
                    NUMBERREM(dataGridView1);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }
        }

        private void NUMBERREM(DataGridView dataGridView1)
        {
            try
            {
                if (lexemes[position].Type == LexemeType.Semicolon)
                {
                    str += lexemes[position].Token;
                    position++;
                    END(dataGridView1);

                }
                else if (lexemes[position].Type == LexemeType.Invalid)
                {

                    dataGridView1.Rows.Add($"Недопустимый символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    NUMBERREM(dataGridView1);
                }
                else if (lexemes[position].Type != LexemeType.Semicolon)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    NUMBERREM(dataGridView1);
                }
                else
                {
                    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидалась точка с запятой");
                    counter++;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
            }

        }

        private void END(DataGridView dataGridView1)
        {
            try
            {
                if (lexemes[position].Type == LexemeType.Invalid)
                {

                    dataGridView1.Rows.Add($"Недопустимый символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    NUMBERREM(dataGridView1);
                }
                else if (lexemes[position].Type == LexemeType.EndStr)
                {   
                    position++;
                    if (lexemes[position].Type == LexemeType.NewStr)
                    {
                        str += lexemes[position].Token;
                        position++;
                        DEF(dataGridView1);
                    }
                }
                else if (lexemes[position].Type != LexemeType.Invalid)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    NUMBERREM(dataGridView1);
                }
                
            }
            catch (ArgumentOutOfRangeException)
            {
            }

        }
    }
}
