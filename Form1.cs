using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace FaLP_1
{

    public partial class Form1 : Form
    {
        public string IntArrayToString(int[] ints)
        {
            return string.Join(" ", ints.Select(x => x.ToString()).ToArray());
        }
        public string CharArrayToString(char[] ints)
        {
            return string.Join(" ", ints.Select(x => x.ToString()).ToArray());
        }
        public int[] StringToIntArr(string stringOfInteger)
        {
            int[] intArray = stringOfInteger.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            return intArray; 
            /*            int[] arr = stringOfInteger.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();
                        return arr;*/
        }
        public char FindForValue(int i)
        {
            char k = alphabet.Where(x => x.Value == i).FirstOrDefault().Key;
            return k;
        }
        public Dictionary<char, int> alphabet = new Dictionary<char, int>();
        public void WorkingExcel() {
            Dictionary<char, int> alfavit = new Dictionary<char, int>();
            Microsoft.Office.Interop.Excel.Application ObjWorkExcel = new Microsoft.Office.Interop.Excel.Application(); //открыть эксель
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(@"C:\Users\Anastasia\Desktop\учеба 6 сем\FaLP_1\alphabet.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1 лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell);//1 €чейку
            string[,] list = new string[lastCell.Column, lastCell.Row]; // массив значений с листа равен по размеру листу
            char ch = ' ';
            int integ = -1;
            for (int i = 0; i < lastCell.Column; i++) {  //по всем колонам
                for (int j = 0; j < lastCell.Row; j++) {  // по всем строкам
                    list[i, j] = ObjWorkSheet.Cells[j + 1, i + 1].Text.ToString();//считываем текст в строку
                    if (j == 0)
                    {
                        ch = char.Parse(list[i, j]);
                    }
                    if (j == 1)
                    {
                        integ = int.Parse(list[i, j]);
                    }
                }
                if ((ch != ' ') && (integ != -1))
                {
                    alfavit.Add(ch, integ);
                }
                ch = ' ';
                integ = -1;
            }
            alphabet = alfavit;

            ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохран€€
            ObjWorkExcel.Quit(); // выйти из эксел€
            GC.Collect(); // убрать за собой
        }

/* Dictionary<char, int> aalphabet = new Dictionary<char, int>(){
               { 1, 'а'},
                { 2, 'б'},
                { 3, 'в'},
                { 4, 'г'},
                { 5, 'д'},
                { 6, 'е'},
                { 7, 'Є'},
                { 8, 'ж'},
                { 9, 'з'},
                { 10, 'и'},
                { 11, 'й'},
                { 12, 'к'},
                { 13, 'л'},
                { 14, 'м'},
                { 15, 'н'},
                { 16, 'о'},
                { 17, 'п'},
                { 18, 'р'},
                { 19, 'с'},
                { 20, 'т'},
                { 21, 'у'},
                { 22, 'ф'},
                { 23, 'х'},
                { 24, 'ц'},
                { 25, 'ч'},
                { 26, 'ш'},
                { 27, 'щ'},
                { 28, 'ъ'},
                { 29, 'ы'},
                { 30, 'ь'},
                { 31, 'э'},
                { 32, 'ю'},
                { 33, '€'},
                {'а',1},
                {'б',2},
                { 'в',3},
                { 'г',4},
                { 'д',5},
                { 'е',6},
                { 'Є',7},
                { 'ж',8},
                { 'з',9},
                { 'и',10},
                { 'й',11},
                { 'к',12},
                { 'л',13},
                { 'м',14},
                { 'н',15},
                { 'о',16},
                { 'п',17},
                { 'р',18},
                { 'с',19},
                { 'т',20},
                { 'у',21},
                { 'ф',22},
                { 'х',23},
                { 'ц',24},
                { 'ч',25},
                { 'ш',26},
                { 'щ',27},
                { 'ъ',28},
                { 'ы',29},
                { 'ь',30},
                { 'э',31},
                { 'ю',32},
                {'€',33}

        };*/

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //зашифровать
            WorkingExcel();
            var text = textBox1.Text;
            char[] textt = new char[text.Length];
            int[] result = new int[text.Length];
            textt = text.ToCharArray();
    
            for (int i = 0; i < text.Length; i++)
            {
                 result[i] = alphabet[textt[i]];  
            }
            string answer = IntArrayToString(result);
            textBox1.Text = answer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //расшифровать
            WorkingExcel();
            var text = textBox1.Text;
            char[] result = new char[text.Length];
            int[] textt = new int[text.Length];
            textt = StringToIntArr(text);

            for (int i = 0; i < textt.Length; i++)
            {
                result[i] = alphabet.Where(x => x.Value == textt[i]).FirstOrDefault().Key;
            }
            string answer = CharArrayToString(result);
            textBox1.Text = answer;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }
    }
}