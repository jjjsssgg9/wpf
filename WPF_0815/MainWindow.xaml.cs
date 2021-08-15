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

namespace WPF_0815
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        /*KHAxLib.Form1 khAxCtr = new KHAxLib.Form1();
        private void excuteKHAx(object sender)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host =
            new System.Windows.Forms.Integration.WindowsFormsHost();

            khAxCtr.TopLevel = false;

            host.Child = khAxCtr;

            //this.grid1.Children.Add(host);

            if (khAxCtr.CommConnect() == 0)
            {
                // Connection success
                khAxCtr.addListboxitem("성공");
            }
            else
            {
                // Connection fail
                khAxCtr.addListboxitem("실패 ");
            }
        }*/
        public ICommand ButtonCommand { get; set; }
        public ICommand ButtonExecuteKHAx { get; set; }
        public ICommand CostomCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this; //ui 컨트롤들은 mainwindo의 변수를 바인딩 소스로 쓸 수 있다. 
            ButtonCommand = new RelayCommand(callbutton);// relaycommand에 callbutton를 델리게이트로 등록
            CostomCommand = new RelayCommand(callcostom);// relaycommand에 callcostom를 델리게이트로 등록
            // ButtonExecuteKHAx = new RelayCommand(excuteKHAx);//키움증권 api 호출 커멘드
        }
        public void callcostom(object param)
        {
            MessageBox.Show("call costom command " + param.ToString());
        }
        public void callbutton(object param)
        {
            MessageBox.Show("call button command " + param.ToString());
        }
    }
}
