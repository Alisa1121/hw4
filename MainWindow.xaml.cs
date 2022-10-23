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

namespace hw4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> foods = new Dictionary<string, int>();
        int[] order = new int[6];
        public MainWindow()
        {
            InitializeComponent();
            AddNewFood(foods);
        }

        private void AddNewFood(Dictionary<string, int> myFood)
        {
            myFood.Add("大麥克漢堡(套餐)", 150);
            myFood.Add("大麥克漢堡(單點)", 90);
            myFood.Add("麥香雞漢堡(套餐)", 140);
            myFood.Add("麥香雞漢堡(單點)", 80);
            myFood.Add("雙層牛肉堡(套餐)", 160);
            myFood.Add("雙層牛肉堡(單點)", 100);
        }
        private void Button()
        {
            bool success = int.TryParse(sum1.Text, out order[0]);
            success = int.TryParse(sum2.Text, out order[1]);
            success = int.TryParse(sum3.Text, out order[2]);
            success = int.TryParse(sum4.Text, out order[3]);
            success = int.TryParse(sum5.Text, out order[4]);
            success = int.TryParse(sum6.Text, out order[5]);
        }

        private void PlaceOrder(object sender, TextChangedEventArgs e)
        {
            var targetTextBox = sender as TextBox;
            bool success = int.TryParse(targetTextBox.Text, out int count);
            if (!success)
            {
                MessageBox.Show("請輸入整數", "輸入錯誤");
            }
            else if (count <= 0)
            {
                MessageBox.Show("請輸入正整數", "輸入錯誤");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button();
            sum7.Text = "";
            int sumx = 0, i = 0;
            foreach (var item in foods)
            {
                if (order[i] > 0)
                {
                    sum7.Text += $"{item.Key}X{order[i]}={order[i] * item.Value}元\n";
                    sumx = sumx + (order[i] * item.Value);
                }
                i++;
            }
            sum7.Text += $"總共{sumx}元";
            int end_sum;
            if (sumx >= 1000)
            {
                end_sum = (int)(sumx * 0.85);
                sum7.Text += $"，折扣後總價為{end_sum}元\n";
            }
            else if (sumx >= 500)
            {
                end_sum = (int)(sumx * 0.9);
                sum7.Text += $"，折扣後總價為{end_sum}元\n";
            }
            else
            {
                sum7.Text += "\n";
            }
            sum7.Text += $"獲得回饋點數{(int)(sumx * 0.1)}點\n";
        }
    }
}
