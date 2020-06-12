using BlazorConduit.Client.Models.Authentication.Dtos;
using BlazorConduit.Client.Models.Authentication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Users.Actions.GetCurrentUser
{
    public class GetCurrentUserSuccessAction
    {
        public GetCurrentUserSuccessAction(ConduitUserDto user) =>
            User = user;

        public ConduitUserDto User { get; }
    }
}
