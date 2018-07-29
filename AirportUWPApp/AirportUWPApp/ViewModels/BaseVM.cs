using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
