using BlazorConduit.Client.Models.Articles.Dtos;
using System.Collections.Generic;

namespace BlazorConduit.Client.Models.Articles.ViewModels
{
    public class CommentViewModelList
    {
        public IEnumerable<CommentDto>? Comments { get; set; }
    }
}
