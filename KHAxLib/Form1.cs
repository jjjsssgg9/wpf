using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHAxLib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int CommConnect()
        {
            int result = axKHOpenAPI1.CommConnect();

            listBox1.Items.Clear();
            //clearListboxitem();

            if (result == 0)
                addListboxitem("로그인 시작");
            else
                addListboxitem("로그인 실패");
            return result;

        }
        public void addListboxitem(string str)
        {
            listBox1.Items.Add(str);
        }
    }
}
