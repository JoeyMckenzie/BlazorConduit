using BlazorConduit.Client.Store.State;
using Fluxor;

namespace BlazorConduit.Client.Store.Features.Articles
{
    public class ArticlesFeature : Feature<ArticleState>
    {
        public override string GetName() => "Articles";

        protected override ArticleState GetInitialState() =>
            new ArticleState(false, null, null, null, null, null, null, 0);
    }
}
