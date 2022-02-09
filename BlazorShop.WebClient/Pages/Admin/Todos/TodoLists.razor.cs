namespace BlazorShop.WebClient.Pages.Admin.Todos
{
    public partial class TodoLists
    {
        [CascadingParameter] public TodoState State { get; set; }

        private ElementReference _titleInput;

        private ElementReference _newListModal;

        private TodoListResponse _newTodoList = new();

        private CustomValidation _customValidation;

        private async Task NewList()
        {
            _newTodoList = new TodoListResponse();

            await Task.Delay(500);

            if (_titleInput.Context != null)
            {
                await _titleInput.FocusAsync();
            }
        }

        private async Task CreateNewList()
        {
            _customValidation.ClearErrors();

            try
            {
                var list = await State.TodoListService.PostTodoListAsync(_newTodoList);

                State.TodoLists.Add(list);

                await SelectList(list);

                State.JS.InvokeVoid(JsInteropConstants.HideModal, _newListModal);
            }
            finally
            {
            }
        }

        private bool IsSelected(TodoListResponse list)
        {
            return State.SelectedList.Id == list.Id;
        }

        private async Task SelectList(TodoListResponse list)
        {
            if (IsSelected(list)) return;

            State.SelectedList = await State.TodoListService.GetTodoListAsync(list.Id);
        }
    }
}
