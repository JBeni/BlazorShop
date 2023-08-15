// <copyright file="TodoState.razor.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Pages.Admin.Todos
{
    /// <summary>
    /// The todos state model.
    /// </summary>
    public partial class TodoState
    {
        /// <summary>
        /// Gets or sets the instance of the <see cref="RenderFragment"/> to use.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Gets or sets the instance of the <see cref="ITodoListService"/> to use.
        /// </summary>
        [Inject]
        public ITodoListService TodoListService { get; set; }

        /// <summary>
        /// Gets or sets the instance of the <see cref="ITodoItemService"/> to use.
        /// </summary>
        [Inject]
        public ITodoItemService TodoItemService { get; set; }

        /// <summary>
        /// Gets or sets the instance of the <see cref="IJSInProcessRuntime"/> to use.
        /// </summary>
        [Inject]
        public IJSInProcessRuntime JS { get; set; }

        /// <summary>
        /// Gets or sets the instance of the <see cref="ICollection{TodoListResponse}"/> to use.
        /// </summary>
        public ICollection<TodoListResponse> TodoLists { get; set; }

        /// <summary>
        /// Gets or sets the instance of the <see cref="TodoListResponse"/> to use.
        /// </summary>
        public TodoListResponse SelectedList
        {
            get
            {
                return this.SelectedListPriv;
            }

            set
            {
                this.SelectedListPriv = value;
                this.StateHasChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the todo is initialised or not.
        /// </summary>
        public bool Initialised { get; set; }

        /// <summary>
        /// Gets or sets the instance of the <see cref="TodoListResponse"/> to use.
        /// </summary>
        private TodoListResponse SelectedListPriv { get; set; }

        /// <summary>
        /// Synch the list.
        /// </summary>
        public void SyncList()
        {
            var list = this.TodoLists.First(l => l.Id == this.SelectedList.Id);

            list.Title = this.SelectedList.Title;
            this.StateHasChanged();
        }

        /// <summary>
        /// Delete a todo list.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task DeleteList()
        {
            var list = this.TodoLists.First(l => l.Id == this.SelectedList.Id);
            this.TodoLists.Remove(list);

            this.SelectedList = await this.TodoListService.GetTodoListAsync(this.TodoLists.First().Id);
            this.StateHasChanged();
        }

        /// <summary>
        /// Initialize the component on load.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        protected override async Task OnInitializedAsync()
        {
            this.TodoLists = await this.TodoListService.GetTodoListsAsync();
            this.SelectedList = await this.TodoListService.GetTodoListAsync(this.TodoLists.First().Id);
            this.Initialised = true;
        }
    }
}
