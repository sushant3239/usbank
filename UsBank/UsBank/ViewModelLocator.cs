using System;
using UsBank.Container;
using UsBank.Infrastructure;
using UsBank.ViewModels;

namespace UsBank
{
    public class ViewModelLocator
    {
        private ITypeResolver _typeResolver;

        public ViewModelLocator()
        {
            _typeResolver = TypeResolver.Instance;
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return _typeResolver.Resolve<MainPageViewModel>();
            }
        }
    }
}
