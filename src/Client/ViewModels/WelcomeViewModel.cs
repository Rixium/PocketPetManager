using System;
using Prism.Mvvm;

namespace Client.ViewModels
{
    public class WelcomeViewModel : BindableBase
    {
        public WelcomeViewModel()
        {
            Console.Write("HI");
        }
    }
}