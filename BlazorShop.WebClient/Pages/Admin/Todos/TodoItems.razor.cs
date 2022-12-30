// <copyright file="TodoItems.razor.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Pages.Admin.Todos
{
    /// <summary>
    /// The todo item model.
    /// </summary>
    public partial class TodoItems
    {
        /// <summary>
        /// Gets or Sets the instance of the <see cref="TodoState"/> to use.
        /// </summary>
        [CascadingParameter]
        public TodoState State { get; set; }

        /// <summary>
        /// Gets or Sets the instance of the <see cref="TodoItemResponse"/> to use.
        /// </summary>
        public TodoItemResponse SelectedItem { get; set; }

        /// <summary>
        /// Gets or Sets the instance of the <see cref="ElementReference"/> to use.
        /// </summary>
        private ElementReference TitleInput { get; set; }

        /// <summary>
        /// Gets or Sets the instance of the <see cref="ElementReference"/> to use.
        /// </summary>
        private ElementReference ListOptionsModal { get; set; }

        /// <summary>
        /// Check if an item is seelcted or not.
        /// </summary>
        /// <param name="item">The todo item.</param>
        /// <returns>A boolean value.</returns>
        public bool IsSelectedItem(TodoItemResponse item)
        {
            return this.SelectedItem == item;
        }

        /// <summary>
        /// Adding an item.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task AddItem()
        {
            var newItem = new TodoItemResponse { ListId = this.State.SelectedList.Id };

            this.State.SelectedList.Items.Add(newItem);
            await this.EditItem(newItem);
        }

        /// <summary>
        /// Mark the todo item as completed.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="args">The event.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task ToggleDone(TodoItemResponse item, ChangeEventArgs args)
        {
            if (args != null && args.Value is bool value)
            {
                item.Done = value;
                await this.State.TodoItemService.PutTodoItemAsync(item);
            }
        }

        /// <summary>
        /// Edit an item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task EditItem(TodoItemResponse item)
        {
            this.SelectedItem = item;

            await Task.Delay(50);
            if (this.TitleInput.Context != null)
            {
                await this.TitleInput.FocusAsync();
            }
        }

        /// <summary>
        /// Saving an item.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task SaveItem()
        {
            if (this.SelectedItem.Id == 0)
            {
                if (string.IsNullOrWhiteSpace(this.SelectedItem.Title))
                {
                    this.State.SelectedList.Items.Remove(this.SelectedItem);
                }
                else
                {
                    var item = await this.State.TodoItemService.PostTodoItemAsync(this.SelectedItem);
                    this.SelectedItem.Id = item.Id;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.SelectedItem.Title))
                {
                    await this.State.TodoItemService.DeleteTodoItemAsync(this.SelectedItem.Id);
                    this.State.SelectedList.Items.Remove(this.SelectedItem);
                }
                else
                {
                    await this.State.TodoItemService.PutTodoItemAsync(this.SelectedItem);
                }
            }
        }

        /// <summary>
        /// Save a list.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task SaveList()
        {
            await this.State.TodoListService.PutTodoListAsync(this.State.SelectedList);

            this.State.JS.InvokeVoid(JsInteropConstants.HideModal, this.ListOptionsModal);
            this.State.SyncList();
        }

        /// <summary>
        /// Delete a list.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task DeleteList()
        {
            await this.State.TodoListService.DeleteTodoListAsync(this.State.SelectedList.Id);

            this.State.JS.InvokeVoid(JsInteropConstants.HideModal, this.ListOptionsModal);
            await this.State.DeleteList();
        }
    }
}
