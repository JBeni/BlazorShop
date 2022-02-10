namespace BlazorShop.WebClient.Pages.Admin.Todos
{
    public partial class TodoState
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        [Inject] public ITodoListService TodoListService { get; set; }

        [Inject] public ITodoItemService TodoItemService { get; set; }

        [Inject] public IJSInProcessRuntime JS { get; set; }

        public ICollection<TodoListResponse> TodoLists { get; set; }

        private TodoListResponse _selectedList;

        public TodoListResponse SelectedList
        {
            get { return _selectedList; }
            set
            {
                _selectedList = value;
                StateHasChanged();
            }
        }

        public void SyncList()
        {
            var list = TodoLists.First(l => l.Id == SelectedList.Id);

            list.Title = SelectedList.Title;
            StateHasChanged();
        }

        public async Task DeleteList()
        {
            var list = TodoLists.First(l => l.Id == SelectedList.Id);
            TodoLists.Remove(list);

            SelectedList = await TodoListService.GetTodoListAsync(TodoLists.First().Id);
            StateHasChanged();
        }

        public bool Initialised { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TodoLists = await TodoListService.GetTodoListsAsync();
            SelectedList = await TodoListService.GetTodoListAsync(TodoLists.First().Id);
            Initialised = true;
        }
    }
}
