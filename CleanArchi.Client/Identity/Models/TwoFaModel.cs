using System;

namespace CleanArchi.Client.Identity.Models
{
    public class TwoFaModel
    {
        public string SharedKey { get; set; } = "";
        public int recoveryCodesLeft { get; set; }
        public IEnumerable<string> RecoveryCodes { get; set; }= new List<string>();
        public bool IsTwoFactorEnabled { get; set; }
        public bool IsMachineRemembered { get; set; }
    }
}
