using GUI_module.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI_module.ViewModels
{
    /// <summary>
    /// Base class for ViewModels. Provides navigation service and property change notification sending
    /// </summary>
    public class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        /// <summary>
        /// Create a base viewmodel and initialize navigation service 
        /// </summary>
        /// <param name="navigationService">Navigation service</param>
        public BaseViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        /// <summary>
        /// Event for views to see if property was changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify observers that a property was changed.
        /// Usage: call NotifyPropertyChanged(); inside a set method of property.
        /// </summary>
        /// <param name="propertyName">[auto] Name of changed property</param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Navigation service
        /// </summary>
        protected INavigationService navigationService { get; set; }
    }
}
