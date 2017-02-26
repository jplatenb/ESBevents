﻿using System;
using System.Collections.Generic;
using ESBevents.ViewModels;
using Xamarin.Forms;

namespace ESBevents
{
	public partial class EventlogView : ContentPage
	{
		internal EventlogViewModel vm;

		public EventlogView()
		{
			vm = new EventlogViewModel();

			InitializeComponent();

			Initialize();
		}

		public EventlogView(MainPageViewModel _mpVM)
		{
			InitializeComponent();

			vm = new EventlogViewModel(_mpVM);
			//vm.Zorgverleners = _mpVM.Zorgverleners;

			Initialize();
		}

		void Initialize()
		{
			BindingContext = vm;

			eventList.ItemTapped += (sender, e) =>
			{
				//Navigation.PushAsync(new EventView(vm.SelectedItem.Event));
				Navigation.PushAsync(new EventView());

				((ListView)sender).SelectedItem = null;
			};
		}
	}
}
