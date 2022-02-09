namespace BlazorShop.WebClient.Pages.Admin.Todos
{
    public partial class TodoItems
    {
        [CascadingParameter] public TodoState State { get; set; }

        public TodoItemResponse SelectedItem { get; set; }

        private ElementReference _titleInput;

        private ElementReference _listOptionsModal;

        public bool IsSelectedItem(TodoItemResponse item)
        {
            return SelectedItem == item;

        }

        private async Task AddItem()
        {
            var newItem = new TodoItemResponse { ListId = State.SelectedList.Id };

            State.SelectedList.Items.Add(newItem);

            await EditItem(newItem);
        }

        private async Task ToggleDone(TodoItemResponse item, ChangeEventArgs args)
        {
            if (args != null && args.Value is bool value)
            {
                item.Done = value;

                await State.TodoItemService.PutTodoItemAsync(item);
            }
        }

        private async Task EditItem(TodoItemResponse item)
        {
            SelectedItem = item;

            await Task.Delay(50);

            if (_titleInput.Context != null)
            {
                await _titleInput.FocusAsync();
            }
        }

        private async Task SaveItem()
        {
            if (SelectedItem.Id == 0)
            {
                if (string.IsNullOrWhiteSpace(SelectedItem.Title))
                {
                    State.SelectedList.Items.Remove(SelectedItem);
                }
                else
                {
                    var item = await State.TodoItemService.PostTodoItemAsync(SelectedItem);
                    SelectedItem.Id = item.Id;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(SelectedItem.Title))
                {
                    await State.TodoItemService.DeleteTodoItemAsync(SelectedItem.Id);
                    State.SelectedList.Items.Remove(SelectedItem);
                }
                else
                {
                    await State.TodoItemService.PutTodoItemAsync(SelectedItem);
                }
            }
        }

        private async Task SaveList()
        {
            await State.TodoListService.PutTodoListAsync(State.SelectedList);

            State.JS.InvokeVoid(JsInteropConstants.HideModal, _listOptionsModal);

            State.SyncList();
        }

        private async Task DeleteList()
        {
            await State.TodoListService.DeleteTodoListAsync(State.SelectedList.Id);

            State.JS.InvokeVoid(JsInteropConstants.HideModal, _listOptionsModal);

            await State.DeleteList();
        }
    }
}
