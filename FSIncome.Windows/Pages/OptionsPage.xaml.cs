﻿using FSIncome.Core;
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

namespace FSIncome.Windows.Pages
{
    public partial class OptionsPage : Page
    {
        //default values
        private string currencyDefault { get; } = "PLN";
        private string daysDefault { get; } = "12";

        public bool goBack { get; set; } = false;

        public OptionsPage()
        {
            InitializeComponent();
        }

        private void CurrencyPlnClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = "PLN";
            ExpanderCurrency.IsExpanded = false;
        }
        private void CurrencyEuroClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = "EUR";
            ExpanderCurrency.IsExpanded = false;
        }
        private void CurrencyGbpClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = "GBP";
            ExpanderCurrency.IsExpanded = false;
        }
        private void Days6Click(object sender, RoutedEventArgs e)
        {
            ExpanderDays.Header = "6";
            ExpanderDays.IsExpanded = false;
        }
        private void Days9Click(object sender, RoutedEventArgs e)
        {
            ExpanderDays.Header = "9";
            ExpanderDays.IsExpanded = false;
        }
        private void Days12Click(object sender, RoutedEventArgs e)
        {
            ExpanderDays.Header = "12";
            ExpanderDays.IsExpanded = false;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNoCancel);
            
            if(result==MessageBoxResult.Yes)
            {
                Dictionary<string, string> settings = new Dictionary<string, string>();
                settings["currency"] = ExpanderCurrency.Header.ToString();
                settings["seasondays"] = ExpanderDays.Header.ToString();

                ResourcesClass.EditConfigFile(ResourcesClass.projectPath, settings);

                goBack = true;
            }
            if (result == MessageBoxResult.No)
            {
                goBack = true;
            }
            
        }
        public void SetValues()
        {
            ExpanderCurrency.Header = ResourcesClass.ReadData(ResourcesClass.configFilePath, "currency");
            ExpanderDays.Header = ResourcesClass.ReadData(ResourcesClass.configFilePath, "seasondays");
        }
        private void DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = currencyDefault;
            ExpanderDays.Header = daysDefault;

            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings["currency"] = ExpanderCurrency.Header.ToString();
            settings["seasondays"] = ExpanderDays.Header.ToString();

            ResourcesClass.EditConfigFile(ResourcesClass.projectPath, settings);
        }
        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings["currency"] = ExpanderCurrency.Header.ToString();
            settings["seasondays"] = ExpanderDays.Header.ToString();

            ResourcesClass.EditConfigFile(ResourcesClass.projectPath, settings);


            goBack = true;
        }
    }
}
