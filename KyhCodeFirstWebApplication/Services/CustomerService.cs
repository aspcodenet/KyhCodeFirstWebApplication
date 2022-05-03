using System.Reflection.Metadata;

namespace KyhCodeFirstWebApplication.Services;

public class Test
{
    public void Testar()
    {


        var cust = new CustomerService();
        var error = cust.Create("231231", "234342");
        if (error == CustomerService.StatusCode.Ok)
        {
            //Få tag i idt
        }

        int theNewIdt;
        var error2= cust.CreateWithOutParam("231231", "234342", out theNewIdt);
        if (error2 == CustomerService.StatusCode.Ok)
        {
            //Få tag i idt
            //theNewIdt har ett värde
        }


        var (errorCode, id) = cust.CreateWithTuple("addadasda", "32113231");
        if (errorCode == CustomerService.StatusCode.Ok)
        {
            Console.Write(id);
        }

    }
}
public class CustomerService
{
    public enum StatusCode
    {
        Ok,
        Error_Blabla
    }

    public class CreateResult
    {
        public StatusCode Code { get; set; }
        public int TheNewId { get; set; }
    }

    public CreateResult CreateWithResult(string namn, string city)
    {
        if (namn == null)
            return new CreateResult
            {
                Code = StatusCode.Error_Blabla,
                TheNewId = 0
            };
        // var c = new Customer()
        // _context.saveChanges()
        // int newId = c.Id;
        int newId = 123;
        return new CreateResult
        {
            Code = StatusCode.Ok,
            TheNewId = newId
        };
    }


    public StatusCode CreateWithOutParam(string namn, string city, out int theNewId)
    {
        theNewId = 0;
        if (namn == null)
            return StatusCode.Error_Blabla;
        // var c = new Customer()
        // _context.saveChanges()
        // int newId = c.Id;
        int newId = 123;
        theNewId = newId;
        return StatusCode.Ok;
    }



    public (StatusCode, int ) CreateWithTuple(string namn, string city)
    {
        if (namn == null)
            return (StatusCode.Error_Blabla, 0);
        // var c = new Customer()
        // _context.saveChanges()
        // int newId = c.Id;
        int newId = 123;
        return (StatusCode.Ok, newId);
    }



    public StatusCode Create(string namn, string city)
    {
        if (namn == null)
            return StatusCode.Error_Blabla;
        // var c = new Customer()
        // _context.saveChanges()
        // int newId = c.Id;
        int newId = 123;
        return StatusCode.Ok;
    }
}
