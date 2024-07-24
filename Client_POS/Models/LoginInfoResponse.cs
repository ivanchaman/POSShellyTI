namespace ShellyPOS.Models
{
    public class LoginInfoResponse
    {
        public string Token { get; set; }
        public long UserNumber { get; set; }
        public string Uuid { get; set; }
        public string Email { get; set; }
        public long Company { get; set; }
        public string QrCodeUrl { get; set; }
        public string SecreteCode { get; set; }
        public byte[] Session { get; set; }
        public int PrimaryTwoFactor { get; set; }
        public bool HasTwoFactor { get; set; }
        public int Status { get; set; }
        public string Left { get; set; }
        public bool HasTermsStatus { get; set; }
        public bool HasUserName { get; set; }
        public string AuthConstant { get; set; }
        public List<TermAndConditionDocumentResponse> TermsServices { get; set; }
    }
}
