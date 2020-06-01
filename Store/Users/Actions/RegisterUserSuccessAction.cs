using BlazorConduit.Models.Authentication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Store.Users.Actions
{
    public class RegisterUserSuccessAction
    {
        public RegisterUserSuccessAction(ConduitUserViewModel user) =>
            User = user;

        public ConduitUserViewModel User { get; }
    }
}
