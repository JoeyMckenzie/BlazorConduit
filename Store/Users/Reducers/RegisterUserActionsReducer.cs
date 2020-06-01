using BlazorConduit.Store.Users.Actions;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Store.Users.Reducers
{
    public static class RegisterUserActionsReducer
    {
        [ReducerMethod]
        public static AppState ReduceRegisterUserAction(AppState state, RegisterUserAction action) =>
            new AppState(true, null, string.Empty);

        [ReducerMethod]
        public static AppState ReduceRegisterUserSuccessAction(AppState state, RegisterUserSuccessAction action) =>
            new AppState(false, action.User, string.Empty);
    }
}
