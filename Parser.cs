using System;
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

        public Parser(List<Lexeme> lexemes)
        {
            this.lexemes = lexemes;
            this.position = 0;
            this.counter = 0;
            //expectedLexemes = new List<LexemeType>(); // стек ожидаемых лексем
            //expectedLexemes.Add(LexemeType.Keyword);
            //expectedLexemes.Add(LexemeType.Delimiter);
            //expectedLexemes.Add(LexemeType.Identifier);
            //expectedLexemes.Add(LexemeType.Colon);
            //expectedLexemes.Add(LexemeType.DataType);
            //expectedLexemes.Add(LexemeType.Equally);
            //expectedLexemes.Add(LexemeType.Number);
            //expectedLexemes.Add(LexemeType.Semicolon);
            //foundLexemes = new List<LexemeType>(); // стек обнаруженных лексем
        }

        public void Parse(DataGridView dataGridView1)
        {
            //try
            //{

            //for (int u = 0;u<lexemes.Count;u++)
            //{
            //    if (lexemes[u].Type == LexemeType.Invalid)
            //    {
            //        //position++;
            //        dataGridView1.Rows.Add($"Недопустимый символ в позиции {lexemes[position].StartPosition}");
            //        counter++;

            //    }
            //}
            DEF(dataGridView1);
            //}
            //catch (Exception ex)
            //{
            //    dataGridView1.Rows.Add("Ошибка", ex.Message);
            //}
        }

        private void DEF(DataGridView dataGridView1)
        {
            try
            {
                //if (position == lexemes.Count)
                //{
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 0: ожидался ключевое слово 'const'");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 5: ожидался пробел");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 6: ожидался идентификатор");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 7: ожидался двоеточие");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 8: ожидался тип данных");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 11: ожидалось равно");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 12: ожидалось число");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 13: ожидалась точка с запятой");
                //    counter += 8;
                //}
                //else {

                if (lexemes[position].Type == LexemeType.Keyword)
                {
                    position++;
                    //foundLexemes.Add(LexemeType.Keyword);
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
                    //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался ключевое слово 'const'");
                    DEFREM(dataGridView1);
                }
                //}
            }
            catch (ArgumentOutOfRangeException)
            {
                //position--;
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
                //position--;
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 0: ожидался ключевое слово 'const'");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 5: ожидался пробел");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 6: ожидался идентификатор");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 7: ожидался двоеточие");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 8: ожидался тип данных");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 11: ожидалось равно");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 12: ожидалось число");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции 13: ожидалась точка с запятой");
                //counter += 8;
            }
        }

        private void DEFREM(DataGridView dataGridView1)
        {
            //if (lexemes[position].Type == LexemeType.Keyword)
            //{
            //    position++;
            //    DEFREM();
            //}
            //else
            try
            {
                //if (position == lexemes.Count)
                //{
                //    position--;
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидался пробел");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 2}: ожидался идентификатор");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 3}: ожидался двоеточие");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 4}: ожидался тип данных");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 5}: ожидалось равно");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 6}: ожидалось число");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 7}: ожидалась точка с запятой");
                //    counter += 7;
                //}
                //else
                //{

                if (lexemes[position].Type == LexemeType.Delimiter)
                {
                    position++;
                    //foundLexemes.Add(LexemeType.Delimiter);
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
                    //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался пробел");
                    ID(dataGridView1);
                }
                //}
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
                //position--;
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидался пробел");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 2}: ожидался идентификатор");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 3}: ожидался двоеточие");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 4}: ожидался тип данных");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 5}: ожидалось равно");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 6}: ожидалось число");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 7}: ожидалась точка с запятой");
                //counter += 7;
            }
        }

        private void ID(DataGridView dataGridView1)
        {
            try
            {

                //if (position == lexemes.Count)
                //{
                //    position--;
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидался идентификатор");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 2}: ожидался двоеточие");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 3}: ожидался тип данных");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 6}: ожидалось равно");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 7}: ожидалось число");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 8}: ожидалась точка с запятой");
                //    counter += 6;
                //}
                //else
                //{

                if (lexemes[position].Type == LexemeType.Identifier)
                {
                    position++;
                    //TYPE();
                    //foundLexemes.Add(LexemeType.Identifier);
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
                    //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался идентификатор");
                    IDREM(dataGridView1);
                }
                //}
            }

            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
                //position--;
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидался идентификатор");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 2}: ожидался двоеточие");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 3}: ожидался тип данных");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 6}: ожидалось равно");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 7}: ожидалось число");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 8}: ожидалась точка с запятой");
                //counter += 6;
            }
        }

        private void IDREM(DataGridView dataGridView1)
        {
            //if (lexemes[position].Type == LexemeType.Identifier)
            //{
            //    position++;
            //    IDREM();

            //}
            //else
            try
            {

                //if (position == lexemes.Count)
                //{
                //    position--;
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидался двоеточие");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 2}: ожидался тип данных");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 5}: ожидалось равно");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 6}: ожидалось число");
                //    dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 7}: ожидалась точка с запятой");
                //    counter += 5;
                //}
                //else
                //{

                if (lexemes[position].Type == LexemeType.Colon)
                {
                    position++;
                    //foundLexemes.Add(LexemeType.Colon);
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
                    //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался двоеточие");
                    TYPE(dataGridView1);
                }
            //}
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
                //position--;
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидался двоеточие");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 2}: ожидался тип данных");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 5}: ожидалось равно");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 6}: ожидалось число");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 7}: ожидалась точка с запятой");
                //counter += 5;
            }
}

        private void TYPE(DataGridView dataGridView1)
        {
            try
            {


                if (lexemes[position].Type == LexemeType.DataType)
                {
                    position++;
                    //EQUAL();
                    //foundLexemes.Add(LexemeType.DataType);
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
                    //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался тип данных");
                    TYPEREM(dataGridView1);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
                //position--;
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидался тип данных");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 4}: ожидалось равно");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 5}: ожидалось число");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 6}: ожидалась точка с запятой");
                //counter += 4;
            }
        }

        private void TYPEREM(DataGridView dataGridView1)
        {
            //if (lexemes[position].Type == LexemeType.DataType)
            //{
            //    position++;
            //    TYPEREM();
            //}
            //else

            try
            {
                if (lexemes[position].Type == LexemeType.Delimiter)
                {
                    position++;
                    try
                    {


                        if (lexemes[position].Type == LexemeType.Equally)
                        {
                            position++;
                            //foundLexemes.Add(LexemeType.Equally);
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
                            //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался равно");
                            EQUAL(dataGridView1);
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                        counter++;
                        //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидался равно");
                        //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 2}: ожидалось число");
                        //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 3}: ожидалась точка с запятой");
                        //counter += 3;
                    }
                }

                else if (lexemes[position].Type == LexemeType.Equally)
                {
                    position++;
                    //foundLexemes.Add(LexemeType.Equally);
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
                    //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался равно");
                    EQUAL(dataGridView1);
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
                //position--;
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидался равно");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 2}: ожидалось число");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 3}: ожидалась точка с запятой");
                //counter += 3;
            }

        }

        private void EQUAL(DataGridView dataGridView1)
        {
            if (lexemes[position].Type == LexemeType.Delimiter)
            {
                position++;
                if ((lexemes[position].Type == LexemeType.Plus) || (lexemes[position].Type == LexemeType.Minus))
                {
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
                position++;
                NUMBER(dataGridView1);
            }
            else
            {
                NUMBER(dataGridView1);
            }
            //else
            //{
            //    throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидался знак равенства");
            //}
        }

        private void NUMBER(DataGridView dataGridView1)
        {
            try
            {


                if (lexemes[position].Type == LexemeType.Number)
                {
                    position++;
                    //foundLexemes.Add(LexemeType.Number);
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
                    //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидалось число");
                    NUMBERREM(dataGridView1);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
                //position--;
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидалось число");
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 2}: ожидалась точка с запятой");
                //counter += 2;
            }
        }

        private void NUMBERREM(DataGridView dataGridView1)
        {
            //if (lexemes[position].Type == LexemeType.Number)
            //{
            //    position++;
            //    NUMBERREM();
            //}
            //else
            try
            {
                if (lexemes[position].Type == LexemeType.Semicolon)
                {
                    position++;
                    //foundLexemes.Add(LexemeType.Semicolon);
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
                    //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидалась точка с запятой");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                counter++;
                //position--;
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидалась точка с запятой");
                //counter++;
            }

        }

        private void END(DataGridView dataGridView1)
        {
            //if (lexemes[position].Type == LexemeType.Number)
            //{
            //    position++;
            //    NUMBERREM();
            //}
            //else
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
                        //dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                        //counter++;
                        position++;
                        DEF(dataGridView1);
                    }
                    //dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    //counter++;
                    //position++;
                    //DEF(dataGridView1);
                }
                else if (lexemes[position].Type != LexemeType.Invalid)
                {
                    dataGridView1.Rows.Add($"Отброшенный символ {lexemes[position].Token} в позиции {lexemes[position].StartPosition}");
                    counter++;
                    position++;
                    NUMBERREM(dataGridView1);
                }
                

                //else
                //{
                //    //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидалась точка с запятой");
                //    //counter++;
                //    //throw new Exception($"Ошибка синтаксиса в позиции {lexemes[position].StartPosition}: ожидалась точка с запятой");
                //}
            }
            catch (ArgumentOutOfRangeException)
            {
                //dataGridView1.Rows.Add($"Неожиданный символ '\0'");
                //counter++;
                //position--;
                //dataGridView1.Rows.Add($"Ошибка синтаксиса в позиции {lexemes[position].EndPosition + 1}: ожидалась точка с запятой");
                //counter++;
            }

        }
    }
}
