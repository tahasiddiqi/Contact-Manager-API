using Contact_Manager.EFCore;
using Contact_Manager.Model;
using Microsoft.AspNetCore.Mvc;


namespace Contact_Manager.Controllers
{
    
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DbHelper _db;
        public ContactController(ContactDbContext contactdbContext)
        {
            _db = new DbHelper(contactdbContext);
        }
        
        [HttpGet]
        [Route("api/[controller]/ReadAllContacts")]
        public IActionResult ReadAllContacts()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ContactModel> data = _db.GetContacts();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
                
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        
        [HttpGet]
        [Route("api/[controller]/ReadContactsById/{id}")]
        public IActionResult ReadContact(int id)
        {

            ResponseType type = ResponseType.Success;
            try
            {
                ContactModel contact = _db.GetContactById(id);

                if (contact == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, contact));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    

        
        [HttpPost]
        [Route("api/[controller]/CreateContact")]
        public IActionResult CreateContact([FromBody] ContactModel model)
        {
            ResponseType type = ResponseType.Success;
            try
            {
           
            _db.SaveContact(model);
            return Ok(ResponseHandler.GetAppResponse(type, model));
            }
        catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

       
        [HttpPut]
       [Route("api/[controller]/UpdateContact/{id}")]
        public IActionResult UpdateContact([FromBody] ContactModel model)
        {
            ResponseType type = ResponseType.Success;
            try
            {
            _db.SaveContact(model);
            return Ok(ResponseHandler.GetAppResponse(type, model));
             }
               catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        
        [HttpDelete]
        [Route("api/[controller]/DeleteContact/{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {

                _db.DeleteContact(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Deleted Successfully"));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
     
}