﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Generator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SchemaModelContainer"].ConnectionString;
        }
    }
}
