using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
using CefSharp.Wpf;
namespace WPF_0815
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public string topstring = "top";
        public string leftstring = "left";
        public string bottomstring = "bottom";

        public ICommand ButtonCommand { get; set; }
        public ICommand ButtonExecuteKHAx { get; set; }
        public ICommand CostomCommand { get; set; }
        AESEncrypt aes = new AESEncrypt();
        public string address {get;set;}
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this; //ui 컨트롤들은 mainwindo의 변수를 바인딩 소스로 쓸 수 있다. 
            ButtonCommand = new RelayCommand(callbutton);// relaycommand에 callbutton를 델리게이트로 등록
            address = "www.naver.com";
        }
        public void callcostom(object param)
        {
            MessageBox.Show("call costom command " + param.ToString());
        }
        public void callbutton(object param)
        {
            MessageBox.Show("입력된 주소는 : "+address);
        }
    }
}
