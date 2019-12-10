using CommonModels;
using Prism.Events;
using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    public class ModuleAViewModel : BindableBase
    {
        public ModuleAViewModel(){  }

        IEventAggregator _ea;

        public ModuleAViewModel(CommonModel cModel, IEventAggregator ea)
        {
            MyCModel = cModel;

            _ea = ea;
            _ea.GetEvent<LanguageChangeEvent>().Subscribe(ChangedLang);

            //TabItemのHeaderになる言葉を多言語設定の為Resoucesから取り出す
            Title = CommonModel.GetLocalizedValue<string>("TITLEMA");
        }

        private string _title;
        /// <summary>
        /// TabItemのHeaderにバインドされる
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// 言語設定が変わった時の処理
        /// </summary>
        public void ChangedLang()
        {
            Title = CommonModel.GetLocalizedValue<string>("TITLEMA");
        }

        private CommonModel myCModel;
        /// <summary>
        /// アプリの共有モデル
        /// </summary>
        public CommonModel MyCModel
        {
            get { return myCModel; }
            set { SetProperty(ref myCModel, value); }
        }

    }
}
