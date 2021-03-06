using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESBevents.Models;

namespace ESBevents.ViewModels
{
	public class EventViewModel : INotifyPropertyChanged
	{
		public EventViewModel()
		{
			_event = new EventModel();
		}

		public EventViewModel(EventlogViewModel _elVM)
		{
			_event = _elVM.SelectedItem.Event;
		}

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string name)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
		#endregion INotifyPropertyChanged implementation

		#region Properties
		private EventModel _event;

		public EventModel Event
		{
			get { return _event; }
			set
			{
				if (_event == value) return;

				_event = value;

				OnPropertyChanged("Event");
			}
		}

		public string TimeLogged { get { return string.Format("{0}", Event.TimeLogged); } }
		public string Job { get { return string.Format("{0}", Event.Job); } }
		public string MessageId { get { return string.Format("{0}", Event.MessageId); } }
		public string SourceClass { get { return string.Format("{0}", Event.SourceClass); } }
		public string SourceMethod { get { return string.Format("{0}", Event.SourceMethod); } }
		public string ConfigName { get { return string.Format("{0}", Event.ConfigName); } }
		public string Text { get { return string.Format("{0}", Event.Text); } }
		public string Type { get { return string.Format("{0}", Event.Type); } }
		public string SessionId { get { return string.Format("{0}", Event.SessionId); } }
		public string TraceCat { get { return string.Format("{0}", Event.TraceCat); } }

		public string TypeImage
		{
			get {
				if (Event.Type != null)
				{
					switch (Event.Type)
					{
						case "1":
							return "led_blue.png";
						case "2":
							return "led_red.png";
						case "3":
							return "led_yellow.png";
						case "4":
							return "led_green.png";
						case "5":
							return "led_blue.png";
						default:
							break;
					}
				}

				return "";
			}
		}

		#endregion Properties
	}
}
