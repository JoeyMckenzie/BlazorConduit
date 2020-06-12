using BlazorConduit.Client.Store.State;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Store.Features.Articles
{
    public class ArticlesFeature : Feature<ArticleState>
    {
        public override string GetName() => "Articles";

        protected override ArticleState GetInitialState() =>
            new ArticleState(false, null);
    }
}
