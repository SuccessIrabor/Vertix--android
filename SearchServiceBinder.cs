using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Vertix
{
    class SearchServiceBinder : Binder
    {
        private Service Service;

        public SearchServiceBinder(Service service) {
            this.Service = service;
        }
    }
}