namespace CleanArchi.Client.Identity.Models
{
    public class TwoFactorConfig
    {
        public bool Enable { get; set; }
        public string TwoFactorCode { get; set; } = "";
        public bool ResetSharedKey { get; set; } = false;
        public bool ResetRecoveryCodes { get; set; } = false;
        public bool ForgetMachine { get; set; } = false;
}

}
