using BlazorConduit.Client.Models.Articles.Dtos;
using System.Collections.Generic;

namespace BlazorConduit.Client.Models.Articles.ViewModels
{
    public class ArticleViewModelList
    {
        public IEnumerable<ArticleDto>? Articles { get; set; }

        public int ArticlesCount { get; set; }
    }
}
