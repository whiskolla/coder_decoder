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
            Microsoft.Office.Interop.Excel.Application ObjWorkExcel = new Microsoft.Office.Interop.Excel.Application(); //������� ������
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(@"C:\Users\Anastasia\Desktop\����� 6 ���\FaLP_1\alphabet.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //������� ����
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1]; //�������� 1 ����
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell);//1 ������
            string[,] list = new string[lastCell.Column, lastCell.Row]; // ������ �������� � ����� ����� �� ������� �����
            char ch = ' ';
            int integ = -1;
            for (int i = 0; i < lastCell.Column; i++) {  //�� ���� �������
                for (int j = 0; j < lastCell.Row; j++) {  // �� ���� �������
                    list[i, j] = ObjWorkSheet.Cells[j + 1, i + 1].Text.ToString();//��������� ����� � ������
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

            ObjWorkBook.Close(false, Type.Missing, Type.Missing); //������� �� ��������
            ObjWorkExcel.Quit(); // ����� �� ������
            GC.Collect(); // ������ �� �����
        }

/* Dictionary<char, int> aalphabet = new Dictionary<char, int>(){
               { 1, '�'},
                { 2, '�'},
                { 3, '�'},
                { 4, '�'},
                { 5, '�'},
                { 6, '�'},
                { 7, '�'},
                { 8, '�'},
                { 9, '�'},
                { 10, '�'},
                { 11, '�'},
                { 12, '�'},
                { 13, '�'},
                { 14, '�'},
                { 15, '�'},
                { 16, '�'},
                { 17, '�'},
                { 18, '�'},
                { 19, '�'},
                { 20, '�'},
                { 21, '�'},
                { 22, '�'},
                { 23, '�'},
                { 24, '�'},
                { 25, '�'},
                { 26, '�'},
                { 27, '�'},
                { 28, '�'},
                { 29, '�'},
                { 30, '�'},
                { 31, '�'},
                { 32, '�'},
                { 33, '�'},
                {'�',1},
                {'�',2},
                { '�',3},
                { '�',4},
                { '�',5},
                { '�',6},
                { '�',7},
                { '�',8},
                { '�',9},
                { '�',10},
                { '�',11},
                { '�',12},
                { '�',13},
                { '�',14},
                { '�',15},
                { '�',16},
                { '�',17},
                { '�',18},
                { '�',19},
                { '�',20},
                { '�',21},
                { '�',22},
                { '�',23},
                { '�',24},
                { '�',25},
                { '�',26},
                { '�',27},
                { '�',28},
                { '�',29},
                { '�',30},
                { '�',31},
                { '�',32},
                {'�',33}

        };*/

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //�����������
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
            //������������
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