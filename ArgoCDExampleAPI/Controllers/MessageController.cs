using Microsoft.AspNetCore.Mvc;

namespace ArgoCDExampleAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MessageController : ControllerBase
	{
		private static readonly List<Message> Messages = new List<Message>
		{
			new Message { Id = 1, Content = "Hello, world!" },
			new Message { Id = 2, Content = "Welcome to the Simple API!" }
		};

		[HttpGet]
		public ActionResult<IEnumerable<Message>> GetMessages()
		{
			return Messages;
		}

		[HttpGet("{id}")]
		public ActionResult<Message> GetMessage(int id)
		{
			var message = Messages.Find(m => m.Id == id);
			if (message == null)
			{
				return NotFound();
			}

			return message;
		}

		[HttpPost]
		public ActionResult<Message> PostMessage(Message newMessage)
		{
			newMessage.Id = Messages.Count + 1;
			Messages.Add(newMessage);
			return CreatedAtAction(nameof(GetMessage), new { id = newMessage.Id }, newMessage);
		}

		[HttpPut("{id}")]
		public IActionResult PutMessage(int id, Message updatedMessage)
		{
			var index = Messages.FindIndex(m => m.Id == id);
			if (index == -1)
			{
				return NotFound();
			}

			Messages[index] = updatedMessage;
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var message = Messages.Find(m => m.Id == id);
			if (message == null)
			{
				return NotFound();
			}

			Messages.Remove(message);
			return NoContent();
		}
	}
}
