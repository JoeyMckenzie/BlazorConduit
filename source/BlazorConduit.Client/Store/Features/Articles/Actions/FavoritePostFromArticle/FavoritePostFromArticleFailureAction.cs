using BlazorConduit.Client.Store.Features.Shared.Actions;
using System.Collections.Generic;

namespace BlazorConduit.Client.Store.Features.Articles.Actions.FavoritePostFromArticle
{
    public class FavoritePostFromArticleFailureAction : FailureAction
    {
        public FavoritePostFromArticleFailureAction(string reasonForFailure, IEnumerable<string>? errors = null) 
            : base(reasonForFailure, errors)
        {
        }
    }
}
