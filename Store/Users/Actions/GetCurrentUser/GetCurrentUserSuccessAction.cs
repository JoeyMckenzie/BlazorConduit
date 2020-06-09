using BlazorConduit.Models.Authentication.Dtos;
using BlazorConduit.Models.Authentication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Store.Users.Actions.GetCurrentUser
{
    public class GetCurrentUserSuccessAction
    {
        public GetCurrentUserSuccessAction(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
