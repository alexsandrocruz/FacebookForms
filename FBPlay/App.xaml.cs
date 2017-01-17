﻿using Xamarin.Forms;
using System.Reflection;
using System.Linq;

namespace FBPlay
{
    public partial class App : Application
    {
        public static double Width { get; set; }
        public static double Height { get; set; }

        public App()
        {
            InitializeComponent();

            LoadDynamicResources(new DynamicResources());

            MainPage = new HomeWallPage();
        }

        void LoadDynamicResources(IDynamicResources resources)
        {
            if (Resources == null)
                Resources = new ResourceDictionary();

            var properties = resources.GetType().GetRuntimeProperties();
            foreach (var prop in properties)
            {
                Resources.Add(prop.Name, prop.GetValue(resources));
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}