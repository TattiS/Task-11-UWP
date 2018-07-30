using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace AirportUWPApp.ViewModels
{
    public class BaseVM:INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public void NotifyPropertyChanged(Expression<Func<object>> target)
		{
			if (target != null)
			{
				if (target.Body is MemberExpression body)
				{
					NotifyPropertyChanged(body.Member.Name);
				}
			}
		}
	}
}
