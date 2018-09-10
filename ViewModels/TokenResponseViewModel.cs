
using Newtonsoft.Json;

namespace JobberApp.ViewModels
{
    // [JsonObject(MemberSerialization.OptOut)]
    public class TokenResponseViewModel
    {
        #region Constructor
        public TokenResponseViewModel() { }
        #endregion

        #region Properties
        public string Token { get; set; }
        public int Expiration { get; set; }
        public string RefreshToken { get; set; }
        public string DisplayName { get; set; }
        #endregion
    }
}