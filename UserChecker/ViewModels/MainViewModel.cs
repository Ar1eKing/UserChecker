using System;
using System.Linq;
using UserChecker.Models;
using System.Windows.Input;
using System.Threading.Tasks;

namespace UserChecker
{
    public class MainViewModel : BaseVeiwModel
    {
        #region Commands

        public ICommand SearchCommand { get; set; }
        public ICommand RenderCommand { get; set; }

        #endregion

        #region Parameters

        private UserInfo _user;
        public UserInfo User
        {
            get { return _user; }
            set { Set(ref _user, value); }
        }

        private string _htmlContent;
        public string HtmlContent
        {
            get { return _htmlContent; }
            set { Set(ref _htmlContent, value); }
        }

        private Signature _selectedSignature;
        public Signature SelectedSignature
        {
            get { return _selectedSignature; }
            set { Set(ref _selectedSignature, value); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { Set(ref _errorMessage, value); }
        }

        private bool _errorIsVisible;
        public bool ErrorIsVisible
        {
            get { return _errorIsVisible; }
            set { Set(ref _errorIsVisible, value); }
        }

        private bool _searchResultIsVisible;
        public bool SearchResultIsVisible
        {
            get { return _searchResultIsVisible; }
            set { Set(ref _searchResultIsVisible, value); }
        }

        private bool _renderIsVisible;
        public bool RenderIsVisible
        {
            get { return _renderIsVisible; }
            set { Set(ref _renderIsVisible, value); }
        }

        #endregion

        public MainViewModel()
        {
            SearchCommand = new Command(async () => await SearchAsync());
            RenderCommand = new Command(async () => await RenderAsync());

            User = new UserInfo();
            SearchResultIsVisible = false;
            RenderIsVisible = false;

            User.UserId = "5059537892278272";
        }

        private async Task SearchAsync()
        {
            try
            {
                var response = await WebApi.SearchUser(User.UserId);
                if (response == null)
                    return;

                RenderIsVisible = false;

                if (!Convert.ToBoolean(response.Result))
                {
                    ErrorIsVisible = true; ;
                    ErrorMessage = response.Error;
                    SearchResultIsVisible = false;
                }
                else
                {
                    ErrorIsVisible = false;
                    SearchResultIsVisible = true;
                    User = response;
                    SelectedSignature = User.Signatures.Values.First();
                }
            }
            catch (Exception)
            {
                ErrorMessage = "Problem with server connection!";
                ErrorIsVisible = true;
            }
        }

        private async Task RenderAsync()
        {
            try
            {
                var response = await WebApi.RenderRequest(SelectedSignature.Id);
                ErrorIsVisible = false;
                RenderIsVisible = true;
                HtmlContent = response.Html;
            }
            catch (Exception)
            {
                ErrorMessage = "Problem with server connection!";
                ErrorIsVisible = true;
            }
        }
    }
}