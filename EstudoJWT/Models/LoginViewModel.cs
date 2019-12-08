using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstudoJWT.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool AutenticacaoExterna { get; set; }
    }
}