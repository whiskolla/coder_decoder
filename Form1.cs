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

        Dictionary<char, int> alphabet = new Dictionary<char, int>(){
/*                { 1, 'א'},
                { 2, 'ב'},
                { 3, 'ג'},
                { 4, 'ד'},
                { 5, 'ה'},
                { 6, 'ו'},
                { 7, '¸'},
                { 8, 'ז'},
                { 9, 'ח'},
                { 10, 'ט'},
                { 11, 'י'},
                { 12, 'ך'},
                { 13, 'כ'},
                { 14, 'ל'},
                { 15, 'ם'},
                { 16, 'מ'},
                { 17, 'ן'},
                { 18, 'נ'},
                { 19, 'ס'},
                { 20, 'ע'},
                { 21, 'ף'},
                { 22, 'פ'},
                { 23, 'ץ'},
                { 24, 'צ'},
                { 25, 'ק'},
                { 26, 'ר'},
                { 27, 'ש'},
                { 28, 'ת'},
                { 29, 'û'},
                { 30, 'ü'},
                { 31, '‎'},
                { 32, '‏'},
                { 33, 'ÿ'},*/
                {'א',1},
                {'ב',2},
                { 'ג',3},
                { 'ד',4},
                { 'ה',5},
                { 'ו',6},
                { '¸',7},
                { 'ז',8},
                { 'ח',9},
                { 'ט',10},
                { 'י',11},
                { 'ך',12},
                { 'כ',13},
                { 'ל',14},
                { 'ם',15},
                { 'מ',16},
                { 'ן',17},
                { 'נ',18},
                { 'ס',19},
                { 'ע',20},
                { 'ף',21},
                { 'פ',22},
                { 'ץ',23},
                { 'צ',24},
                { 'ק',25},
                { 'ר',26},
                { 'ש',27},
                { 'ת',28},
                { 'û',29},
                { 'ü',30},
                { '‎',31},
                { '‏',32},
                {'ÿ',33}

        };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //חארטפנמגאעü
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
            //נאסרטפנמגאעü
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