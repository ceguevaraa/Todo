using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Lists.Commands.CreateItem;
using Todo.Application.Lists.Commands.DeleteItem;
using Todo.Application.Lists.Commands.UpdateItem;
using Todo.Application.Lists.Queries.GetTodoItemDetail;
using Todo.Application.Lists.Queries.GetTodoItems;
using Todo.Application.Progressions.Commands.CreateProgression;

namespace Todo.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IGetTodoItemsQuery _listQuery;
        private readonly IGetTodoItemDetailQuery _detailQuery;
        private readonly ICreateItemCommand _createCommand;
        private readonly IUpdateItemCommand _updateCommand;
        private readonly IDeleteItemCommand _deleteCommand;

        private readonly ICreateProgressionCommand _createProgressionCommand;


        public TodoController(
            IGetTodoItemsQuery listQuery,
            IGetTodoItemDetailQuery detailQuery,
            ICreateItemCommand createCommand,
            IUpdateItemCommand updateCommand,
            IDeleteItemCommand deleteCommand,
            ICreateProgressionCommand createProgressionCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
            _createProgressionCommand = createProgressionCommand;
        }

        #region TodoItems
        [HttpGet]
        public IEnumerable<TodoItemModel> Get()
        {
            return _listQuery.Execute();
        }

        [HttpGet("{id}")]
        public TodoItemDetailModel Get(int id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateItemModel item)
        {
            _createCommand.Execute(item);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Update(UpdateItemModel item)
        {
            _updateCommand.Execute(item);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int itemId)
        {
            _deleteCommand.Execute(itemId);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        #endregion TodoItems

        #region Progressions

        [HttpGet("{id}/progressions")]
        public TodoItemDetailModel GetProgressions(int id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost("{id}/progressions")]
        public HttpResponseMessage CreateProgression(int id, CreateProgressionRequest request)
        {
            var model = new CreateProgressionModel
            {
                TodoItemId = id,
                CreatedAt = request.CreatedAt,
                Percentage = request.Percentage
            };

            _createProgressionCommand.Execute(model);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        #endregion Progressions





    }
}
