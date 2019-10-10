using System;


namespace Frameworks
{
    public class BasePage : Base
    {

        public BasePage(CurrentTest currenttest) : base(currenttest)
        {}

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

        public TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage), CTest);
        }


    }
}
