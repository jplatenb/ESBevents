using System;
using System.Collections.Generic;
using System.Diagnostics;
using ESBevents.Models;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
    public partial class ProcessStartView : ContentPage
	{
		internal ProcessStartViewModel vm;

		public ProcessStartView()
		{
			InitializeComponent();

			vm = new ProcessStartViewModel();

			Initialize();
		}

		public ProcessStartView(CustomerViewModel cvm)
		{
			InitializeComponent();

			vm = new ProcessStartViewModel(cvm);
            vm.Customer = cvm.Customer;
            vm.Customers = cvm.Customers;

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;

			koppelingenList.ItemTapped += (sender, e) =>
			{
                var selected = ((ListView)sender).SelectedItem as KoppelingModel;

				//// NU DE KOPPELING STARTEN
				/// 
				// Dan met de velden de webservice aanroepen.

				//var webSrvc = new GetEventLogWS();
				//var status = await webSrvc.GetEventLogAsync(vm);

				//if (status == HttpStatusCode.Continue)
				//{
				//  // De json die terug komt in vm zetten van door het object door te geven.

				//  await Navigation.PushAsync(new EventlogView(vm));
				//}

				Debug.WriteLine("Start: " + selected.Name);

				((ListView)sender).SelectedItem = null;
			};
		}

		void OnClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new OptionView(vm.Customers));
		}

	}
}