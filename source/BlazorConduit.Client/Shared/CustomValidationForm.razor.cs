using BlazorConduit.Client.Store.State;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Threading.Tasks;

namespace BlazorConduit.Client.Shared
{
    /// <summary>
    /// Code behind for custom validation form markup so that we can utilize the generic TState type constraint.
    /// </summary>
    /// <typeparam name="TState">Inherited state from RootState.</typeparam>
    public partial class CustomValidationForm<TState> : ComponentBase
        where TState : RootState
    {
        public EditContext? EditContext;

        public bool IsValid;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public IState<TState>? State { get; set; }

        [Parameter]
        public object? ValidationObject { get; set; }

        [Parameter]
        public string? ButtonText { get; set; }

        [Parameter]
        public EventCallback<bool> SubmitClickedCallback { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ThrowExceptionIfArgumentIsNull(State);
            ThrowExceptionIfArgumentIsNull(ValidationObject);
            ThrowExceptionIfArgumentIsNull(SubmitClickedCallback);

            await base.OnInitializedAsync();

            // Register the validation display event and initialize the edit context
            IsValid = true;
            EditContext = new EditContext(ValidationObject);
            State!.StateChanged += DisplayValidationErrors;
        }

        public async Task OnSubmitClicked()
        {
            // Do not allow the user to proceed if their are validation edits
            IsValid = !(EditContext is null) && EditContext.Validate();

            await SubmitClickedCallback.InvokeAsync(IsValid);
        }

        private void ThrowExceptionIfArgumentIsNull(object? input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }
        }

        private void DisplayValidationErrors(object sender, TState state)
        {
            IsValid = state.HasCurrentErrors;

            StateHasChanged();
        }
    }
}
