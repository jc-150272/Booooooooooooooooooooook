﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace book3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyPage : ContentPage
    {
        public PropertyPage()
        {
            InitializeComponent();
        }
        

        private void Backup(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BackupPage());
        }
        private void Help(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }
        
    }
}