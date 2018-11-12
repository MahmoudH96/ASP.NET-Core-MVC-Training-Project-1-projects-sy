using ChefBox.Cooking.Dto.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.IData.Interfaces
{
    public interface ISharedRepository
    {
        SharedContentDto GetSharedContent();
        HomePageDto GetHomePageContent();
    }
}
