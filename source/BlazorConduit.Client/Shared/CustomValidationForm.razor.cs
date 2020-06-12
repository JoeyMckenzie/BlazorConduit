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
        public EditContext? editContext;

        public bool isValid = true;

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
            State!.StateChanged += DisplayValidationErrors;
            editContext = new EditContext(ValidationObject);
        }

        public async Task OnSubmitClicked()
        {
            // Do not allow the user to proceed if their are validation edits
            isValid = !(editContext is null) && editContext.Validate();

            await SubmitClickedCallback.InvokeAsync(isValid);
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
            isValid = state.HasCurrentErrors;

            StateHasChanged();
        }
    }
}
