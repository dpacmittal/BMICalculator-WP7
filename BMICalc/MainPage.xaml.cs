using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace BMICalc
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void calculate_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Double h = Convert.ToDouble(si_height_box.Text) / 100.0;
                Double w = Convert.ToDouble(si_weight_box.Text);
                Double bmi = w / (h * h);
                si_bmi_box.Text = Convert.ToString(bmi);
                si_bmi_desc.Text = returnDesc(bmi);
            }
            catch (Exception exc)
            {
                si_bmi_desc.Text = "Invalid Input. Try giving numbers";
            }

        }
        private void metric_calculate_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Double h = Convert.ToDouble(metric_height_box.Text);
                Double w = Convert.ToDouble(metric_weight_box.Text) * 703;
                Double bmi = w / (h * h);
                metric_bmi_box.Text = Convert.ToString(bmi);
                metric_bmi_desc.Text = returnDesc(bmi);

            }
            catch (Exception exc)
            {
                metric_bmi_desc.Text = "Invalid Input. Try giving numbers";
            }
        }
        public string returnDesc(Double bmi)
        {
            if (bmi <= 18.5)
                return "You're underweight";
            else if (bmi <= 24.9)
                return "You're fit";
            else if (bmi <= 29.9)
                return "You're overweight";
            else
                return "You're obese. Go hit the gym, you fatass!";
        }

        private void si_height_box_GotFocus(object sender, RoutedEventArgs e)
        {
            if (si_height_box.Text == "Height in cm")
                si_height_box.Text = "";
        }

        private void si_weight_box_GotFocus(object sender, RoutedEventArgs e)
        {
            if (si_weight_box.Text == "Weight in kg")
                si_weight_box.Text = "";
        }

        private void si_height_box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (si_height_box.Text == "")
                si_height_box.Text = "Height in cm";
        }

        private void si_weight_box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (si_weight_box.Text == "")
                si_weight_box.Text = "Weight in kg";
        }
        private void metric_height_box_GotFocus(object sender, RoutedEventArgs e)
        {
            if (metric_height_box.Text == "Height in inches")
                metric_height_box.Text = "";
        }

        private void metric_weight_box_GotFocus(object sender, RoutedEventArgs e)
        {
            if (metric_weight_box.Text == "Weight in lbs")
                metric_weight_box.Text = "";
        }

        private void metric_height_box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (metric_height_box.Text == "")
                metric_height_box.Text = "Height in inches";
        }

        private void metric_weight_box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (metric_weight_box.Text == "")
                metric_weight_box.Text = "Weight in lbs";
        }
    }
}