using ChefBox.AdminUI.ViewModels.Base;
using ChefBox.Cooking.Data.Repositories;
using ChefBox.Cooking.IData.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefBox.AdminUI.Controllers
{
    public abstract class ChefBoxController:Controller
    {
        public ISharedRepository SharedRepository { get; }

        protected ChefBoxController(ISharedRepository sharedRepository)
        {
            SharedRepository = sharedRepository;
        }

        public override ViewResult View(object model)
        {
            FillBaseViewModel(model);
            return base.View(model);
        }
        public override ViewResult View(string viewName, object model)
        {
            FillBaseViewModel(model);
            return base.View(viewName, model);
        }

        private void FillBaseViewModel(object viewModel)
        {
            if(viewModel is ChefBoxViewModel)
            {
                var vm = viewModel as ChefBoxViewModel;
                vm.SharedContentDto = SharedRepository.GetSharedContent();
            }
        }
    }
}
