using Newtonsoft.Json;

namespace JobberApp.ViewModels
{
    // [JsonObject(MemberSerialization.OptOut)]
    public class TokenRequestViewModel
    {
        #region Constructor
        public TokenRequestViewModel() { }
        #endregion

        #region Properties
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        #endregion
    }
}